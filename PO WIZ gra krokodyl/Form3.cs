using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PO_WIZ_gra_krokodyl
{
    public partial class Form3 : Form
    {
        private System.Windows.Forms.Timer timer;
        private int czasPozostaly;

        private Settings ustawienia;

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
            czasPozostaly--;
            //lblCzas.Text = "Czas: " + czasPozostaly + "s";

            if (czasPozostaly <= 0)
            {
                timer.Stop();  
                MessageBox.Show("Przegrałeś, czas się skończył", "Koniec gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();  
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
                ustawienia.y * (buttonSize + padding)
            );

        }

        private async void ObracanieKarty(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string typKarty = (string)btn.Tag;

            if (typKarty == "szop")
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

                await Task.Delay(2000);

                UkryjKarteISasiadow(btn);
            }
            else if (typKarty == "krokodyl")
            {
                if (btn.BackColor == Color.LightGray)
                {
                    btn.BackColor = Color.White;
                    btn.Text = typKarty;
                }

                var tcs = new TaskCompletionSource<bool>();

                EventHandler clickHandler = null;
                clickHandler = (s, ev) =>
                {
                    if (btn.BackColor == Color.White)
                    {
                        btn.BackColor = Color.LightGray;
                        btn.Text = "";
                        tcs.TrySetResult(true);
                        btn.Click -= clickHandler;
                    }
                };

                btn.Click += clickHandler;


                await Task.Yield();


                var completedTask = await Task.WhenAny(tcs.Task, Task.Delay(5000));

                if (completedTask != tcs.Task)
                {
                    MessageBox.Show("Przegrałeś! Czas na odwrócenie karty minął.");
                    this.Close();
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
            UkryjIkoneKarty(btn);

            List<Button> sasiedzi = PobierzSasiadow(btn);
            foreach (Button sasiedniBtn in sasiedzi)
            {
                UkryjIkoneKarty(sasiedniBtn);
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
                    Button sasiedniBtn = (Button)control;
                    int sasiedniLeft = sasiedniBtn.Left;
                    int sasiedniTop = sasiedniBtn.Top;

                    if ((Math.Abs(btnLeft - sasiedniLeft) == rozmiarPrzycisku + padding && btnTop == sasiedniTop) ||
                        (Math.Abs(btnTop - sasiedniTop) == rozmiarPrzycisku + padding && btnLeft == sasiedniLeft))
                    {
                        sasiedzi.Add(sasiedniBtn);
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
            {
                karty.Add("pusta");  
            }

            Random rand = new Random();
            return karty.OrderBy(x => rand.Next()).ToList();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
