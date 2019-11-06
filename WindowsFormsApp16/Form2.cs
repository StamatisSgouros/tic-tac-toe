using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class Form2 : Form
    {
        int px;
        Class2 c2;
        public Form2(int x)
        {
            InitializeComponent();
             px = x;
           if (px == 1)//label σε περιπτωση 1 η 2 παιχτων
            {
                label3.Visible = false;
                textBox2.Visible = false;
            }
             if (px == 2)
            {
                label3.Visible = true;
                textBox2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            c2 = new Class2();


        }
        string username1, username2;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form3 game = new Form3(username1, username2, px);//περασμα παραμετρων απο την μια κλαση στην αλλη

            game.Show();
            Opacity = 0;
            timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text=="")
            {
                username1 = "Player 1";
            }
            else
            {
                username1 = textBox1.Text;
            }
            if (textBox2.Text == "")
            {
                username2 = "Player 2";
            }
            else
            {
                username2 = textBox2.Text;
            }
            

            if ((px==2)&&(textBox1.Text == "")&& (textBox2.Text == "")||(px==1)&& (textBox1.Text == ""))

            {
                timer1.Enabled = true;
                c2.Wait();//καλεσμα κλασης
            }
            else
            {
                timer1.Enabled = true;
                
            }

        }
    }
}
