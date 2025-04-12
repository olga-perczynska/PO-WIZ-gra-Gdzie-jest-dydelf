namespace PO_WIZ_gra_krokodyl
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
            bStart = new Button();
            bUstawienia = new Button();
            bKoniec = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // bStart
            // 
            bStart.Location = new Point(127, 243);
            bStart.Name = "bStart";
            bStart.Size = new Size(268, 58);
            bStart.TabIndex = 0;
            bStart.Text = "Start";
            bStart.UseVisualStyleBackColor = true;
            bStart.Click += bStart_Click;
            // 
            // bUstawienia
            // 
            bUstawienia.Location = new Point(127, 341);
            bUstawienia.Name = "bUstawienia";
            bUstawienia.Size = new Size(268, 58);
            bUstawienia.TabIndex = 1;
            bUstawienia.Text = "Ustawienia";
            bUstawienia.UseVisualStyleBackColor = true;
            bUstawienia.Click += bUstawienia_Click;
            // 
            // bKoniec
            // 
            bKoniec.Location = new Point(127, 440);
            bKoniec.Name = "bKoniec";
            bKoniec.Size = new Size(268, 58);
            bKoniec.TabIndex = 2;
            bKoniec.Text = "Koniec";
            bKoniec.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(127, 121);
            label1.Name = "label1";
            label1.Size = new Size(276, 41);
            label1.TabIndex = 3;
            label1.Text = "GDZIE JEST DYDELF";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 599);
            Controls.Add(label1);
            Controls.Add(bKoniec);
            Controls.Add(bUstawienia);
            Controls.Add(bStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bStart;
        private Button bUstawienia;
        private Button bKoniec;
        private Label label1;
    }
}
