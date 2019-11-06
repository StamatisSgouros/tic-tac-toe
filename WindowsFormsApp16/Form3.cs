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
    public partial class Form3 : Form
    {
        int x=0;
        Random r;
        Class1 c1;
        public Form3(string username1,string username2,int px)
        {
            
            InitializeComponent();
            
            label5.Text = username1;//βλεπει αν θα ειναι 1 η 2 παιχτες και καθοριζει τη θα φαινεται στα label
            if (px == 2)
            {
                label1.Text = username1;
                label2.Text = username2;
                label6.Text = username2;
            }
            else
            {
                label1.Text = username1;
                label2.Text = "Computer";
                label6.Text = "Computer";
                x = 1;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            c1 = new Class1();
            r = new Random();
            Button[,] btarray = new Button [5, 5];//δημιουργεια πινακα κουμπιων
            var buttons = Controls.OfType<Button>().OrderBy(x => x.Top).ToList();//τοποθετηση κουμπιων σε πινακα απο πανω προς τα κατω οπως ειναι τοποθετημενα στην σελιδα σε μονοδιαστατο πινακα
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                   btarray[i, j] = buttons[i*5+j];//τοποθετηση κουμπιων απο τον μονοδιαστατο στον δισδιαστατο πινακα
                }
            }
            
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                   
                    btarray[i, j].Click += function;//καλεσμα της συναρτησης function καθε φορα που πατιεται καποιο κουμπι
                    
                }
            }



            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == j)
                    {
                        btarray[i, j].TextChanged += functionij;//καλεσμα συναρτησης funtionij για κυρια διαγωνιο
                    }
                    if (i+j==4)
                    {
                        btarray[i, j].TextChanged += function4;//καλεσμα συναρτησης funtionij για δευτερευουσα διαγωνιο διαγωνιο
                    }
                    if (j == 0)
                    {
                        btarray[i, j].TextChanged += functionj0;//καλεσμα συναρτησης funtion για της στηλες ξεκινοντας απο εδω*
                    }
                    if (j == 1)
                    {
                        btarray[i, j].TextChanged += functionj1;
                    }
                    if (j == 2)
                    {
                        btarray[i, j].TextChanged += functionj2;
                    }
                    if (j == 3)
                    {
                        btarray[i, j].TextChanged += functionj3;
                    }
                    if (j == 4)
                    {
                        btarray[i, j].TextChanged += functionj4;//μεχρι εδω*
                    }
                    if (i == 0)
                    {
                        btarray[i, j].TextChanged += functioni0;//καλεσμα συναρτησης funtion για της γραμμες ξεκινοντας απο εδω*
                    }
                    if (i == 1)
                    {
                        btarray[i, j].TextChanged += functioni1;
                    }
                    if (i == 2)
                    {
                        btarray[i, j].TextChanged += functioni2;
                    }
                    if (i == 3)
                    {
                        btarray[i, j].TextChanged += functioni3;
                    }
                    if (i == 4)
                    {
                        btarray[i, j].TextChanged += functioni4;//μεχρι εδω*
                    }
                   

                }
            }
            
            
            

        }
        int countfunc = 0;//μετρητης κλησης συναρτησης(για περιπτωση ισοπαλιας)
        private void function(object kati, EventArgs katiallo)
        {
            countfunc = countfunc + 1;
            int a;
            if ((label5.Visible == true) && (((Button)kati).Text != "X") && (((Button)kati).Text != "O"))//ελεγχος οτι το κουμπι δεν εχει πατηθει και ποιος παιχτης παιζει εκεινη τη στιγμη  
            {
                ((Button)kati).Text = "X";
                label5.Visible = false;
                label6.Visible = true;
                if (x==1)//ελεγχος αν ο παικτης παιζει μονος του με τον υπολογιστη 
                {
                    a = r.Next(25);//ευρεση τυχαιου αριθμου απο το 1-25
                    var buttoncomp = Controls.OfType<Button>().OrderBy(x => x.Top).ToList();//τοποθετηση κουμπιων σε πινακα απο πανω προς τα κατω οπως ειναι τοποθετημενα στην σελιδα σε μονοδιαστατο πινακα
                    if ((buttoncomp[a].Text!="X")&&(buttoncomp[a].Text != "O")&&(countfunc!=25))//ελεγχος το τυχαιο κουμπι δεν εχει πατηθει προηγουμενος και οτι η συναρτηση εχει κληθει λιγοτερο απο 25 φορες και κανει κλικ στο κουμπι
                    {
                        buttoncomp[a].PerformClick();
                    }
                    else if(countfunc!=25)//σε περπιτωση που το κουμπι εχει πατηθει βρησκω καινουριο τυχαιο αριθμο μεχρη να βρεθει κουμπι που να μην εχει πατηθει
                    {
                      
                        while ((buttoncomp[a].Text == "X")|| (buttoncomp[a].Text == "O"))
                        {
                            a = r.Next(25);
                        }
                        buttoncomp[a].PerformClick();
                    }
                    

                }

            }
            else if ((label6.Visible == true) && (((Button)kati).Text != "O") && (((Button)kati).Text != "X"))//ελεγχος οτι το κουμπι δεν εχει πατηθει και ποιος παιχτης παιζει εκεινη τη στιγμη  
            {
                ((Button)kati).Text = "O";
                label6.Visible = false;
                label5.Visible = true;


            }
           
            if (countfunc == 25) //ελαγχος ποσες φορες εχει καλεσθει η συναρτηση και περιπτωση ισοπαλιας
            {
                label7.Text = "Tie Game!!!";
                label7.Visible = true;

            }
            
        }
        int countxij = 0;
        int countoij = 0;
        private void functionij(object kati, EventArgs katiallo)//συναρτησεις για ελεγχους σε στηλες και γραμμες σε περιπτωσεις νικης απο εδω*
        {
            if (((Button)kati).Text == "X")
            {
                countxij = countxij + 1;
            }
            if (((Button)kati).Text == "O")
            {
                countoij = countoij + 1;
            }
            if (countoij == 5)
            {
                label7.Visible = true;
                label7.Text = label2.Text + "  Wins" + " !!!" ;
                
             
            }
            if (countxij == 5)
            {
                label7.Visible = true;
                label7.Text =  label1.Text + "  Wins"+ " !!!";
            }
        }
        int countx4 = 0;
        int counto4 = 0; 
        private void function4(object kati, EventArgs katiallo)
        {
            if (((Button)kati).Text == "X")
            {
                countx4 = countx4 + 1;
            }
            if (((Button)kati).Text == "O")
            {
                counto4 = counto4 + 1;
            }
            if (counto4 == 5)
            {
                label7.Visible = true;
                label7.Text = label2.Text + "  Wins" + " !!!";

            }
            if (countx4 == 5)
            {
                label7.Visible = true;
                label7.Text = label1.Text + "  Wins" + " !!!";
            }
        }
        int countxj0 = 0;
        int countoj0 = 0;
        private void functionj0(object kati, EventArgs katiallo)
        {
            if (((Button)kati).Text == "X")
            {
                countxj0 = countxj0 + 1;
            }
            if (((Button)kati).Text == "O")
            {
                countoj0 = countoj0 + 1;
            }
            if (countoj0 == 5)
            {
                label7.Visible = true;
                label7.Text = label2.Text + "  Wins" + " !!!";

            }
            if (countxj0 == 5)
            {
                label7.Visible = true;
                label7.Text = label1.Text + "  Wins" + " !!!";
            }
        }
        int countxj1 = 0;
        int countoj1 = 0;
        private void functionj1(object kati, EventArgs katiallo)
        {
            if (((Button)kati).Text == "X")
            {
                countxj1 = countxj1 + 1;
            }
            if (((Button)kati).Text == "O")
            {
                countoj1 = countoj1 + 1;
            }
            if (countoj1 == 5)
            {
                label7.Visible = true;
                label7.Text = label2.Text + "  Wins" + " !!!";

            }
            if (countxj1 == 5)
            {
                label7.Visible = true;
                label7.Text = label1.Text + "  Wins" + " !!!";
            }
        }
        int countxj2 = 0;
        int countoj2 = 0;
        private void functionj2(object kati, EventArgs katiallo)
        {
            if (((Button)kati).Text == "X")
            {
                countxj2 = countxj2 + 1;
            }
            if (((Button)kati).Text == "O")
            {
                countoj2 = countoj2 + 1;
            }
            if (countoj2 == 5)
            {
                label7.Visible = true;
                label7.Text = label2.Text + "  Wins" + " !!!";

            }
            if (countxj2 == 5)
            {
                label7.Visible = true;
                label7.Text = label1.Text + "  Wins" + " !!!";
            }
        }
        int countxj3 = 0;
        int countoj3 = 0;
        private void functionj3(object kati, EventArgs katiallo)
        {
            if (((Button)kati).Text == "X")
            {
                countxj3 = countxj3 + 1;
            }
            if (((Button)kati).Text == "O")
            {
                countoj3 = countoj3 + 1;
            }
            if (countoj3 == 5)
            {
                label7.Visible = true;
                label7.Text = label2.Text + "  Wins" + " !!!";

            }
            if (countxj3 == 5)
            {
                label7.Visible = true;
                label7.Text = label1.Text + "  Wins" + " !!!";
            }
        }
        int countxj4 = 0;
        int countoj4 = 0;
        private void functionj4(object kati, EventArgs katiallo)
        {
            if (((Button)kati).Text == "X")
            {
                countxj4 = countxj4 + 1;
            }
            if (((Button)kati).Text == "O")
            {
                countoj4 = countoj4 + 1;
            }
            if (countoj4 == 5)
            {
                label7.Visible = true;
                label7.Text = label2.Text + "  Wins" + " !!!";

            }
            if (countxj4 == 5)
            {
                label7.Visible = true;
                label7.Text = label1.Text + "  Wins" + " !!!";
            }
        }
        int countxi0 = 0;
        int countoi0 = 0;
        private void functioni0(object kati, EventArgs katiallo)
        {
            if (((Button)kati).Text == "X")
            {
                countxi0 = countxi0 + 1;
            }
            if (((Button)kati).Text == "O")
            {
                countoi0 = countoi0 + 1;
            }
            if (countoi0 == 5)
            {
                label7.Visible = true;
                label7.Text = label2.Text + "  Wins" + " !!!";

            }
            if (countxi0 == 5)
            {
                label7.Visible = true;
                label7.Text = label1.Text + "  Wins" + " !!!";
            }
        }
        int countxi1 = 0;
        int countoi1 = 0;
        private void functioni1(object kati, EventArgs katiallo)
        {
            if (((Button)kati).Text == "X")
            {
                countxi1 = countxi1 + 1;
            }
            if (((Button)kati).Text == "O")
            {
                countoi1 = countoi1 + 1;
            }
            if (countoi1 == 5)
            {
                label7.Visible = true;
                label7.Text = label2.Text + "  Wins" + " !!!";

            }
            if (countxi1 == 5)
            {
                label7.Visible = true;
                label7.Text = label1.Text + "  Wins" + " !!!";
            }
        }
        int countxi2 = 0;
        int countoi2 = 0;
        private void functioni2(object kati, EventArgs katiallo)
        {
            if (((Button)kati).Text == "X")
            {
                countxi2 = countxi2 + 1;
            }
            if (((Button)kati).Text == "O")
            {
                countoi2 = countoi2 + 1;
            }
            if (countoi2 == 5)
            {
                label7.Visible = true;
                label7.Text = label2.Text + "  Wins" + " !!!";

            }
            if (countxi2 == 5)
            {
                label7.Visible = true;
                label7.Text = label1.Text + "  Wins" + " !!!";
            }
        }
        int countxi3 = 0;
        int countoi3 = 0;
        private void functioni3(object kati, EventArgs katiallo)
        {
            if (((Button)kati).Text == "X")
            {
                countxi3 = countxi3 + 1;
            }
            if (((Button)kati).Text == "O")
            {
                countoi3 = countoi3 + 1;
            }
            if (countoi3 == 5)
            {
                label7.Visible = true;
                label7.Text = label2.Text + "  Wins" + " !!!";

            }
            if (countxi3 == 5)
            {
                label7.Visible = true;
                label7.Text = label1.Text + "  Wins" + " !!!";
            }
        }
        int countxi4 = 0;
        int countoi4 = 0;
        private void functioni4(object kati, EventArgs katiallo)
        {
            if (((Button)kati).Text == "X")
            {
                countxi4 = countxi4 + 1;
            }
            if (((Button)kati).Text == "O")
            {
                countoi4 = countoi4 + 1;
            }
            if (countoi4 == 5)
            {
                label7.Visible = true;
                label7.Text = label2.Text + "  Wins" + " !!!";

            }
            if (countxi4 == 5)
            {
                label7.Visible = true;
                label7.Text = label1.Text + "  Wins" + " !!!";
            }
        }                                                       //μεχρη εδω*
        

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//τιμερ οταν ο χρηστης παταει το exit
            c1.Exit();//καλεσμα κλασης 
        }

        private void label7_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void label7_VisibleChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;//απενεργοποιηση ολων το κουμπιων σε περιπτωση που καποιος χρηστης κερδησε η ηρθε σε ισοπαλια
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;
            button20.Enabled = false;
            button21.Enabled = false;
            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button25.Enabled = false;
            label9.Visible = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            c1.Restart();//καλεσμα κλασης για επανεκκινηση εφαρμογης
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Application.Exit();
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Application.Restart();
            timer2.Enabled = false;
        }

        private void resartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c1.restapp();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c1.exitapp();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic-tac-toe (also known as noughts and crosses or Xs and Os) is a paper-and-pencil game for two players, X and O, who take turns marking the spaces in a 5×5 grid. The player who succeeds in placing five of their marks in a horizontal, vertical, or diagonal row wins the game.");
        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for your support please send your Feedback on our e-mail:                                             example@hotmail.com");
        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.facebook.com");
        }

        private void instagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");
            
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Our e-mail: example@hotmail.com");
        }

        private void reportAProblemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you experience any inconveniences please send them on our e-mail:                                                 example@hotmail.com");
        }
    }
}
