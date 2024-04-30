using Newtonsoft.Json;
using System.Text.Json;

namespace f_
{
	partial class EU_Form
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
			string oT_ = JsonConvert.SerializeObject(D_.fN_(), Formatting.Indented);
			File.WriteAllText(D_.q_, oT_);
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
			Q8_ = new Button();
			xC_ = new TextBox();
			h_ = new ListView();
			e0_ = new ColumnHeader();
			rU_ = new Button();
			p7_ = new Label();
			VO_ = new Label();
			p__ = new Label();
			I6_ = new TextBox();
			y_ = new TextBox();
			FQ_ = new Button();
			J_ = new SplitContainer();
			j7_ = new Label();
			((System.ComponentModel.ISupportInitialize)J_).BeginInit();
			J_.Panel1.SuspendLayout();
			J_.Panel2.SuspendLayout();
			J_.SuspendLayout();
			SuspendLayout();
			// 
			// AddRecordButton
			// 
			Q8_.Font = new Font("Microsoft Sans Serif", 10F);
			Q8_.Location = new Point(505, 149);
			Q8_.Margin = new Padding(3, 4, 3, 4);
			Q8_.Name = "AddRecordButton";
			Q8_.Size = new Size(75, 30);
			Q8_.TabIndex = 0;
			Q8_.Text = "Add";
			Q8_.UseVisualStyleBackColor = true;
			Q8_.Click += v6_;
			// 
			// inputTextBox
			// 
			xC_.Font = new Font("Microsoft Sans Serif", 10F);
			xC_.Location = new Point(47, 151);
			xC_.Margin = new Padding(3, 4, 3, 4);
			xC_.MaxLength = 100;
			xC_.Name = "inputTextBox";
			xC_.Size = new Size(452, 26);
			xC_.TabIndex = 1;
			// 
			// recordsListView
			// 
			h_.Columns.AddRange(new ColumnHeader[] { e0_ });
			h_.Location = new Point(47, 200);
			h_.Margin = new Padding(3, 4, 3, 4);
			h_.Name = "recordsListView";
			h_.Size = new Size(533, 170);
			h_.TabIndex = 2;
			h_.UseCompatibleStateImageBehavior = false;
			h_.View = View.Details;
			// 
			// RecordsColumn
			// 
			e0_.Text = "User's Records";
			e0_.Width = 527;
			// 
			// logOutButton
			// 
			rU_.Font = new Font("Microsoft Sans Serif", 9F);
			rU_.Location = new Point(1020, 20);
			rU_.Margin = new Padding(3, 4, 3, 4);
			rU_.Name = "logOutButton";
			rU_.Size = new Size(102, 29);
			rU_.TabIndex = 12;
			rU_.Text = "Log out";
			rU_.UseVisualStyleBackColor = true;
			rU_.Click += s_;
			// 
			// titlelabel
			// 
			p7_.AutoSize = true;
			p7_.Font = new Font("Segoe UI", 13F);
			p7_.Location = new Point(148, 106);
			p7_.Name = "titlelabel";
			p7_.Size = new Size(229, 30);
			p7_.TabIndex = 18;
			p7_.Text = "Add new user (Admin)";
			// 
			// passwordLabel
			// 
			VO_.AutoSize = true;
			VO_.Font = new Font("Microsoft Sans Serif", 11F);
			VO_.Location = new Point(42, 260);
			VO_.Name = "passwordLabel";
			VO_.Size = new Size(92, 24);
			VO_.TabIndex = 17;
			VO_.Text = "Password";
			// 
			// usernameLabel
			// 
			p__.AutoSize = true;
			p__.Font = new Font("Microsoft Sans Serif", 11F);
			p__.Location = new Point(42, 205);
			p__.Name = "usernameLabel";
			p__.Size = new Size(97, 24);
			p__.TabIndex = 16;
			p__.Text = "Username";
			// 
			// passwordTextBox
			// 
			I6_.Font = new Font("Microsoft Sans Serif", 11F);
			I6_.Location = new Point(157, 260);
			I6_.Margin = new Padding(3, 4, 3, 4);
			I6_.Name = "passwordTextBox";
			I6_.Size = new Size(279, 28);
			I6_.TabIndex = 15;
			// 
			// usernameTextBox
			// 
			y_.Font = new Font("Microsoft Sans Serif", 11F);
			y_.Location = new Point(157, 205);
			y_.Margin = new Padding(3, 4, 3, 4);
			y_.Name = "usernameTextBox";
			y_.Size = new Size(279, 28);
			y_.TabIndex = 14;
			// 
			// createUserButton
			// 
			FQ_.Font = new Font("Microsoft Sans Serif", 10F);
			FQ_.Location = new Point(334, 337);
			FQ_.Margin = new Padding(3, 4, 3, 4);
			FQ_.Name = "createUserButton";
			FQ_.Size = new Size(102, 33);
			FQ_.TabIndex = 13;
			FQ_.Text = "Add";
			FQ_.UseVisualStyleBackColor = true;
			FQ_.Click += a_;
			// 
			// splitContainer1
			// 
			J_.Location = new Point(12, 56);
			J_.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			J_.Panel1.BackColor = SystemColors.Control;
			J_.Panel1.Controls.Add(FQ_);
			J_.Panel1.Controls.Add(p7_);
			J_.Panel1.Controls.Add(y_);
			J_.Panel1.Controls.Add(VO_);
			J_.Panel1.Controls.Add(I6_);
			J_.Panel1.Controls.Add(p__);
			// 
			// splitContainer1.Panel2
			// 
			J_.Panel2.BackColor = SystemColors.Control;
			J_.Panel2.Controls.Add(j7_);
			J_.Panel2.Controls.Add(h_);
			J_.Panel2.Controls.Add(Q8_);
			J_.Panel2.Controls.Add(xC_);
			J_.Size = new Size(1110, 494);
			J_.SplitterDistance = 479;
			J_.TabIndex = 19;
			// 
			// label1
			// 
			j7_.AutoSize = true;
			j7_.Font = new Font("Segoe UI", 13F);
			j7_.Location = new Point(246, 106);
			j7_.Name = "label1";
			j7_.Size = new Size(132, 30);
			j7_.TabIndex = 19;
			j7_.Text = "Add records";
			// 
			// UserForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(255, 224, 192);
			ClientSize = new Size(1134, 562);
			Controls.Add(J_);
			Controls.Add(rU_);
			Margin = new Padding(3, 4, 3, 4);
			Name = "UserForm";
			Text = "UserForm";
			J_.Panel1.ResumeLayout(false);
			J_.Panel1.PerformLayout();
			J_.Panel2.ResumeLayout(false);
			J_.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)J_).EndInit();
			J_.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.Button Q8_;
		private System.Windows.Forms.TextBox xC_;
		private System.Windows.Forms.ListView h_;
		private ColumnHeader e0_;
		private Button rU_;
		private Label p7_;
		private Label VO_;
		private Label p__;
		private TextBox I6_;
		private TextBox y_;
		private Button FQ_;
		private SplitContainer J_;
		private Label j7_;
	}
}