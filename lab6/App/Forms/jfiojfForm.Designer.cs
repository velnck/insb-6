namespace f_
{
	partial class v_hjfhsihfForm
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
			logInButton = new Button();
			usernameTextBox = new TextBox();
			passwordTextBox = new TextBox();
			usernameLabel = new Label();
			passwordLabel = new Label();
			SuspendLayout();
			// 
			// logInButton
			// 
			logInButton.Font = new Font("Microsoft Sans Serif", 11F);
			logInButton.Location = new Point(523, 319);
			logInButton.Margin = new Padding(3, 4, 3, 4);
			logInButton.Name = "logInButton";
			logInButton.Size = new Size(102, 46);
			logInButton.TabIndex = 0;
			logInButton.Text = "Log In";
			logInButton.UseVisualStyleBackColor = true;
			logInButton.Click += FN_;
			// 
			// usernameTextBox
			// 
			usernameTextBox.Font = new Font("Microsoft Sans Serif", 11F);
			usernameTextBox.Location = new Point(323, 177);
			usernameTextBox.Margin = new Padding(3, 4, 3, 4);
			usernameTextBox.Name = "usernameTextBox";
			usernameTextBox.Size = new Size(302, 28);
			usernameTextBox.TabIndex = 1;
			// 
			// passwordTextBox
			// 
			passwordTextBox.Font = new Font("Microsoft Sans Serif", 11F);
			passwordTextBox.Location = new Point(323, 239);
			passwordTextBox.Margin = new Padding(3, 4, 3, 4);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.Size = new Size(302, 28);
			passwordTextBox.TabIndex = 2;
			// 
			// usernameLabel
			// 
			usernameLabel.AutoSize = true;
			usernameLabel.Font = new Font("Microsoft Sans Serif", 11F);
			usernameLabel.Location = new Point(175, 179);
			usernameLabel.Name = "usernameLabel";
			usernameLabel.Size = new Size(97, 24);
			usernameLabel.TabIndex = 3;
			usernameLabel.Text = "Username";
			// 
			// passwordLabel
			// 
			passwordLabel.AutoSize = true;
			passwordLabel.Font = new Font("Microsoft Sans Serif", 11F);
			passwordLabel.Location = new Point(175, 241);
			passwordLabel.Name = "passwordLabel";
			passwordLabel.Size = new Size(92, 24);
			passwordLabel.TabIndex = 4;
			passwordLabel.Text = "Password";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(255, 224, 192);
			ClientSize = new Size(800, 480);
			Controls.Add(passwordLabel);
			Controls.Add(usernameLabel);
			Controls.Add(passwordTextBox);
			Controls.Add(usernameTextBox);
			Controls.Add(logInButton);
			Margin = new Padding(3, 4, 3, 4);
			Name = "MainForm";
			Text = "App";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button logInButton;
		private System.Windows.Forms.TextBox usernameTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Label usernameLabel;
		private System.Windows.Forms.Label passwordLabel;
	}
}

