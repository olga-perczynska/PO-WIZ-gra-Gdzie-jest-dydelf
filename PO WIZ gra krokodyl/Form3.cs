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

        private Settings ustawienia;
        public Form3(Settings settings)
        {
            InitializeComponent();
            ustawienia = settings;
            StworzPlansze();
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

        private void ObracanieKarty(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string typKarty = (string)btn.Tag;

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
