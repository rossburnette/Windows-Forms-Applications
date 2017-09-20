using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace N1KRabota
{
    public partial class tyrsiime : Form
    {
        public tyrsiime()
        {
            InitializeComponent();
        }
        public string ime = "";
        private void button1_Click(object sender, EventArgs e)
        {
            ime = textBox1.Text;
            this.Close();
        }

        private void tyrsiime_Load(object sender, EventArgs e)
        {

        }
    }
}
