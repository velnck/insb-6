using System.Text.RegularExpressions;

namespace f_
{
	public partial class EU_Form : Form
	{
		private v_faefkjeifvn z_;
		public EU_Form(v_faefkjeifvn g_)
		{
			EW_();
			z_ = g_;
			foreach (string Z_ in z_.I_)
			{
				h_.Items.Add(new ListViewItem(Z_));
			}
			if (z_.Y_ != FNt_.c_)
			{
				FQ_.Enabled = false;
			}
		}

		private void v6_(object l_, EventArgs e_)
		{
			string r_ = xC_.Text;
			if (r_.Length > 0)
			{
				if (!Regex.IsMatch(r_, @"^[A-Za-z0-9 ]*$"))
				{
					MessageBox.Show("Text contains unallowed characters. Allowed characters: A-Z, a-z, 0-9, [space].", 
						"Error", MessageBoxButtons.OK);
					return;
				}
				try
				{
					// открытая вставка функции
					if (z_.A7_)
					{
						z_.I_.Add(r_);
					}
					else
					{
						throw new Exception("User is not logged in.");
					}
				}
				catch (Exception A_)
				{
					MessageBox.Show(A_.Message, "Error", MessageBoxButtons.OK);
				}
				h_.Items.Add(new ListViewItem(r_));
				xC_.Clear();
			}
		}

		private void s_(object l_, EventArgs e_)
		{
			D_.f9_(z_);
			Dispose();
		}

		private void a_(object l_, EventArgs e_)
		{
			if (z_.Y_ == FNt_.c_)
			{
				string rT_ = y_.Text;
				if (rT_.Length == 0)
				{
					MessageBox.Show($"Enter username.", "Invalid username", MessageBoxButtons.OK);
					return;
				}
				if (D_.XQ_(rT_))
				{
					MessageBox.Show($"User \"{rT_}\" already exists.", "Invalid username", MessageBoxButtons.OK);
					return;
				}
				string L_ = I6_.Text;
				if (L_.Length == 0)
				{
					MessageBox.Show($"Enter password.", "Invalid password", MessageBoxButtons.OK);
					return;
				}
				y_.Clear();
				I6_.Clear();
				D_.n_(rT_, L_);
				MessageBox.Show($"User \"{rT_}\" added.", "User added", MessageBoxButtons.OK);
			}
			else
			{
				MessageBox.Show($"User must have administrative privileges to complete the action.",
					"Error", MessageBoxButtons.OK);
			}
		}
	}
}
