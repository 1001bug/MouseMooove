namespace MouseMoove
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
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxONOFF = new System.Windows.Forms.CheckBox();
            this.DelayValBox1 = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DelayValBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pause bwtween moves in sec";
            // 
            // checkBoxONOFF
            // 
            this.checkBoxONOFF.AutoSize = true;
            this.checkBoxONOFF.Enabled = false;
            this.checkBoxONOFF.Location = new System.Drawing.Point(26, 54);
            this.checkBoxONOFF.Name = "checkBoxONOFF";
            this.checkBoxONOFF.Size = new System.Drawing.Size(76, 17);
            this.checkBoxONOFF.TabIndex = 5;
            this.checkBoxONOFF.Text = "On Air";
            this.checkBoxONOFF.UseVisualStyleBackColor = true;
            // 
            // DelayValBox1
            // 
            this.DelayValBox1.Location = new System.Drawing.Point(26, 28);
            this.DelayValBox1.Name = "DelayValBox1";
            this.DelayValBox1.Size = new System.Drawing.Size(43, 20);
            this.DelayValBox1.TabIndex = 7;
            this.DelayValBox1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panel1.Location = new System.Drawing.Point(7, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 182);
            this.panel1.TabIndex = 8;
            this.panel1.Tag = "AAA";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 276);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DelayValBox1);
            this.Controls.Add(this.checkBoxONOFF);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Mouse move";
            ((System.ComponentModel.ISupportInitialize)(this.DelayValBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxONOFF;
        private System.Windows.Forms.NumericUpDown DelayValBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

