namespace OpenYSAuthenticator
{
	partial class AuthenticationForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationForm));
			this.textBox_Password = new System.Windows.Forms.TextBox();
			this.textBox_Username = new System.Windows.Forms.TextBox();
			this.button_Authenticate = new System.Windows.Forms.Button();
			this.imageList_Authenticate = new System.Windows.Forms.ImageList(this.components);
			this.label_Username = new System.Windows.Forms.Label();
			this.label_Password = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label_Result = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// textBox_Password
			// 
			this.textBox_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_Password.Location = new System.Drawing.Point(363, 38);
			this.textBox_Password.Name = "textBox_Password";
			this.textBox_Password.PasswordChar = '*';
			this.textBox_Password.Size = new System.Drawing.Size(100, 20);
			this.textBox_Password.TabIndex = 3;
			this.textBox_Password.Text = "Password";
			// 
			// textBox_Username
			// 
			this.textBox_Username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_Username.Location = new System.Drawing.Point(363, 12);
			this.textBox_Username.Name = "textBox_Username";
			this.textBox_Username.Size = new System.Drawing.Size(100, 20);
			this.textBox_Username.TabIndex = 2;
			this.textBox_Username.Text = "Username";
			// 
			// button_Authenticate
			// 
			this.button_Authenticate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Authenticate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.button_Authenticate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_Authenticate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button_Authenticate.ImageKey = "Shield_Unknown.png";
			this.button_Authenticate.ImageList = this.imageList_Authenticate;
			this.button_Authenticate.Location = new System.Drawing.Point(296, 64);
			this.button_Authenticate.Name = "button_Authenticate";
			this.button_Authenticate.Size = new System.Drawing.Size(167, 36);
			this.button_Authenticate.TabIndex = 4;
			this.button_Authenticate.Text = "     Authenticate";
			this.button_Authenticate.UseVisualStyleBackColor = true;
			this.button_Authenticate.Click += new System.EventHandler(this.button_Authenticate_Click);
			// 
			// imageList_Authenticate
			// 
			this.imageList_Authenticate.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Authenticate.ImageStream")));
			this.imageList_Authenticate.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList_Authenticate.Images.SetKeyName(0, "Shield_Unknown.png");
			this.imageList_Authenticate.Images.SetKeyName(1, "Shield_OK.png");
			this.imageList_Authenticate.Images.SetKeyName(2, "Shield_NOK.png");
			this.imageList_Authenticate.Images.SetKeyName(3, "Shield_Alert.png");
			// 
			// label_Username
			// 
			this.label_Username.AutoSize = true;
			this.label_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Username.Location = new System.Drawing.Point(293, 15);
			this.label_Username.Name = "label_Username";
			this.label_Username.Size = new System.Drawing.Size(67, 13);
			this.label_Username.TabIndex = 4;
			this.label_Username.Text = "Username:";
			// 
			// label_Password
			// 
			this.label_Password.AutoSize = true;
			this.label_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Password.Location = new System.Drawing.Point(293, 41);
			this.label_Password.Name = "label_Password";
			this.label_Password.Size = new System.Drawing.Size(65, 13);
			this.label_Password.TabIndex = 5;
			this.label_Password.Text = "Password:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(275, 88);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// label_Result
			// 
			this.label_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_Result.AutoSize = true;
			this.label_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Result.Location = new System.Drawing.Point(286, 104);
			this.label_Result.Name = "label_Result";
			this.label_Result.Size = new System.Drawing.Size(177, 13);
			this.label_Result.TabIndex = 8;
			this.label_Result.Text = "Authentication Failed: No Username";
			this.label_Result.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// AuthenticationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(475, 126);
			this.Controls.Add(this.label_Result);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label_Password);
			this.Controls.Add(this.label_Username);
			this.Controls.Add(this.button_Authenticate);
			this.Controls.Add(this.textBox_Username);
			this.Controls.Add(this.textBox_Password);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "AuthenticationForm";
			this.Text = "Edit Authentication";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBox_Password;
		private System.Windows.Forms.TextBox textBox_Username;
		private System.Windows.Forms.Button button_Authenticate;
		private System.Windows.Forms.Label label_Username;
		private System.Windows.Forms.Label label_Password;
		private System.Windows.Forms.ImageList imageList_Authenticate;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label_Result;
	}
}