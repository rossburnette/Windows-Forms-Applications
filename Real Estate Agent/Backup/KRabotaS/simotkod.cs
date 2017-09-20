using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KRabotaS
{
    public partial class simotkod : Form
    {
        public simotkod()
        {
            InitializeComponent();
        }
        public string kod = "";
        private void simotkod_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "") { MessageBox.Show("Попълнете полето","Грешка"); }
            else
            {
                kod = textBox1.Text; //prisvoqvame na kod stoinosta ot textbox1
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
