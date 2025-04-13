using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PO_WIZ_gra_krokodyl
{
    public partial class Form3 : Form
    {
        private System.Windows.Forms.Timer timer;
        private int czasPozostaly;
        private Settings ustawienia;
        private Dictionary<Button, DateTime> odkryteKrokodyle = new Dictionary<Button, DateTime>();
        private int odkryteDydelfy = 0;
        private Label lblCzas;
        private Panel panelCzas;

        public Form3(Settings settings)
        {
            InitializeComponent();

            ustawienia = settings;
            StworzPlansze();
            czasPozostaly = ustawienia.czas;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblCzas.Text = $"Czas: {czasPozostaly}s";

            czasPozostaly--;

            if (czasPozostaly <= 0)
            {
                timer.Stop();
                MessageBox.Show("Przegrałeś, czas się skończył", "Koniec gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            var teraz = DateTime.Now;
            foreach (var entry in odkryteKrokodyle.ToList())
            {
                if ((teraz - entry.Value).TotalSeconds >= 2)
                {
                    timer.Stop();
                    MessageBox.Show("Przegrałeś! Nie zakryłeś krokodyla na czas.");
                    this.Close();
                    return;
                }
            }
        }

        private void StworzPlansze()
        {
            int buttonSize = 200;
            int padding = 10;

            List<string> karty = przygotujKarty();

            int index = 0;

            for (int i = 0; i < ustawienia.x; i++)
            {
                for (int j = 0; j < ustawienia.y; j++)
                {
                    Button btn = new Button();
                    btn.Width = buttonSize;
                    btn.Height = buttonSize;
                    btn.Left = i * (buttonSize + padding);
                    btn.Top = j * (buttonSize + padding);
                    btn.BackColor = Color.LightGray;
                    btn.Tag = false;

                    if (index < karty.Count)
                    {
                        btn.Tag = karty[index];
                        index++;
                    }

                    btn.Click += ObracanieKarty;

                    this.Controls.Add(btn);
                }
            }

            this.ClientSize = new Size(
                ustawienia.x * (buttonSize + padding),
                ustawienia.y * (buttonSize + padding) + 50 
            );

            panelCzas = new Panel();
            panelCzas.Dock = DockStyle.Bottom;
            panelCzas.Height = 50;
            panelCzas.BackColor = Color.Transparent;

            lblCzas = new Label();
            lblCzas.AutoSize = true;
            lblCzas.Font = new Font("Arial", 14, FontStyle.Bold);
            lblCzas.ForeColor = Color.Black;
            lblCzas.Text = $"Czas: {czasPozostaly}s";
            panelCzas.Controls.Add(lblCzas);  

            this.Controls.Add(panelCzas);  
        }


        private void ObracanieKarty(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string typKarty = (string)btn.Tag;

            if (typKarty == "krokodyl")
            {
                if (btn.BackColor == Color.LightGray)
                {
                    btn.BackColor = Color.White;
                    btn.Text = typKarty;
                    odkryteKrokodyle[btn] = DateTime.Now;
                }
                else if (btn.BackColor == Color.White && odkryteKrokodyle.ContainsKey(btn))
                {
                    btn.BackColor = Color.LightGray;
                    btn.Text = "";
                    odkryteKrokodyle.Remove(btn);
                }
            }
            else if (typKarty == "szop")
            {
                btn.BackColor = Color.White;
                btn.Text = typKarty;

                var _ = Task.Delay(2000).ContinueWith(_ =>
                {
                    this.Invoke(new Action(() =>
                    {
                        UkryjKarteISasiadow(btn);
                    }));
                });
            }
            else if (typKarty == "dydelf")
            {
                if (btn.BackColor == Color.LightGray)
                {
                    btn.BackColor = Color.White;
                    btn.Text = typKarty;

                    odkryteDydelfy++;

                    if (odkryteDydelfy >= ustawienia.dydelf)
                    {
                        timer.Stop();
                        MessageBox.Show("Gratulacje! Odkryłeś wszystkie dydelfy. Wygrałeś!", "Wygrana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
            }
            else 
            {
                if (btn.BackColor == Color.LightGray)
                {
                    btn.BackColor = Color.White;
                    btn.Text = typKarty;
                }
                else
                {
                    btn.BackColor = Color.LightGray;
                    btn.Text = "";
                }
            }
        }

        private void UkryjKarteISasiadow(Button btn)
        {
            bool btnWasDydelf = (string)btn.Tag == "dydelf" && btn.BackColor == Color.White;
            UkryjIkoneKarty(btn);
            if (btnWasDydelf)
                odkryteDydelfy--;

            List<Button> sasiedzi = PobierzSasiadow(btn);

            foreach (Button sasiad in sasiedzi)
            {
                bool sasiadWasDydelf = (string)sasiad.Tag == "dydelf" && sasiad.BackColor == Color.White;
                UkryjIkoneKarty(sasiad);
                if (sasiadWasDydelf)
                    odkryteDydelfy--;
            }
        }


        private void UkryjIkoneKarty(Button btn)
        {
            btn.BackColor = Color.LightGray;
            btn.Text = "";
        }

        private List<Button> PobierzSasiadow(Button btn)
        {
            List<Button> sasiedzi = new List<Button>();
            int rozmiarPrzycisku = 200;
            int padding = 10;

            int btnLeft = btn.Left;
            int btnTop = btn.Top;

            foreach (Control control in this.Controls)
            {
                if (control is Button && control != btn)
                {
                    Button b = (Button)control;
                    int left = b.Left;
                    int top = b.Top;

                    if ((Math.Abs(btnLeft - left) == rozmiarPrzycisku + padding && btnTop == top) ||
                        (Math.Abs(btnTop - top) == rozmiarPrzycisku + padding && btnLeft == left))
                    {
                        sasiedzi.Add(b);
                    }
                }
            }

            return sasiedzi;
        }

        private List<string> przygotujKarty()
        {
            List<string> karty = new List<string>();

            for (int i = 0; i < ustawienia.krokodyl; i++)
                karty.Add("krokodyl");

            for (int i = 0; i < ustawienia.szop; i++)
                karty.Add("szop");

            for (int i = 0; i < ustawienia.dydelf; i++)
                karty.Add("dydelf");

            int liczbaPrzyciskow = ustawienia.x * ustawienia.y;
            while (karty.Count < liczbaPrzyciskow)
                karty.Add("pusta");

            Random rand = new Random();
            return karty.OrderBy(x => rand.Next()).ToList();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }
    }
}
