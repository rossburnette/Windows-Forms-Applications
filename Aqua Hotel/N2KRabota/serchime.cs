using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace N2KRabota
{
    public partial class serchime : Form
    {
        public serchime()
        {
            InitializeComponent();
        }
        public string ime = "";
        private void serchime_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ime = textBox1.Text;
            this.Close();
        }
    }
}
