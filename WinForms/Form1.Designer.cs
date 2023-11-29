namespace WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            TXT1 = new TextBox();
            TXT2 = new TextBox();
            BTN_calc = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(515, 118);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(134, 23);
            comboBox1.TabIndex = 0;
            // 
            // TXT1
            // 
            TXT1.Location = new Point(549, 71);
            TXT1.Name = "TXT1";
            TXT1.Size = new Size(100, 23);
            TXT1.TabIndex = 1;
            // 
            // TXT2
            // 
            TXT2.Location = new Point(549, 162);
            TXT2.Name = "TXT2";
            TXT2.Size = new Size(100, 23);
            TXT2.TabIndex = 1;
            // 
            // BTN_calc
            // 
            BTN_calc.Location = new Point(574, 203);
            BTN_calc.Name = "BTN_calc";
            BTN_calc.Size = new Size(75, 23);
            BTN_calc.TabIndex = 2;
            BTN_calc.Text = "חשב";
            BTN_calc.UseVisualStyleBackColor = true;
            BTN_calc.Click += BTN_calc_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BTN_calc);
            Controls.Add(TXT2);
            Controls.Add(TXT1);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private TextBox TXT1;
        private TextBox TXT2;
        private Button BTN_calc;
    }
}