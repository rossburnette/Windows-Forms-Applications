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
    public partial class serchegn : Form
    {
        public serchegn()
        {
            InitializeComponent();
        }
        public string egn = "";
        private void serchegn_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.egn = textBox1.Text;
            this.Close();
        }
    }
}
