namespace ZeeCommApp
{
    partial class UserControl3
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
            this.roundPictureBox2 = new ZeeComm.RoundPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(55, 13);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // roundPictureBox2
            // 
            this.roundPictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.roundPictureBox2.Location = new System.Drawing.Point(2, 1);
            this.roundPictureBox2.Name = "roundPictureBox2";
            this.roundPictureBox2.Size = new System.Drawing.Size(47, 47);
            this.roundPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.roundPictureBox2.TabIndex = 3;
            this.roundPictureBox2.TabStop = false;
            // 
            // UserControl3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundPictureBox2);
            this.Name = "UserControl3";
            this.Size = new System.Drawing.Size(270, 50);
            this.Load += new System.EventHandler(this.UserControl3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ZeeComm.RoundPictureBox roundPictureBox2;
        private System.Windows.Forms.Label label1;
    }
}
