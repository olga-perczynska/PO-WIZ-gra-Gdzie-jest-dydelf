using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PO_WIZ_gra_krokodyl
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public Settings UserSettings { get; private set; } = new Settings();

        private void bOK_Click(object sender, EventArgs e)
        {
            UserSettings.x = Convert.ToInt32(comboBoxX.SelectedItem);
            UserSettings.y = Convert.ToInt32(comboBoxY.SelectedItem);
            UserSettings.dydelf = Convert.ToInt32(comboBoxDydelf.SelectedItem);
            UserSettings.krokodyl = Convert.ToInt32(comboBoxKrokodyl.SelectedItem);
            UserSettings.szop = Convert.ToInt32(comboBoxSzop.SelectedItem);
            UserSettings.czas = Convert.ToInt32(textBoxCzas.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
