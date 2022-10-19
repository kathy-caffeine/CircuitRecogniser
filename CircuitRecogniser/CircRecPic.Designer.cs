namespace CircuitRecogniser
{
    partial class CircRecPic
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
            this.pictureOutput = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureOutput
            // 
            this.pictureOutput.Location = new System.Drawing.Point(12, 11);
            this.pictureOutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureOutput.Name = "pictureOutput";
            this.pictureOutput.Size = new System.Drawing.Size(802, 522);
            this.pictureOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureOutput.TabIndex = 2;
            this.pictureOutput.TabStop = false;
            // 
            // CircRecPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 544);
            this.Controls.Add(this.pictureOutput);
            this.Name = "CircRecPic";
            this.Text = "CircRecPic";
            this.Load += new System.EventHandler(this.CircRecPic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureOutput;
    }
}