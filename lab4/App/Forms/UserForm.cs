using System.Text.RegularExpressions;

namespace App
{
	public partial class UserForm : Form
	{
		private User _currentUser;
		public UserForm(User user)
		{
			InitializeComponent();
			_currentUser = user;
			foreach (string record in _currentUser.Records)
			{
				recordsListView.Items.Add(new ListViewItem(record));
			}
			if (_currentUser.Role != Role.Admin)
			{
				createUserButton.Enabled = false;
			}
		}

		private void AddRecordButton_Click(object sender, EventArgs e)
		{
			string text = inputTextBox.Text;
			if (text.Length > 0)
			{
				if (!Regex.IsMatch(text, @"^[A-Za-z0-9 ]*$"))
				{
					MessageBox.Show("Text contains unallowed characters. Allowed characters: A-Z, a-z, 0-9, [space].", 
						"Error", MessageBoxButtons.OK);
					return;
				}
				try
				{
					_currentUser.AddRecord(text);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
				}
				recordsListView.Items.Add(new ListViewItem(text));
				inputTextBox.Clear();
			}
		}

		private void logOutButton_Click(object sender, EventArgs e)
		{
			UsersList.LogOut(_currentUser);
			Dispose();
		}

		private void createUserButton_Click(object sender, EventArgs e)
		{
			if (_currentUser.Role == Role.Admin)
			{
				string username = usernameTextBox.Text;
				if (username.Length == 0)
				{
					MessageBox.Show($"Enter username.", "Invalid username", MessageBoxButtons.OK);
					return;
				}
				if (UsersList.Exists(username))
				{
					MessageBox.Show($"User \"{username}\" already exists.", "Invalid username", MessageBoxButtons.OK);
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
				MessageBox.Show($"User \"{username}\" added.", "User added", MessageBoxButtons.OK);
			}
			else
			{
				MessageBox.Show($"User must have administrative privileges to complete the action.",
					"Error", MessageBoxButtons.OK);
			}
		}
	}
}
