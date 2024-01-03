namespace ZeeCommApp
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.userProfilePic = new ZeeComm.RoundPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(69, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // userProfilePic
            // 
            this.userProfilePic.BackColor = System.Drawing.Color.DimGray;
            this.userProfilePic.Location = new System.Drawing.Point(3, 3);
            this.userProfilePic.Name = "userProfilePic";
            this.userProfilePic.Size = new System.Drawing.Size(60, 60);
            this.userProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userProfilePic.TabIndex = 0;
            this.userProfilePic.TabStop = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userProfilePic);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(185, 67);
            ((System.ComponentModel.ISupportInitialize)(this.userProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZeeComm.RoundPictureBox userProfilePic;
        private System.Windows.Forms.Label label1;
    }
}
