namespace App
{
	public partial class AdminForm : Form
	{
		public AdminForm()
		{
			InitializeComponent();
		}

		private void createButton_Click(object sender, EventArgs e)
		{
			string username = usernameTextBox.Text;
			if (username.Length == 0)
			{
				MessageBox.Show($"Enter username.", "Invalid username", MessageBoxButtons.OK);
				return;
			}
			string password = passwordTextBox.Text;
			if (password.Length == 0)
			{
				MessageBox.Show($"Enter password.", "Invalid password", MessageBoxButtons.OK);
				return;
			}
			usernameTextBox.Clear();
			passwordTextBox.Clear();
			UsersList.AddNewUser(username, password);
		}
	}
}
