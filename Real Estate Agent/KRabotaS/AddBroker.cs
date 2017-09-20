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
    public partial class AddBroker : Form
    {
        public AddBroker()
        {
            InitializeComponent();
        }
        Brokeri broker = new Brokeri(); //obekt to tip Brokeri

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "") { MessageBox.Show("Моля попълнете всички полета !","Грешка"); } //proverka za validnost na danni
            else if (broker.PreverkaDaliImaTakyvBroker(textBox7.Text) == true) { MessageBox.Show("Вече има брокер с това ЕГН", "Грешка"); } //proverka dali ima takyv broker
            else
            {
                FileStream file = new FileStream(@"brokeri.txt", FileMode.Append, FileAccess.Write);//syzdavame failov potok
                StreamWriter sw = new StreamWriter(file); //syzdavame potok za pisane vyv file

                sw.WriteLine(textBox1.Text + '\t' + textBox2.Text + '\t' + textBox3.Text + '\t' + textBox4.Text + '\t' + textBox5.Text + '\t' + textBox6.Text + '\t' + textBox7.Text);//zapisva red vyv faila

                sw.Close();
                file.Close();//zatvarqme faila
                this.Close();//zatvarqme formata
            }
        }

        private void AddBroker_Load(object sender, EventArgs e)
        {

        }
    }
}
