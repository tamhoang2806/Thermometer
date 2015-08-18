namespace thermometer_test
{
    partial class Form1
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
            this.openInputFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // openInputFile
            // 
            this.openInputFile.Location = new System.Drawing.Point(25, 25);
            this.openInputFile.Name = "openInputFile";
            this.openInputFile.Size = new System.Drawing.Size(75, 23);
            this.openInputFile.TabIndex = 0;
            this.openInputFile.Text = "Open file";
            this.openInputFile.UseVisualStyleBackColor = true;
            this.openInputFile.Click += new System.EventHandler(this.openInputFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "input";
            this.openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 240);
            this.Controls.Add(this.openInputFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openInputFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

