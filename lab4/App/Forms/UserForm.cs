namespace App
{
	public partial class UserForm : Form
	{
		private User _currentUser;
		public UserForm(User currentUser)
		{
			InitializeComponent();
			_currentUser = currentUser;
			foreach (string record in _currentUser.Records)
			{
				recordsListView.Items.Add(new ListViewItem(record));
			}
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			string text = inputTextBox.Text;
			if (text.Length > 0)
			{
				try
				{
					_currentUser.AddRecord(text);
				} catch (Exception ex) 
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
	}
}
