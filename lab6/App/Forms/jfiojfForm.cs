using System.Drawing.Text;

namespace f_
{
	public partial class v_hjfhsihfForm : Form
	{
		private System.Windows.Forms.Timer E_ = new();
		public v_hjfhsihfForm()
		{
			InitializeComponent();
		}

		private void FN_(object p_, EventArgs HU_)
		{
			string i_ = usernameTextBox.Text;
			string W_ = passwordTextBox.Text;
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
					Form HE_ = new v_Form(S_);
					HE_.Location = Location;
					HE_.StartPosition = FormStartPosition.Manual;
					HE_.FormClosing += delegate { Show(); };
					HE_.Show();
					usernameTextBox.Clear();
					passwordTextBox.Clear();
					E_.Interval = 5000;
					E_.Tick += fF_;
					E_.Start();
					logInButton.Enabled = false;
				}
				else
				{
					MessageBox.Show($"Password is incorrect.", "Wrong password", MessageBoxButtons.OK);
				}
			}
		}
		private void fF_(object l_, EventArgs e_)
		{
			logInButton.Enabled = true;
			E_.Stop();
		}
	}
}
