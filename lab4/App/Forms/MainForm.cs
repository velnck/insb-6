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
			User user = UsersList.Find(username);
			if (user == null) 
			{
				MessageBox.Show($"User \"{username}\" is not registered.", "Invalid username", MessageBoxButtons.OK);
			}
			else
			{
				if (user.CheckIsPasswordCorrect(password))
				{
					Form form;
					if (user.Role == Role.Admin)
					{
						form = new AdminForm();
					}
					else
					{
						form = new UserForm(user);
						
					}
					form.Location = Location;
					form.StartPosition = FormStartPosition.Manual;
					form.FormClosing += delegate { Show(); };
					form.Show();
					Hide();
				}
				else
				{
					MessageBox.Show($"Password is incorrect.", "Wrong password", MessageBoxButtons.OK);
				}
			}
		}
	}
}
