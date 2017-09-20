﻿using System;
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
    public partial class DelImot : Form
    {
        public DelImot()
        {
            InitializeComponent();
        }
        Imoti imot = new Imoti();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("Моля попълнете кода на имота", "Грешка"); } //proverka za validnost na dannite
            else if (imot.ProverkaDaliImaTakyvImot(textBox1.Text) != true) { MessageBox.Show("Няма такъв имот", "Грешка"); } //proverka za validnost na dannite
            else
            {

                FileStream file = new FileStream(@"imoti.txt", FileMode.OpenOrCreate, FileAccess.Read); //failov potok
                StreamReader sr = new StreamReader(file);//Potok za 4etene

                ArrayList list = new ArrayList(); //Arai list za zapazvane na danite ot faila
                int red = 0; //int promenliva 
                string[] s2 = new string[7]; //masiv s 7 elementa  

                while (sr.EndOfStream != true) //obhojdame faila i pylnim listAray
                {
                    list.Add(sr.ReadLine());
                }
                file.Position = 0; //vry6tame pointera na faila v na4aloto

                while (sr.EndOfStream != true) //obhojdame faila i stigame do reda s vyprosnite danni
                {
                    s2 = sr.ReadLine().Split('\t');
                    if (textBox1.Text == s2[1]) { break; }
                    else { red++; }

                }

                list.RemoveAt(red); //premahvame vyprosniq red

                sr.Close(); //zatvarqme 
                file.Close(); //zatvarqme faila

                File.Delete(@"imoti.txt"); //triem faila
                file = new FileStream(@"imoti.txt", FileMode.OpenOrCreate, FileAccess.Write); //syzdavame nov fail
                StreamWriter sw = new StreamWriter(file); //potok za pisane

                foreach (object i in list) //zapisvame seki red ot listaray bez iztritiq v noviq fail
                {
                    sw.WriteLine(i);
                }

                sw.Close();
                file.Close(); //zatvarqme faila

                this.Close();
            }
        }

        private void DelImot_Load(object sender, EventArgs e)
        {

        }
    }
}
