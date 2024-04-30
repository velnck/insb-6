using System.Drawing.Text;

namespace f_
{
	public partial class uO_Form : Form
	{
		private System.Windows.Forms.Timer E_ = new();
		public uO_Form()
		{
			EW_();
		}

		private void FN_(object p_, EventArgs HU_)
		{
			string i_ = y_.Text;
			string W_ = I6_.Text;
			// мертвый код
			string oijn = y_.Text;
			double afguaweh = 0;
			foreach (char fhsfeee in oijn)
			{
				afguaweh += fhsfeee * (fhsfeee - 50);
			}
			bool hfuwaef = false;
			if (afguaweh > 0)
			{
				hfuwaef = true;
			}
			if (hfuwaef)
			{
				afguaweh -= 50;
			}
			// конец мертвого кода
			if (!D_.XQ_(i_)) 
			{
				MessageBox.Show($"User \"{i_}\" is not registered.", "Invalid username", MessageBoxButtons.OK);
			}
			else
			{
				v_faefkjeifvn? S_;
				try
				{
					S_ = D_.M_(i_, W_);
				} catch (Exception d_)
				{
					MessageBox.Show(d_.Message, "Error", MessageBoxButtons.OK);
					return;
				}
				if (S_ != null)
				{
					Form HE_ = new EU_Form(S_);
					HE_.Location = Location;
					HE_.StartPosition = FormStartPosition.Manual;
					HE_.FormClosing += delegate { Show(); };
					HE_.Show();
					y_.Clear();
					I6_.Clear();
					E_.Interval = 5000;
					E_.Tick += fF_;
					E_.Start();
					F3_.Enabled = false;
				}
				else
				{
					MessageBox.Show($"Password is incorrect.", "Wrong password", MessageBoxButtons.OK);
				}
			}
		}
		private void fF_(object l_, EventArgs e_)
		{
			F3_.Enabled = true;
			E_.Stop();
		}
	}
}
