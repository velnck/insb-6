using Newtonsoft.Json;
using System.Text.Json;

namespace App
{
	partial class UserForm
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
			AddRecordButton = new Button();
			inputTextBox = new TextBox();
			recordsListView = new ListView();
			RecordsColumn = new ColumnHeader();
			logOutButton = new Button();
			titlelabel = new Label();
			passwordLabel = new Label();
			usernameLabel = new Label();
			passwordTextBox = new TextBox();
			usernameTextBox = new TextBox();
			createUserButton = new Button();
			splitContainer1 = new SplitContainer();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			// 
			// AddRecordButton
			// 
			AddRecordButton.Font = new Font("Microsoft Sans Serif", 10F);
			AddRecordButton.Location = new Point(505, 149);
			AddRecordButton.Margin = new Padding(3, 4, 3, 4);
			AddRecordButton.Name = "AddRecordButton";
			AddRecordButton.Size = new Size(75, 30);
			AddRecordButton.TabIndex = 0;
			AddRecordButton.Text = "Add";
			AddRecordButton.UseVisualStyleBackColor = true;
			AddRecordButton.Click += AddRecordButton_Click;
			// 
			// inputTextBox
			// 
			inputTextBox.Font = new Font("Microsoft Sans Serif", 10F);
			inputTextBox.Location = new Point(47, 151);
			inputTextBox.Margin = new Padding(3, 4, 3, 4);
			inputTextBox.MaxLength = 100;
			inputTextBox.Name = "inputTextBox";
			inputTextBox.Size = new Size(452, 26);
			inputTextBox.TabIndex = 1;
			// 
			// recordsListView
			// 
			recordsListView.Columns.AddRange(new ColumnHeader[] { RecordsColumn });
			recordsListView.Location = new Point(47, 200);
			recordsListView.Margin = new Padding(3, 4, 3, 4);
			recordsListView.Name = "recordsListView";
			recordsListView.Size = new Size(533, 170);
			recordsListView.TabIndex = 2;
			recordsListView.UseCompatibleStateImageBehavior = false;
			recordsListView.View = View.Details;
			// 
			// RecordsColumn
			// 
			RecordsColumn.Text = "User's Records";
			RecordsColumn.Width = 527;
			// 
			// logOutButton
			// 
			logOutButton.Font = new Font("Microsoft Sans Serif", 9F);
			logOutButton.Location = new Point(1020, 20);
			logOutButton.Margin = new Padding(3, 4, 3, 4);
			logOutButton.Name = "logOutButton";
			logOutButton.Size = new Size(102, 29);
			logOutButton.TabIndex = 12;
			logOutButton.Text = "Log out";
			logOutButton.UseVisualStyleBackColor = true;
			logOutButton.Click += logOutButton_Click;
			// 
			// titlelabel
			// 
			titlelabel.AutoSize = true;
			titlelabel.Font = new Font("Segoe UI", 13F);
			titlelabel.Location = new Point(148, 106);
			titlelabel.Name = "titlelabel";
			titlelabel.Size = new Size(229, 30);
			titlelabel.TabIndex = 18;
			titlelabel.Text = "Add new user (Admin)";
			// 
			// passwordLabel
			// 
			passwordLabel.AutoSize = true;
			passwordLabel.Font = new Font("Microsoft Sans Serif", 11F);
			passwordLabel.Location = new Point(42, 260);
			passwordLabel.Name = "passwordLabel";
			passwordLabel.Size = new Size(92, 24);
			passwordLabel.TabIndex = 17;
			passwordLabel.Text = "Password";
			// 
			// usernameLabel
			// 
			usernameLabel.AutoSize = true;
			usernameLabel.Font = new Font("Microsoft Sans Serif", 11F);
			usernameLabel.Location = new Point(42, 205);
			usernameLabel.Name = "usernameLabel";
			usernameLabel.Size = new Size(97, 24);
			usernameLabel.TabIndex = 16;
			usernameLabel.Text = "Username";
			// 
			// passwordTextBox
			// 
			passwordTextBox.Font = new Font("Microsoft Sans Serif", 11F);
			passwordTextBox.Location = new Point(157, 260);
			passwordTextBox.Margin = new Padding(3, 4, 3, 4);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.Size = new Size(279, 28);
			passwordTextBox.TabIndex = 15;
			// 
			// usernameTextBox
			// 
			usernameTextBox.Font = new Font("Microsoft Sans Serif", 11F);
			usernameTextBox.Location = new Point(157, 205);
			usernameTextBox.Margin = new Padding(3, 4, 3, 4);
			usernameTextBox.Name = "usernameTextBox";
			usernameTextBox.Size = new Size(279, 28);
			usernameTextBox.TabIndex = 14;
			// 
			// createUserButton
			// 
			createUserButton.Font = new Font("Microsoft Sans Serif", 10F);
			createUserButton.Location = new Point(334, 337);
			createUserButton.Margin = new Padding(3, 4, 3, 4);
			createUserButton.Name = "createUserButton";
			createUserButton.Size = new Size(102, 33);
			createUserButton.TabIndex = 13;
			createUserButton.Text = "Add";
			createUserButton.UseVisualStyleBackColor = true;
			createUserButton.Click += createUserButton_Click;
			// 
			// splitContainer1
			// 
			splitContainer1.Location = new Point(12, 56);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.BackColor = SystemColors.Control;
			splitContainer1.Panel1.Controls.Add(createUserButton);
			splitContainer1.Panel1.Controls.Add(titlelabel);
			splitContainer1.Panel1.Controls.Add(usernameTextBox);
			splitContainer1.Panel1.Controls.Add(passwordLabel);
			splitContainer1.Panel1.Controls.Add(passwordTextBox);
			splitContainer1.Panel1.Controls.Add(usernameLabel);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.BackColor = SystemColors.Control;
			splitContainer1.Panel2.Controls.Add(label1);
			splitContainer1.Panel2.Controls.Add(recordsListView);
			splitContainer1.Panel2.Controls.Add(AddRecordButton);
			splitContainer1.Panel2.Controls.Add(inputTextBox);
			splitContainer1.Size = new Size(1110, 494);
			splitContainer1.SplitterDistance = 479;
			splitContainer1.TabIndex = 19;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 13F);
			label1.Location = new Point(246, 106);
			label1.Name = "label1";
			label1.Size = new Size(132, 30);
			label1.TabIndex = 19;
			label1.Text = "Add records";
			// 
			// UserForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(255, 224, 192);
			ClientSize = new Size(1134, 562);
			Controls.Add(splitContainer1);
			Controls.Add(logOutButton);
			Margin = new Padding(3, 4, 3, 4);
			Name = "UserForm";
			Text = "UserForm";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button AddRecordButton;
		private System.Windows.Forms.TextBox inputTextBox;
		private System.Windows.Forms.ListView recordsListView;
		private ColumnHeader RecordsColumn;
		private Button logOutButton;
		private Label titlelabel;
		private Label passwordLabel;
		private Label usernameLabel;
		private TextBox passwordTextBox;
		private TextBox usernameTextBox;
		private Button createUserButton;
		private SplitContainer splitContainer1;
		private Label label1;
	}
}