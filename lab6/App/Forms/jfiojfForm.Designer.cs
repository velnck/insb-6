namespace f_
{
	partial class uO_Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer zY_ = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="LB_">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool LB_)
		{
			if (LB_ && (zY_ != null))
			{
				zY_.Dispose();
			}
			base.Dispose(LB_);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void EW_()
		{
			F3_ = new Button();
			y_ = new TextBox();
			I6_ = new TextBox();
			p__ = new Label();
			VO_ = new Label();
			SuspendLayout();
			// 
			// logInButton
			// 
			F3_.Font = new Font("Microsoft Sans Serif", 11F);
			F3_.Location = new Point(523, 319);
			F3_.Margin = new Padding(3, 4, 3, 4);
			F3_.Name = "logInButton";
			F3_.Size = new Size(102, 46);
			F3_.TabIndex = 0;
			F3_.Text = "Log In";
			F3_.UseVisualStyleBackColor = true;
			F3_.Click += FN_;
			// 
			// usernameTextBox
			// 
			y_.Font = new Font("Microsoft Sans Serif", 11F);
			y_.Location = new Point(323, 177);
			y_.Margin = new Padding(3, 4, 3, 4);
			y_.Name = "usernameTextBox";
			y_.Size = new Size(302, 28);
			y_.TabIndex = 1;
			// 
			// passwordTextBox
			// 
			I6_.Font = new Font("Microsoft Sans Serif", 11F);
			I6_.Location = new Point(323, 239);
			I6_.Margin = new Padding(3, 4, 3, 4);
			I6_.Name = "passwordTextBox";
			I6_.Size = new Size(302, 28);
			I6_.TabIndex = 2;
			// 
			// usernameLabel
			// 
			p__.AutoSize = true;
			p__.Font = new Font("Microsoft Sans Serif", 11F);
			p__.Location = new Point(175, 179);
			p__.Name = "usernameLabel";
			p__.Size = new Size(97, 24);
			p__.TabIndex = 3;
			p__.Text = "Username";
			// 
			// passwordLabel
			// 
			VO_.AutoSize = true;
			VO_.Font = new Font("Microsoft Sans Serif", 11F);
			VO_.Location = new Point(175, 241);
			VO_.Name = "passwordLabel";
			VO_.Size = new Size(92, 24);
			VO_.TabIndex = 4;
			VO_.Text = "Password";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(255, 224, 192);
			ClientSize = new Size(800, 480);
			Controls.Add(VO_);
			Controls.Add(p__);
			Controls.Add(I6_);
			Controls.Add(y_);
			Controls.Add(F3_);
			Margin = new Padding(3, 4, 3, 4);
			Name = "MainForm";
			Text = "App";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button F3_;
		private System.Windows.Forms.TextBox y_;
		private System.Windows.Forms.TextBox I6_;
		private System.Windows.Forms.Label p__;
		private System.Windows.Forms.Label VO_;
	}
}

