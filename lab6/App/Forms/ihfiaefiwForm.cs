using System.Text.RegularExpressions;

namespace f_
{
	public partial class v_Form : Form
	{
		private v_faefkjeifvn z_;
		public v_Form(v_faefkjeifvn g_)
		{
			InitializeComponent();
			z_ = g_;
			foreach (string Z_ in z_.I_)
			{
				recordsListView.Items.Add(new ListViewItem(Z_));
			}
			if (z_.Y_ != FNt_.c_)
			{
				createUserButton.Enabled = false;
			}
		}

		private void v6_(object l_, EventArgs e_)
		{
			string r_ = inputTextBox.Text;
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
					z_.V_(r_);
				}
				catch (Exception A_)
				{
					MessageBox.Show(A_.Message, "Error", MessageBoxButtons.OK);
				}
				recordsListView.Items.Add(new ListViewItem(r_));
				inputTextBox.Clear();
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
				string rT_ = usernameTextBox.Text;
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
				string L_ = passwordTextBox.Text;
				if (L_.Length == 0)
				{
					MessageBox.Show($"Enter password.", "Invalid password", MessageBoxButtons.OK);
					return;
				}
				usernameTextBox.Clear();
				passwordTextBox.Clear();
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
