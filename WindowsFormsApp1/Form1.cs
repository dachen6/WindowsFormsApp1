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
        bool showon;
        bool showoff;
        string line; 
        int j;
        string[] save = new string[10];
        int count = 1;
        bool stop = false;
        bool snooze;
        //open new form1 and set everything well
        public Form1()
        {
            InitializeComponent();         
            if(!File.Exists("timesave1.txt"))
            {
                StreamWriter qw = new StreamWriter("timesave1.txt");
                qw.Close();
            }
             j = 0;           
            StreamReader fi = new StreamReader("timesave1.txt");
            line = fi.ReadLine();
            while (line != null &&line != "")
            {
                save[j] = line;
                
                string[] timeDisplay = line.Split(' ', ':');
                line = timeDisplay[0] + ":" + timeDisplay[1] + " " + timeDisplay[3] + " " + timeDisplay[4];
                listBox1.Items.Add(line);
                j++;
                line = fi.ReadLine();
            }
            if (j == 10)
            {
                button1.Enabled = false;
            }
            fi.Close();
            button4.Enabled = false;
            button3.Enabled = false;
            showon = false;
            showoff = false;
            stop = false;
        }
        /// <summary>
        /// check event every second
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            time = new System.Timers.Timer();
            time.Interval = 1000;
            time.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            time.Start();
            
        }
        /// <summary>
        /// if all alarm are off show off if one is on show on if it went off show wheno off
        /// when one alarm when off, if we click snooze it will running again after 30 second 
        /// if we clcik stop, it will continue running
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            showon = false;
            foreach (string str in save)
            {
                if (str != null)
                {
                   
                    string am;
                    am = str;
                    string[] timeDisplay = str.Split(' ', ':');
                    if (timeDisplay[0].Length == 1) 
                    {
                        timeDisplay[0] = "0" + timeDisplay[0];
                    }
                    am = timeDisplay[0] + ":" + timeDisplay[1] + ":" + timeDisplay[2] + " " + timeDisplay[3];

                    if (str.Contains("on"))
                    {
                        showon = true;
                       
                    }                  
                    if (string.Equals(am, System.DateTime.Now.ToString("hh:mm:ss tt")))
                    {
                        showoff = true;
                        show.Invoke(new Action(delegate () { show.Text = "went off"; }));
                    }
                }
            }
            string test = show.Text;
            if (string.Equals(test, "went off") && stop)
            {
                showon = true;
                stop = false;
                showoff = false;
            }
            if ( snooze)
            {
                showoff = false;
                showon = true;
                if (count == 30)
                {
                    showon = false;
                    snooze = false;
                    showoff = true;
                    count = 1;
                }
                count++;
            }
            if (showoff)
            {
                show.Invoke(new Action(delegate () { show.Text = "went off"; }));
                button4.Invoke(new Action(delegate () { button4.Enabled = true; }));
                button3.Invoke(new Action(delegate () { button3.Enabled = true; }));
            }
            else if (showon)
            {
                show.Invoke(new Action(delegate () { show.Text = "running"; }));
                button4.Invoke(new Action(delegate () { button4.Enabled = false; }));
                button3.Invoke(new Action(delegate () { button3.Enabled = false; }));
            }
            else
            {
                show.Invoke(new Action(delegate () { show.Text = "off"; }));
            }
         

            
      
        }

        /// <summary>
        /// click add a new alarm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ListBox box = new ListBox();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if(f2.DialogResult == DialogResult.OK)
            {
                pass = f2.passing;
                save[j] = pass;               
                StreamWriter Fi = new StreamWriter("timesave1.txt");
                foreach (string s in save)
                {
                    Fi.WriteLine(s);
                }
                Fi.Close();
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



        /// <summary>
        /// edit a alarm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                StreamWriter Fi = new StreamWriter("timesave1.txt");
                Fi.Flush();
                foreach(string s in save)
                {
                    Fi.WriteLine(s);
                }
                Fi.Close();
                listBox1.Items.RemoveAt(index);
                string[] timeDisplay = pass.Split(' ', ':');
                pass = timeDisplay[0] + ":" + timeDisplay[1] + " " + timeDisplay[3] + " " + timeDisplay[4];
                listBox1.Items.Insert(index,pass);

            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// clci snooze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            stop = true;
            button3.Enabled = false;
            button4.Enabled = false;
        }
        /// <summary>
        /// click stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            snooze = true;
            button3.Enabled = false;
            button4.Enabled = false;
        }
    }
}
