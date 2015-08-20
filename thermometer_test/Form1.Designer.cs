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
            this.submitBtn = new System.Windows.Forms.Button();
            this.tempFluctuation = new System.Windows.Forms.TextBox();
            this.celsiusRadioBtn1 = new System.Windows.Forms.RadioButton();
            this.fahrenheitRadioBtn1 = new System.Windows.Forms.RadioButton();
            this.fluctuationLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fahrenheitRadioBtn2 = new System.Windows.Forms.RadioButton();
            this.celsiusRadioBtn2 = new System.Windows.Forms.RadioButton();
            this.tempThreshold = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.noDirectionRadioBtn = new System.Windows.Forms.RadioButton();
            this.belowRadioBtn = new System.Windows.Forms.RadioButton();
            this.aboveRadioBtn = new System.Windows.Forms.RadioButton();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(377, 202);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(70, 28);
            this.submitBtn.TabIndex = 1;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // tempFluctuation
            // 
            this.tempFluctuation.Location = new System.Drawing.Point(9, 47);
            this.tempFluctuation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tempFluctuation.Name = "tempFluctuation";
            this.tempFluctuation.Size = new System.Drawing.Size(76, 20);
            this.tempFluctuation.TabIndex = 2;
            // 
            // celsiusRadioBtn1
            // 
            this.celsiusRadioBtn1.AutoSize = true;
            this.celsiusRadioBtn1.Checked = true;
            this.celsiusRadioBtn1.Location = new System.Drawing.Point(106, 31);
            this.celsiusRadioBtn1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.celsiusRadioBtn1.Name = "celsiusRadioBtn1";
            this.celsiusRadioBtn1.Size = new System.Drawing.Size(58, 17);
            this.celsiusRadioBtn1.TabIndex = 3;
            this.celsiusRadioBtn1.TabStop = true;
            this.celsiusRadioBtn1.Text = "Celsius";
            this.celsiusRadioBtn1.UseVisualStyleBackColor = true;
            // 
            // fahrenheitRadioBtn1
            // 
            this.fahrenheitRadioBtn1.AutoSize = true;
            this.fahrenheitRadioBtn1.Location = new System.Drawing.Point(106, 54);
            this.fahrenheitRadioBtn1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fahrenheitRadioBtn1.Name = "fahrenheitRadioBtn1";
            this.fahrenheitRadioBtn1.Size = new System.Drawing.Size(75, 17);
            this.fahrenheitRadioBtn1.TabIndex = 4;
            this.fahrenheitRadioBtn1.Text = "Fahrenheit";
            this.fahrenheitRadioBtn1.UseVisualStyleBackColor = true;
            // 
            // fluctuationLabel
            // 
            this.fluctuationLabel.AutoSize = true;
            this.fluctuationLabel.Location = new System.Drawing.Point(9, 28);
            this.fluctuationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fluctuationLabel.Name = "fluctuationLabel";
            this.fluctuationLabel.Size = new System.Drawing.Size(59, 13);
            this.fluctuationLabel.TabIndex = 5;
            this.fluctuationLabel.Text = "Fluctuation";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fahrenheitRadioBtn1);
            this.groupBox1.Controls.Add(this.fluctuationLabel);
            this.groupBox1.Controls.Add(this.tempFluctuation);
            this.groupBox1.Controls.Add(this.celsiusRadioBtn1);
            this.groupBox1.Location = new System.Drawing.Point(25, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(228, 84);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fluctuation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fahrenheitRadioBtn2);
            this.groupBox2.Controls.Add(this.celsiusRadioBtn2);
            this.groupBox2.Controls.Add(this.tempThreshold);
            this.groupBox2.Location = new System.Drawing.Point(25, 150);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(228, 81);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Temperature Threshold";
            // 
            // fahrenheitRadioBtn2
            // 
            this.fahrenheitRadioBtn2.AutoSize = true;
            this.fahrenheitRadioBtn2.Location = new System.Drawing.Point(106, 41);
            this.fahrenheitRadioBtn2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fahrenheitRadioBtn2.Name = "fahrenheitRadioBtn2";
            this.fahrenheitRadioBtn2.Size = new System.Drawing.Size(75, 17);
            this.fahrenheitRadioBtn2.TabIndex = 2;
            this.fahrenheitRadioBtn2.Text = "Fahrenheit";
            this.fahrenheitRadioBtn2.UseVisualStyleBackColor = true;
            // 
            // celsiusRadioBtn2
            // 
            this.celsiusRadioBtn2.AutoSize = true;
            this.celsiusRadioBtn2.Checked = true;
            this.celsiusRadioBtn2.Location = new System.Drawing.Point(106, 18);
            this.celsiusRadioBtn2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.celsiusRadioBtn2.Name = "celsiusRadioBtn2";
            this.celsiusRadioBtn2.Size = new System.Drawing.Size(58, 17);
            this.celsiusRadioBtn2.TabIndex = 1;
            this.celsiusRadioBtn2.TabStop = true;
            this.celsiusRadioBtn2.Text = "Celsius";
            this.celsiusRadioBtn2.UseVisualStyleBackColor = true;
            // 
            // tempThreshold
            // 
            this.tempThreshold.Location = new System.Drawing.Point(9, 18);
            this.tempThreshold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tempThreshold.Name = "tempThreshold";
            this.tempThreshold.Size = new System.Drawing.Size(76, 20);
            this.tempThreshold.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.noDirectionRadioBtn);
            this.groupBox3.Controls.Add(this.belowRadioBtn);
            this.groupBox3.Controls.Add(this.aboveRadioBtn);
            this.groupBox3.Location = new System.Drawing.Point(281, 64);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(150, 109);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Direction";
            // 
            // noDirectionRadioBtn
            // 
            this.noDirectionRadioBtn.AutoSize = true;
            this.noDirectionRadioBtn.Checked = true;
            this.noDirectionRadioBtn.Location = new System.Drawing.Point(19, 67);
            this.noDirectionRadioBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.noDirectionRadioBtn.Name = "noDirectionRadioBtn";
            this.noDirectionRadioBtn.Size = new System.Drawing.Size(51, 17);
            this.noDirectionRadioBtn.TabIndex = 2;
            this.noDirectionRadioBtn.TabStop = true;
            this.noDirectionRadioBtn.Text = "None";
            this.noDirectionRadioBtn.UseVisualStyleBackColor = true;
            // 
            // belowRadioBtn
            // 
            this.belowRadioBtn.AutoSize = true;
            this.belowRadioBtn.Location = new System.Drawing.Point(19, 46);
            this.belowRadioBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.belowRadioBtn.Name = "belowRadioBtn";
            this.belowRadioBtn.Size = new System.Drawing.Size(54, 17);
            this.belowRadioBtn.TabIndex = 1;
            this.belowRadioBtn.Text = "Below";
            this.belowRadioBtn.UseVisualStyleBackColor = true;
            // 
            // aboveRadioBtn
            // 
            this.aboveRadioBtn.AutoSize = true;
            this.aboveRadioBtn.Location = new System.Drawing.Point(19, 23);
            this.aboveRadioBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.aboveRadioBtn.Name = "aboveRadioBtn";
            this.aboveRadioBtn.Size = new System.Drawing.Size(56, 17);
            this.aboveRadioBtn.TabIndex = 0;
            this.aboveRadioBtn.Text = "Above";
            this.aboveRadioBtn.UseVisualStyleBackColor = true;
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(25, 250);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox.Size = new System.Drawing.Size(422, 300);
            this.resultTextBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 571);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.openInputFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openInputFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.TextBox tempFluctuation;
        private System.Windows.Forms.RadioButton celsiusRadioBtn1;
        private System.Windows.Forms.RadioButton fahrenheitRadioBtn1;
        private System.Windows.Forms.Label fluctuationLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton fahrenheitRadioBtn2;
        private System.Windows.Forms.RadioButton celsiusRadioBtn2;
        private System.Windows.Forms.TextBox tempThreshold;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton belowRadioBtn;
        private System.Windows.Forms.RadioButton aboveRadioBtn;
        private System.Windows.Forms.RadioButton noDirectionRadioBtn;
        private System.Windows.Forms.TextBox resultTextBox;
    }
}

