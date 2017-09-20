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
    public partial class sbroker : Form
    {
        public sbroker()
        {
            InitializeComponent();
        }
        public string egn = "";
        private void sbroker_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("Моля попълнете полето", "Грешка"); }
            else
            {
                egn = textBox1.Text; //prisvoqvame na egn stoinosta ot textbox1
                this.Close();
            }
        }
    }
}
