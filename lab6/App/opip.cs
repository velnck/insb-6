using Newtonsoft.Json;
using System.Text.Json;

namespace f_
{
	public enum FNt_
	{
		k_,
		c_
	}
	public class v_faefkjeifvn
	{
		[JsonProperty("Username")]
		public string e5_ { get; set; }
		[JsonProperty("Password")]
		public string v8_ { get; set; }
		[JsonProperty("Role")]
		public FNt_ Y_ { get; set; }
		[JsonProperty("Records")]
		public List<string> I_ = new List<string>();
		[JsonIgnore]
		public bool A7_ { get; set; } = false;

		public v_faefkjeifvn(string rT_, string L_, FNt_ x0_, List<string> sO_)
		{
			e5_ = rT_;
			v8_ = L_;
			Y_ = x0_;
			if (sO_ != null)
			{
				I_ = sO_;
			}
		}
		public bool iJ_(string L_)
		{
			return L_ == v8_;
		}
		public void V_(string Z_)
		{
			if (A7_)
			{
				I_.Add(Z_);
			}
			else
			{
				throw new Exception("User is not logged in.");
			}
		}
	}
	public class D_
	{
		private static List<v_faefkjeifvn> ZG_ = null;
		public static readonly string q_ = @"D:\univ\labs\s6\исоб\labs\lab4\App\data.json";
		private static int m_ = 3;

		private static v_faefkjeifvn cM_(string rT_)
		{
			if (ZG_ == null)
			{
				AR_();
			}
			v_faefkjeifvn g_ = ZG_.Find(s__ => s__.e5_ == rT_);
			return g_;
		}
		public static List<v_faefkjeifvn> fN_()
		{
			if (ZG_ == null)
			{
				AR_();
			}
			return ZG_;
		}
		private static void AR_()
		{
			string oT_ = File.ReadAllText(q_);
			ZG_ = JsonConvert.DeserializeObject<List<v_faefkjeifvn>>(oT_);
		}
		public static void n_(string rT_, string L_)
		{
			ZG_.Add(new v_faefkjeifvn(rT_, L_, FNt_.k_, null));
		}

		internal static v_faefkjeifvn? M_(string rT_, string L_)
		{
			v_faefkjeifvn g_ = cM_(rT_);
			if (g_ == null)
			{
				throw new Exception("User not found.");
			}
			else if (g_.A7_) {
				throw new Exception("User is already logged in.");
			}
			else
			{
				if (g_.iJ_(L_))
				{
					if (ZG_.Where(s__ => s__.A7_).Count() >= m_)
					{
						throw new Exception("Too many users are logged in.");
					}
					g_.A7_ = true;
					return g_;
				}
				else
				{
					return null;
				}
			}
		}

		internal static bool XQ_(string rT_)
		{
			return cM_(rT_) != null;
		}

		internal static void f9_(v_faefkjeifvn g_)
		{
			g_.A7_ = false;
		}
	}
}
