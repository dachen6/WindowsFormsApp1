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
    public partial class Form2 : Form
    {
        public string passing;
        public string Passing
        {
            get { return this.passing; }
        }
        public Form2()
        {
            InitializeComponent();
           
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "hh:mm:ss tt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            passing = dateTimePicker1.Text.ToString();
            this.DialogResult = DialogResult.OK;

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

    }
}
