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
    public partial class simotcena : Form
    {
        public simotcena()
        {
            InitializeComponent();
        }
        public string cena = "";
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "") { MessageBox.Show("Попълнете полето", "Грешка"); }
            else
            {
                cena = textBox1.Text; //prisvoqvame na cena stoinosta ot textbox1
                this.Close();
            }
        }

        private void simotcena_Load(object sender, EventArgs e)
        {

        }
    }
}
