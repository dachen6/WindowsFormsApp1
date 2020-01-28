using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        System.Timers.Timer time;
        string pass;
        string pass1;
        public Form1()
        {
            InitializeComponent();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            time = new System.Timers.Timer();
            time.Interval = 1000;
            time.Elapsed += Timer_Elapsed;

        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currtime = DateTime.Now;
            foreach (string s in listBox1.Items)
            {
                if (string.Equals(currtime.ToString(), pass.Substring(0, 8)))
                {

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
                pass1 = f2.passing.Substring(0, 4) + f2.passing.Substring(7, 8);
                listBox1.Items.Add(pass1);
                f2.DialogResult = DialogResult.None;
                box.Items.Add(pass1);
            }

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            ListBox box = new ListBox();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (f2.DialogResult == DialogResult.OK)
            {
                pass = f2.passing;
                int index = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(index);
                listBox1.Items.Insert(index,pass);

            }
        }
    }
}
