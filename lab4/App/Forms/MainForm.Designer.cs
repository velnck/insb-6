namespace App
{
	partial class MainForm
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
			this.logInButton = new System.Windows.Forms.Button();
			this.usernameTextBox = new System.Windows.Forms.TextBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.usernameLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// logInButton
			// 
			this.logInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.logInButton.Location = new System.Drawing.Point(353, 302);
			this.logInButton.Name = "logInButton";
			this.logInButton.Size = new System.Drawing.Size(102, 37);
			this.logInButton.TabIndex = 0;
			this.logInButton.Text = "Log In";
			this.logInButton.UseVisualStyleBackColor = true;
			this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
			// 
			// usernameTextBox
			// 
			this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.usernameTextBox.Location = new System.Drawing.Point(404, 116);
			this.usernameTextBox.Name = "usernameTextBox";
			this.usernameTextBox.Size = new System.Drawing.Size(229, 28);
			this.usernameTextBox.TabIndex = 1;
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.passwordTextBox.Location = new System.Drawing.Point(404, 189);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(229, 28);
			this.passwordTextBox.TabIndex = 2;
			// 
			// usernameLabel
			// 
			this.usernameLabel.AutoSize = true;
			this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.usernameLabel.Location = new System.Drawing.Point(183, 120);
			this.usernameLabel.Name = "usernameLabel";
			this.usernameLabel.Size = new System.Drawing.Size(97, 24);
			this.usernameLabel.TabIndex = 3;
			this.usernameLabel.Text = "Username";
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.passwordLabel.Location = new System.Drawing.Point(183, 193);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(92, 24);
			this.passwordLabel.TabIndex = 4;
			this.passwordLabel.Text = "Password";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.usernameLabel);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.usernameTextBox);
			this.Controls.Add(this.logInButton);
			this.Name = "MainForm";
			this.Text = "App";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button logInButton;
		private System.Windows.Forms.TextBox usernameTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Label usernameLabel;
		private System.Windows.Forms.Label passwordLabel;
	}
}

