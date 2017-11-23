using System.ComponentModel;
using System.Windows.Forms;

namespace Com.OfficerFlake.UserInterfaces.Windows
{
    partial class IOForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOForm));
			this.btn_run = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_run
			// 
			this.btn_run.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btn_run.Location = new System.Drawing.Point(0, 0);
			this.btn_run.Name = "btn_run";
			this.btn_run.Size = new System.Drawing.Size(624, 441);
			this.btn_run.TabIndex = 0;
			this.btn_run.Text = "Run!";
			this.btn_run.UseVisualStyleBackColor = true;
			this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
			// 
			// IOForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 441);
			this.Controls.Add(this.btn_run);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "IOForm";
			this.Text = "IOForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IOForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IOForm_FormClosed);
			this.ResumeLayout(false);

        }

        #endregion

        private Button btn_run;
    }
}

