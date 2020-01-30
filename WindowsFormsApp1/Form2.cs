﻿using System;
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
    public partial class Form2 : Form
    {
        Form1 f1 = new Form1();
        public string passing;
        public DateTime now ;
        bool ison;
        public string Passing
        {
            get { return this.passing; }
        }
        public Form2()
        {
            InitializeComponent();
            
            dateTimePicker1.Value = System.DateTime.Now;
        }
        public Form2(string s)
        {
           
            InitializeComponent();
            
            if (s.Contains("on"))
            {
                ison = true;
            }
            else
            {
                ison = false;
            }
            string[] timeDisplay = s.Split(' ', ':');
            s = timeDisplay[0] + ":" + timeDisplay[1] + ":" + timeDisplay[2] + " " + timeDisplay[3];
            DateTime dt = Convert.ToDateTime(s);
            
            dateTimePicker1.Value = dt;
        }



        private void button1_Click(object sender, EventArgs e)
        {

      

            passing = dateTimePicker1.Text;
            
            this.DialogResult = DialogResult.OK;


            /*if (ison)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }*/

            if (checkBox1.Checked)
            {
                passing += " on";
            }
            else
            {
                checkBox1.Checked = false;
                passing += " off";
            }
            
            this.Close();
            

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
