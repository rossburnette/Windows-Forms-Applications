using System;
using System.Collections;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KRabotaS
{
    public partial class EditBroker : Form
    {
        public EditBroker(string egn)
        {
            this.egn = egn;
            InitializeComponent();
        }
        public string egn ;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "") { MessageBox.Show("Моля попълнете всички полета !", "Грешка"); } //proverka za validnost na danni
            else
            {

                FileStream file = new FileStream("brokeri.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
                StreamReader sr = new StreamReader(file);//potok za 4etene

                int red = 0;
                string[] s2 = new string[7];
                ArrayList list = new ArrayList(); //array list v koito 6te zapazvame danite ot faila

                while (sr.EndOfStream != true) //obhojdame faila
                {
                    list.Add(sr.ReadLine());//pylnim lista
                }
                file.Position = 0; //vry6tame pointera 
                while (sr.EndOfStream != true) //obhojdame faila
                { 
                    s2 = sr.ReadLine().Split(); //4etem red po red i razdelqme na danite v masiva ot stringove
                    if (s2[3] == egn) { break; } //proverka 
                    red++;
                }

                list[red] = textBox1.Text  + '\t' + textBox3.Text + '\t' + textBox4.Text + '\t' + egn + '\t' + textBox5.Text + '\t' + textBox6.Text + '\t' + textBox7.Text; //promenqme vyprosniq red

                sr.Close();
                file.Close();

                File.Delete(@"brokeri.txt"); //triem faila
                file = new FileStream("brokeri.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file); //potok za pisane

                foreach (object i in list) //obhojdame lista arayq i zapisvame danite vyv noviq fail
                {
                    sw.WriteLine(i);
                }

                sw.Close();
                file.Close();
                this.Close();

            }
        }

        private void EditBroker_Load(object sender, EventArgs e)
        {

        }

        
    }
}
