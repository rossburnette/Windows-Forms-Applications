using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KRabotaS
{
    public partial class EditImot : Form
    {
        public string kod = "";
        public EditImot(string kod)
        {
            InitializeComponent();
            this.kod = kod;
        }

        private void EditImot_Load(object sender, EventArgs e)
        {

        }
        //analogi4no ot formata EditImot.cs
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "") { MessageBox.Show("Моля попълнете всички полета !", "Грешка"); } //proverka za validnost na danni
            else {

                FileStream file = new FileStream("imoti.txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(file);

                int red = 0;
                string[] s2 = new string[7];
                ArrayList list = new ArrayList();

                while (sr.EndOfStream != true)
                {
                    list.Add(sr.ReadLine());
                }
                file.Position = 0;
                while (sr.EndOfStream != true)
                {
                    s2 = sr.ReadLine().Split();
                    if (s2[1] == kod) { break; }
                    red++;
                }

                list[red] = textBox1.Text + '\t' + kod + '\t' + textBox3.Text + '\t' + textBox4.Text + '\t' + textBox5.Text + '\t' + textBox6.Text + '\t' + textBox7.Text;

                sr.Close();
                file.Close();

                File.Delete(@"imoti.txt");
                file = new FileStream("imoti.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);

                foreach (object i in list)
                {
                    sw.WriteLine(i);
                }

                sw.Close();
                file.Close();
                this.Close();


            }
        }
    }
}
