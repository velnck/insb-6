using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
				_currentUser.AddRecord(text);
				recordsListView.Items.Add(new ListViewItem(text));
				inputTextBox.Clear();
			}
		}
	}
}
