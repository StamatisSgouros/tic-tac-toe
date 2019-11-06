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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (radioButton1.Checked == true)//ελεγχος παιχτων 1  η  2 
            {
                x = 1;
            }
            else if(radioButton2.Checked == true)
            {
                x = 2;
            }
            Form2 players = new Form2(x);

            players.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
