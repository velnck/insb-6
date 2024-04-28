namespace App
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void logInButton_Click(object sender, EventArgs e)
		{
			string username = usernameTextBox.Text;
			string password = passwordTextBox.Text;
			if (!UsersList.Exists(username)) 
			{
				MessageBox.Show($"User \"{username}\" is not registered.", "Invalid username", MessageBoxButtons.OK);
			}
			else
			{
				User? user;
				try
				{
					user = UsersList.LogIn(username, password);
				} catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
					return;
				}
				if (user != null)
				{
					Form form = new UserForm(user);
					form.Location = Location;
					form.StartPosition = FormStartPosition.Manual;
					form.FormClosing += delegate { Show(); };
					form.Show();
					usernameTextBox.Clear();
					passwordTextBox.Clear();
				}
				else
				{
					MessageBox.Show($"Password is incorrect.", "Wrong password", MessageBoxButtons.OK);
				}
			}
		}
	}
}
