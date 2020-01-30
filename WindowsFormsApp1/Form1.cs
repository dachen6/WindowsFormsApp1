using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        System.Timers.Timer time;
        string pass;
        int FIVESEC = 1;
        string line;
        string linshow;
        DateTime dt;
        int i = 0;
        int j;
        string[] save = new string[10];
        public Form1()
        {
            InitializeComponent();         
             j = 0;
            int whattoshow = 1;
            StreamReader File = new StreamReader("timesave1.txt");
            line = File.ReadLine();
            while (line != null &&line != "")
            {
                save[j] = line;
                
                string[] timeDisplay = line.Split(' ', ':');
                line = timeDisplay[0] + ":" + timeDisplay[1] + " " + timeDisplay[3] + " " + timeDisplay[4];
                listBox1.Items.Add(line);
                j++;
                line = File.ReadLine();
            }
            if (j == 10)
            {
                button1.Enabled = false;
            }
            File.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time = new System.Timers.Timer();
            time.Interval = 1000;
            time.Elapsed += Timer_Elapsed;
            time.Start();
            
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            show.Invoke(new Action(delegate () { show.Text = "off"; }));
            foreach (string str in save)
            {
                if (str != null)
                {
                   
                    string am;
                    am = str;
                    string[] timeDisplay = str.Split(' ', ':');
                    am = timeDisplay[0] + ":" + timeDisplay[1] + ":" + timeDisplay[2] + " " + timeDisplay[3];

                    if (str.Contains("on"))
                    {
                        show.Invoke(new Action(delegate () { show.Text = "on"; }));
                    }                  
                    if (string.Equals(am, System.DateTime.Now.ToString("h:mm:ss tt")) || FIVESEC != 1)
                    {
                        button4.Invoke(new Action(delegate () { button4.Enabled = true; }));
                        button4.Enabled = true;
                        FIVESEC++;
                        show.Invoke(new Action(delegate () { show.Text = "wentoff"; }));
                        if(FIVESEC == 60)
                        {
                            FIVESEC = 1;
                            button4.Invoke(new Action(delegate () { button4.Enabled = false; }));
                        }
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListBox box = new ListBox();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if(f2.DialogResult == DialogResult.OK)
            {
                pass = f2.passing;
                save[j] = pass;               
                StreamWriter File = new StreamWriter("timesave1.txt");
                foreach (string s in save)
                {
                    File.WriteLine(s);
                }
                File.Close();
                string[] timeDisplay = pass.Split(' ',':');
                pass = timeDisplay[0] + ":" + timeDisplay[1] + ":" + timeDisplay[3] + " " + timeDisplay[4];
                listBox1.Items.Add(pass);
                f2.DialogResult = DialogResult.None;
                box.Items.Add(pass);
                j++;
            }
            if (j == 10)
            {
                button1.Enabled = false;
            }

        }




        private void exit_Click(object sender, EventArgs e)
        {
            ListBox box = new ListBox();
            
            int index = listBox1.SelectedIndex;
            
            Form2 f2 = new Form2(save[index]);
            f2.ShowDialog();
            
            if (f2.DialogResult == DialogResult.OK)
            {
                pass = f2.passing;
                save[index] = pass;
                StreamWriter File = new StreamWriter("timesave1.txt");
                File.Flush();
                foreach(string s in save)
                {
                    File.WriteLine(s);
                }
                File.Close();
                listBox1.Items.RemoveAt(index);
                string[] timeDisplay = pass.Split(' ', ':');
                pass = timeDisplay[0] + ":" + timeDisplay[1] + " " + timeDisplay[3] + " " + timeDisplay[4];
                listBox1.Items.Insert(index,pass);

            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FIVESEC = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
