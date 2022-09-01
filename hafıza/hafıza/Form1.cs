using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace hafıza
{
    public partial class Form1 : Form
    {
        List<string> icon = new List<string>
        {
            "!",",","b","k","v","z","s","N",
            "!",",","b","k","v","z","s","N"
        };
        Random rnd = new Random();
        int rndsay;
        Button birincil, ikincil;
        int say = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            
            foreach (Button item in Controls)
            {
                item.ForeColor = item.BackColor;

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button btn ;
            foreach (Button item in Controls)
            {
                btn = item as Button;
                rndsay = rnd.Next(icon.Count);
                btn.Text = icon[rndsay];
                icon.RemoveAt(rndsay);
            }
            timer1.Start();
            timer1.Interval = 5000;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            timer2.Stop();
            birincil.Enabled = true;
            birincil.ForeColor = birincil.BackColor;
            ikincil.ForeColor = ikincil.BackColor;
            birincil = null;
            ikincil = null;


        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (birincil == null)
            {
                birincil = btn; 
                birincil.ForeColor = Color.Black;
                birincil.Enabled = false;
                return;
            }
            if (ikincil == null)
            {
                ikincil = btn;
                ikincil.ForeColor = Color.Black;


            }

            if (birincil.Text == ikincil.Text)
            {
                birincil.ForeColor = Color.Black;
                ikincil.ForeColor = Color.Black;
                birincil.Enabled = false;
                ikincil.Enabled = false;
                birincil = null;
                ikincil = null;
                say++;
                if (say==8)
                {
                    DialogResult dlg = new DialogResult();
                    dlg =MessageBox.Show("KAZANDINIZ...", "You win...", MessageBoxButtons.OK);

                    if (dlg == DialogResult.OK)
                    {
                        Application.Exit();

                    }
                    
                }


            }
            else
            {
                timer2.Start();
                timer2.Interval = 250;
            }

            

        }
    }
}
