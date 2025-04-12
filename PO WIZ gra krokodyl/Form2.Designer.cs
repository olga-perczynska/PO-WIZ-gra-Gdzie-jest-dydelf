namespace PO_WIZ_gra_krokodyl
{
    partial class Form2
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBoxDydelf = new ComboBox();
            comboBoxSzop = new ComboBox();
            comboBoxKrokodyl = new ComboBox();
            comboBoxX = new ComboBox();
            comboBoxY = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBoxCzas = new TextBox();
            bOK = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(132, 99);
            label1.Name = "label1";
            label1.Size = new Size(117, 41);
            label1.TabIndex = 0;
            label1.Text = "plansza";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(470, 131);
            label2.Name = "label2";
            label2.Size = new Size(104, 41);
            label2.TabIndex = 1;
            label2.Text = "Dydelf";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(480, 252);
            label3.Name = "label3";
            label3.Size = new Size(83, 41);
            label3.TabIndex = 2;
            label3.Text = "Szop";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(451, 365);
            label4.Name = "label4";
            label4.Size = new Size(136, 41);
            label4.TabIndex = 3;
            label4.Text = "Krokodyl";
            label4.Click += label4_Click;
            // 
            // comboBoxDydelf
            // 
            comboBoxDydelf.FormattingEnabled = true;
            comboBoxDydelf.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6" });
            comboBoxDydelf.Location = new Point(444, 186);
            comboBoxDydelf.Name = "comboBoxDydelf";
            comboBoxDydelf.Size = new Size(155, 49);
            comboBoxDydelf.TabIndex = 4;
            comboBoxDydelf.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBoxSzop
            // 
            comboBoxSzop.FormattingEnabled = true;
            comboBoxSzop.Items.AddRange(new object[] { "3", "4", "5", "6", "7", "8" });
            comboBoxSzop.Location = new Point(444, 296);
            comboBoxSzop.Name = "comboBoxSzop";
            comboBoxSzop.Size = new Size(158, 49);
            comboBoxSzop.TabIndex = 5;
            // 
            // comboBoxKrokodyl
            // 
            comboBoxKrokodyl.FormattingEnabled = true;
            comboBoxKrokodyl.Items.AddRange(new object[] { "0", "1" });
            comboBoxKrokodyl.Location = new Point(444, 409);
            comboBoxKrokodyl.Name = "comboBoxKrokodyl";
            comboBoxKrokodyl.Size = new Size(158, 49);
            comboBoxKrokodyl.TabIndex = 6;
            // 
            // comboBoxX
            // 
            comboBoxX.FormattingEnabled = true;
            comboBoxX.Items.AddRange(new object[] { "3", "4", "5", "6", "7", "8", "9", "10" });
            comboBoxX.Location = new Point(116, 186);
            comboBoxX.Name = "comboBoxX";
            comboBoxX.Size = new Size(155, 49);
            comboBoxX.TabIndex = 7;
            // 
            // comboBoxY
            // 
            comboBoxY.FormattingEnabled = true;
            comboBoxY.Items.AddRange(new object[] { "3", "4", "5", "6", "7", "8", "9", "10" });
            comboBoxY.Location = new Point(116, 296);
            comboBoxY.Name = "comboBoxY";
            comboBoxY.Size = new Size(155, 49);
            comboBoxY.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 189);
            label5.Name = "label5";
            label5.Size = new Size(32, 41);
            label5.TabIndex = 9;
            label5.Text = "x";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 304);
            label6.Name = "label6";
            label6.Size = new Size(33, 41);
            label6.TabIndex = 10;
            label6.Text = "y";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 409);
            label7.Name = "label7";
            label7.Size = new Size(74, 41);
            label7.TabIndex = 11;
            label7.Text = "czas";
            label7.Click += label7_Click;
            // 
            // textBoxCzas
            // 
            textBoxCzas.Location = new Point(116, 403);
            textBoxCzas.Name = "textBoxCzas";
            textBoxCzas.Size = new Size(212, 47);
            textBoxCzas.TabIndex = 12;
            textBoxCzas.TextChanged += textBox1_TextChanged;
            // 
            // bOK
            // 
            bOK.Location = new Point(262, 527);
            bOK.Name = "bOK";
            bOK.Size = new Size(188, 58);
            bOK.TabIndex = 13;
            bOK.Text = "OK";
            bOK.UseVisualStyleBackColor = true;
            bOK.Click += bOK_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 643);
            Controls.Add(bOK);
            Controls.Add(textBoxCzas);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboBoxY);
            Controls.Add(comboBoxX);
            Controls.Add(comboBoxKrokodyl);
            Controls.Add(comboBoxSzop);
            Controls.Add(comboBoxDydelf);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxDydelf;
        private ComboBox comboBoxSzop;
        private ComboBox comboBoxKrokodyl;
        private ComboBox comboBoxX;
        private ComboBox comboBoxY;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBoxCzas;
        private Button bOK;
    }
}