using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace N1KRabota
{
    public partial class spravkaklient : Form
    {
        public string bul;
        public spravkaklient(string bulstat)
        {
            InitializeComponent();
            this.bul = bulstat;
        }

        private void spravkaklient_Load(object sender, EventArgs e)
        {
            FileStream file = new FileStream(@"klienti.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            string[] s = new string[4] ;
            while (sr.EndOfStream != true)
            {
                s = sr.ReadLine().Split('\t');
                if (s[1] == bul) {
                    label2.Text = s[0];
                    label4.Text = s[1];
                    label6.Text = s[2];
                    label8.Text = s[3];
                    break; }
            }

            sr.Close();
            file.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
