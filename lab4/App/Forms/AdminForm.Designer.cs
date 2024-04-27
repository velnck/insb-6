using Newtonsoft.Json;
using System.Text.Json;

namespace App
{
	partial class AdminForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			string str = JsonConvert.SerializeObject(UsersList.GetAll(), Formatting.Indented);
			File.WriteAllText(UsersList.FileName, str);
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			passwordLabel = new Label();
			usernameLabel = new Label();
			passwordTextBox = new TextBox();
			usernameTextBox = new TextBox();
			createButton = new Button();
			titlelabel = new Label();
			SuspendLayout();
			// 
			// passwordLabel
			// 
			passwordLabel.AutoSize = true;
			passwordLabel.Font = new Font("Microsoft Sans Serif", 11F);
			passwordLabel.Location = new Point(187, 218);
			passwordLabel.Name = "passwordLabel";
			passwordLabel.Size = new Size(92, 24);
			passwordLabel.TabIndex = 9;
			passwordLabel.Text = "Password";
			// 
			// usernameLabel
			// 
			usernameLabel.AutoSize = true;
			usernameLabel.Font = new Font("Microsoft Sans Serif", 11F);
			usernameLabel.Location = new Point(187, 159);
			usernameLabel.Name = "usernameLabel";
			usernameLabel.Size = new Size(97, 24);
			usernameLabel.TabIndex = 8;
			usernameLabel.Text = "Username";
			// 
			// passwordTextBox
			// 
			passwordTextBox.Font = new Font("Microsoft Sans Serif", 11F);
			passwordTextBox.Location = new Point(408, 213);
			passwordTextBox.Margin = new Padding(3, 4, 3, 4);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.Size = new Size(229, 28);
			passwordTextBox.TabIndex = 7;
			// 
			// usernameTextBox
			// 
			usernameTextBox.Font = new Font("Microsoft Sans Serif", 11F);
			usernameTextBox.Location = new Point(408, 154);
			usernameTextBox.Margin = new Padding(3, 4, 3, 4);
			usernameTextBox.Name = "usernameTextBox";
			usernameTextBox.Size = new Size(229, 28);
			usernameTextBox.TabIndex = 6;
			// 
			// createButton
			// 
			createButton.Font = new Font("Microsoft Sans Serif", 11F);
			createButton.Location = new Point(343, 322);
			createButton.Margin = new Padding(3, 4, 3, 4);
			createButton.Name = "createButton";
			createButton.Size = new Size(102, 35);
			createButton.TabIndex = 5;
			createButton.Text = "Add";
			createButton.UseVisualStyleBackColor = true;
			createButton.Click += createButton_Click;
			// 
			// titlelabel
			// 
			titlelabel.AutoSize = true;
			titlelabel.Font = new Font("Segoe UI", 13F);
			titlelabel.Location = new Point(321, 76);
			titlelabel.Name = "titlelabel";
			titlelabel.Size = new Size(146, 30);
			titlelabel.TabIndex = 10;
			titlelabel.Text = "Add new user";
			// 
			// AdminForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(titlelabel);
			Controls.Add(passwordLabel);
			Controls.Add(usernameLabel);
			Controls.Add(passwordTextBox);
			Controls.Add(usernameTextBox);
			Controls.Add(createButton);
			Name = "AdminForm";
			Text = "AdminForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label passwordLabel;
		private Label usernameLabel;
		private TextBox passwordTextBox;
		private TextBox usernameTextBox;
		private Button createButton;
		private Label titlelabel;
	}
}