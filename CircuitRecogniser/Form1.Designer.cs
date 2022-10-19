
namespace CircuitRecogniser
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureInput = new System.Windows.Forms.PictureBox();
            this.pictureBoxInfo = new System.Windows.Forms.PictureBox();
            this.groupBoxAlgoritmName = new System.Windows.Forms.GroupBox();
            this.radioButSapo = new System.Windows.Forms.RadioButton();
            this.radioButPrevit = new System.Windows.Forms.RadioButton();
            this.radioButSobel = new System.Windows.Forms.RadioButton();
            this.radioButRoberts = new System.Windows.Forms.RadioButton();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).BeginInit();
            this.groupBoxAlgoritmName.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureInput
            // 
            this.pictureInput.Location = new System.Drawing.Point(12, 187);
            this.pictureInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureInput.Name = "pictureInput";
            this.pictureInput.Size = new System.Drawing.Size(260, 268);
            this.pictureInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureInput.TabIndex = 0;
            this.pictureInput.TabStop = false;
            // 
            // pictureBoxInfo
            // 
            this.pictureBoxInfo.Location = new System.Drawing.Point(397, 11);
            this.pictureBoxInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxInfo.Name = "pictureBoxInfo";
            this.pictureBoxInfo.Size = new System.Drawing.Size(260, 170);
            this.pictureBoxInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxInfo.TabIndex = 2;
            this.pictureBoxInfo.TabStop = false;
            // 
            // groupBoxAlgoritmName
            // 
            this.groupBoxAlgoritmName.Controls.Add(this.radioButSapo);
            this.groupBoxAlgoritmName.Controls.Add(this.radioButPrevit);
            this.groupBoxAlgoritmName.Controls.Add(this.radioButSobel);
            this.groupBoxAlgoritmName.Controls.Add(this.radioButRoberts);
            this.groupBoxAlgoritmName.Location = new System.Drawing.Point(12, 53);
            this.groupBoxAlgoritmName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxAlgoritmName.Name = "groupBoxAlgoritmName";
            this.groupBoxAlgoritmName.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxAlgoritmName.Size = new System.Drawing.Size(187, 128);
            this.groupBoxAlgoritmName.TabIndex = 3;
            this.groupBoxAlgoritmName.TabStop = false;
            this.groupBoxAlgoritmName.Text = "Названия Алгоритмов";
            // 
            // radioButSapo
            // 
            this.radioButSapo.AutoSize = true;
            this.radioButSapo.Location = new System.Drawing.Point(5, 96);
            this.radioButSapo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButSapo.Name = "radioButSapo";
            this.radioButSapo.Size = new System.Drawing.Size(121, 20);
            this.radioButSapo.TabIndex = 3;
            this.radioButSapo.TabStop = true;
            this.radioButSapo.Text = "Фильтр Саппу";
            this.radioButSapo.UseVisualStyleBackColor = true;
            // 
            // radioButPrevit
            // 
            this.radioButPrevit.AutoSize = true;
            this.radioButPrevit.Location = new System.Drawing.Point(5, 70);
            this.radioButPrevit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButPrevit.Name = "radioButPrevit";
            this.radioButPrevit.Size = new System.Drawing.Size(144, 20);
            this.radioButPrevit.TabIndex = 2;
            this.radioButPrevit.TabStop = true;
            this.radioButPrevit.Text = "Фильтр Превитта";
            this.radioButPrevit.UseVisualStyleBackColor = true;
            // 
            // radioButSobel
            // 
            this.radioButSobel.AutoSize = true;
            this.radioButSobel.Location = new System.Drawing.Point(5, 44);
            this.radioButSobel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButSobel.Name = "radioButSobel";
            this.radioButSobel.Size = new System.Drawing.Size(128, 20);
            this.radioButSobel.TabIndex = 1;
            this.radioButSobel.TabStop = true;
            this.radioButSobel.Text = "Фильтр Собеля";
            this.radioButSobel.UseVisualStyleBackColor = true;
            // 
            // radioButRoberts
            // 
            this.radioButRoberts.AutoSize = true;
            this.radioButRoberts.Location = new System.Drawing.Point(5, 18);
            this.radioButRoberts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButRoberts.Name = "radioButRoberts";
            this.radioButRoberts.Size = new System.Drawing.Size(143, 20);
            this.radioButRoberts.TabIndex = 0;
            this.radioButRoberts.TabStop = true;
            this.radioButRoberts.Text = "Фильтр Робертса";
            this.radioButRoberts.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(205, 11);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(186, 38);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Обработать";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(12, 11);
            this.buttonUpload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(187, 38);
            this.buttonUpload.TabIndex = 5;
            this.buttonUpload.Text = "Загрузить изображение";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Enabled = false;
            this.buttonDownload.Location = new System.Drawing.Point(205, 53);
            this.buttonDownload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(186, 38);
            this.buttonDownload.TabIndex = 6;
            this.buttonDownload.Text = "Сохранить изображение";
            this.buttonDownload.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 466);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBoxAlgoritmName);
            this.Controls.Add(this.pictureBoxInfo);
            this.Controls.Add(this.pictureInput);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Поиск контуров";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).EndInit();
            this.groupBoxAlgoritmName.ResumeLayout(false);
            this.groupBoxAlgoritmName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureInput;
        private System.Windows.Forms.PictureBox pictureBoxInfo;
        private System.Windows.Forms.GroupBox groupBoxAlgoritmName;
        private System.Windows.Forms.RadioButton radioButSapo;
        private System.Windows.Forms.RadioButton radioButPrevit;
        private System.Windows.Forms.RadioButton radioButSobel;
        private System.Windows.Forms.RadioButton radioButRoberts;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

