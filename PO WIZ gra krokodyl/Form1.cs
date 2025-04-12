namespace PO_WIZ_gra_krokodyl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Settings mojeUstawienia = new Settings();
        private void bUstawienia_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            if (form2.ShowDialog() == DialogResult.OK)
            {
                mojeUstawienia = form2.UserSettings;
                MessageBox.Show($"Moje ustawienia\nx = {mojeUstawienia.x}, y = {mojeUstawienia.y}\nDydelfy = {mojeUstawienia.dydelf}\nSzopy = {mojeUstawienia.szop}\nKrokodyle = {mojeUstawienia.krokodyl},");
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            Form3 gameForm = new Form3(mojeUstawienia);
            gameForm.Show();

        }
    }
}
