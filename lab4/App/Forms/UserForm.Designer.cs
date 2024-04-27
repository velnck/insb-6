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
			AddButton = new Button();
			inputTextBox = new TextBox();
			recordsListView = new ListView();
			RecordsColumn = new ColumnHeader();
			SuspendLayout();
			// 
			// AddButton
			// 
			AddButton.Font = new Font("Microsoft Sans Serif", 10F);
			AddButton.Location = new Point(585, 121);
			AddButton.Margin = new Padding(3, 4, 3, 4);
			AddButton.Name = "AddButton";
			AddButton.Size = new Size(75, 32);
			AddButton.TabIndex = 0;
			AddButton.Text = "Add";
			AddButton.UseVisualStyleBackColor = true;
			AddButton.Click += AddButton_Click;
			// 
			// inputTextBox
			// 
			inputTextBox.Font = new Font("Microsoft Sans Serif", 10F);
			inputTextBox.Location = new Point(127, 124);
			inputTextBox.Margin = new Padding(3, 4, 3, 4);
			inputTextBox.Name = "inputTextBox";
			inputTextBox.Size = new Size(452, 26);
			inputTextBox.TabIndex = 1;
			// 
			// recordsListView
			// 
			recordsListView.Columns.AddRange(new ColumnHeader[] { RecordsColumn });
			recordsListView.Location = new Point(127, 192);
			recordsListView.Margin = new Padding(3, 4, 3, 4);
			recordsListView.Name = "recordsListView";
			recordsListView.Size = new Size(533, 278);
			recordsListView.TabIndex = 2;
			recordsListView.UseCompatibleStateImageBehavior = false;
			recordsListView.View = View.Details;
			// 
			// RecordsColumn
			// 
			RecordsColumn.Text = "User's Records";
			RecordsColumn.Width = 527;
			// 
			// UserForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 562);
			Controls.Add(recordsListView);
			Controls.Add(inputTextBox);
			Controls.Add(AddButton);
			Margin = new Padding(3, 4, 3, 4);
			Name = "UserForm";
			Text = "UserForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.TextBox inputTextBox;
		private System.Windows.Forms.ListView recordsListView;
		private ColumnHeader RecordsColumn;
	}
}