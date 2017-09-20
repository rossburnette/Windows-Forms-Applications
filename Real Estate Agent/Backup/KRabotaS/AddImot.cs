using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KRabotaS
{
    public partial class AddImot : Form
    {
        public AddImot()
        {
            InitializeComponent();
        }
        Brokeri broker = new Brokeri();//deklarirame obekt ot tip Brokeri
        Imoti imot = new Imoti();//deklarirame obekt ot tip Imoti

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "") { MessageBox.Show("Моля попълнете всички полета !","Грешка"); } //proverka za validnost na danni
            else if (imot.ProverkaDaliImaTakyvImot(textBox2.Text)==true) {MessageBox.Show("Вече съществува имот с този код","Грешка");}//proverka dali ima takyv imot
            else if (broker.PreverkaDaliImaTakyvBroker(textBox7.Text)!=true) { MessageBox.Show("Няма такъв брокер", "Грешка"); } //proverka dali ima takyv broker
            else {
                FileStream file = new FileStream(@"imoti.txt", FileMode.Append, FileAccess.Write);//syzdavame failov potok
                StreamWriter sw = new StreamWriter(file); //syzdavame potok za pisane vyv file

                sw.WriteLine(textBox1.Text + '\t' + textBox2.Text + '\t' + textBox3.Text + '\t' + textBox4.Text + '\t' + textBox5.Text + '\t' + textBox6.Text + '\t' + textBox7.Text);//zapisva red vyv faila

                sw.Close();
                file.Close();//zatvarqme faila
                this.Close();//zatvarqme formata
            }
        }

        private void AddImot_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
