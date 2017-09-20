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
    public partial class tyrsiproizvoditel : Form
    {
        public tyrsiproizvoditel()
        {
            InitializeComponent();
        }
        public string prozivoditel = "";
        private void button1_Click(object sender, EventArgs e)
        {
            prozivoditel = textBox1.Text;
            this.Close();
        }

        private void tyrsiproizvoditel_Load(object sender, EventArgs e)
        {

        }
    }
}
