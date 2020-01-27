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
        string pass;
        public Form1()
        {
            InitializeComponent();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListBox box = new ListBox();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if(f2.DialogResult == DialogResult.OK)
            {
                pass = f2.passing;
                textBox1.Text += pass;
                textBox1.Text += "\r\n";
                f2.DialogResult = DialogResult.None;

                box.Items.Add(pass);

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
