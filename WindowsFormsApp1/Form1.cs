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
        string pass1;
        string[] save = new string[10];
        DateTime dt;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            using (StreamWriter w = File.AppendText("c:\\timesaver.txt"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time = new System.Timers.Timer();
            time.Interval = 1000;
            time.Elapsed += Timer_Elapsed;

        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           /* DateTime currtime = DateTime.Now;
            foreach (string s in listBox1.Items)
            {
                if (string.Equals(currtime.ToString(), pass.Substring(0, 8)))
                {

                }
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListBox box = new ListBox();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if(f2.DialogResult == DialogResult.OK)
            {
                pass = f2.passing;
                save[i] = pass;
                i++;
                StreamWriter File = new StreamWriter("timesave1.txt");
                File.Write("54");
                File.Close();
                string[] timeDisplay = pass.Split(' ',':');
                pass = timeDisplay[0] + ":" + timeDisplay[1] + ":" + timeDisplay[3] + " " + timeDisplay[4];
                listBox1.Items.Add(pass);
                f2.DialogResult = DialogResult.None;
                box.Items.Add(pass);
            }

        }




        private void exit_Click(object sender, EventArgs e)
        {
            ListBox box = new ListBox();
            
            int index = listBox1.SelectedIndex;
            string curItem = listBox1.SelectedItem.ToString();

            Form2 f2 = new Form2();
            f2.ShowDialog();
            
            if (f2.DialogResult == DialogResult.OK)
            {
                pass = f2.passing;
                
                listBox1.Items.RemoveAt(index);
                listBox1.Items.Insert(index,pass);

            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
