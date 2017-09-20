using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace N2KRabota
{
    public partial class Form1 : Form
    {
        public Form1() //kontstruktor
        {
            InitializeComponent();
        }

        Staii staq = new Staii(); //deklarirame obekt ot tip Staii
        Klienti klient = new Klienti();  //deklarirame obekt ot tip Klienti

        private void LoadListKlientiPoStaq(string staq) //funkciq za pylnene na lista s klientite
        {
            ListKlienti.DataSource = "";//praznim lista

            FileStream file = new FileStream(@"klienti.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s = new string[6]; //masiv s 6 elemnta za zapisvane na danite ot redovete


            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                s = sr.ReadLine().Split('\t'); //4etem red po red i broim redovete
                if (s[5] == staq) { redove++; }
            }



            Klienti[] klienti = new Klienti[redove]; //masiv ot obekti Klienti

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {


                s = sr.ReadLine().Split('\t'); //4etem red po red
                if (s[5] == staq)
                {
                    klienti[i] = new Klienti //syzdavame  masiv ot obekti
                    {
                        Ime = s[0],
                        Familiq = s[1],
                        Egn = s[2],
                        Lichnakarta = s[3],
                        Datapostypvane = DateTime.Parse(s[4]),
                        Staq = int.Parse(s[5])
                    };
                    i++;
                }

                ListKlienti.DataSource = klienti; //dobavqme danite v datagrdi vew
            }
            sr.Close();
            file.Close(); //zatvarqme faila
        }

        private void LoadListKlientiPoEGN(string egn) //funkciq za pylnene na lista s klientite
        {
            ListKlienti.DataSource = "";//praznim lista

            FileStream file = new FileStream(@"klienti.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s = new string[6]; //masiv s 6 elemnta za zapisvane na danite ot redovete


            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                s = sr.ReadLine().Split('\t'); //4etem red po red i broim redovete
                if (s[2] == egn) { redove++; }
            }



            Klienti[] klienti = new Klienti[redove]; //masiv ot obekti Klienti

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {


                s = sr.ReadLine().Split('\t'); //4etem red po red
                if (s[2] == egn)
                {
                    klienti[i] = new Klienti //syzdavame  masiv ot obekti
                    {
                        Ime = s[0],
                        Familiq = s[1],
                        Egn = s[2],
                        Lichnakarta = s[3],
                        Datapostypvane = DateTime.Parse(s[4]),
                        Staq = int.Parse(s[5])
                    };
                    i++;
                }

                ListKlienti.DataSource = klienti; //dobavqme danite v datagrdi vew
            }
            sr.Close();
            file.Close(); //zatvarqme faila
        }

        private void LoadListKlientiPoIme(string ime) //funkciq za pylnene na lista s klientite
        {
            ListKlienti.DataSource = "";//praznim lista

            FileStream file = new FileStream(@"klienti.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s = new string[6]; //masiv s 6 elemnta za zapisvane na danite ot redovete


            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
              s =  sr.ReadLine().Split('\t'); //4etem red po red i broim redovete
              if (s[0] == ime) { redove++; }
            }

           

            Klienti[] klienti = new Klienti[redove]; //masiv ot obekti Klienti

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {


                s = sr.ReadLine().Split('\t'); //4etem red po red
                if (s[0] == ime)
                {
                    klienti[i] = new Klienti //syzdavame  masiv ot obekti
                    {
                        Ime = s[0],
                        Familiq = s[1],
                        Egn = s[2],
                        Lichnakarta = s[3],
                        Datapostypvane = DateTime.Parse(s[4]),
                        Staq = int.Parse(s[5])
                    };
                    i++;
                }

                ListKlienti.DataSource = klienti; //dobavqme danite v datagrdi vew
            }
            sr.Close();
            file.Close(); //zatvarqme faila
        }

        private void LoadListKlienti() //funkciq za pylnene na lista s klientite
        {
            ListKlienti.DataSource = "";//praznim lista

            FileStream file = new FileStream(@"klienti.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                sr.ReadLine(); //4etem red po red i broim redovete
                redove++;
            }

            string[] s = new string[6]; //masiv s 6 elemnta za zapisvane na danite ot redovete

            Klienti[] klienti = new Klienti[redove]; //masiv ot obekti Klienti

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
               

                s = sr.ReadLine().Split('\t'); //4etem red po red
                klienti[i] = new Klienti //syzdavame  masiv ot obekti
                {
                   Ime = s[0],
                   Familiq = s[1],
                   Egn = s[2],
                   Lichnakarta = s[3],
                   Datapostypvane = DateTime.Parse(s[4]),
                   Staq = int.Parse(s[5])
                };
                i++;
            }

            ListKlienti.DataSource = klienti; //dobavqme danite v datagrdi vew

            sr.Close();
            file.Close(); //zatvarqme faila
        }

        private void LoadListStaiiTaken() //funkciq koqto pokazva samo zaetite stai
        {
            ListStai.DataSource = "";//praznim lista

            FileStream file = new FileStream(@"staii.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s = new string[3]; //masiv s 3 elemnta za zapisvane na danite ot redovete

            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                s = sr.ReadLine().Split('\t');
                if (s[2] == "1") { redove++; }
            }


            Staii[] staii = new Staii[redove]; //masiv ot obekti Staii

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                tipstaq t = new tipstaq();

                s = sr.ReadLine().Split('\t'); //4etem red po red
                if (s[2] == "1")
                {
                    if (s[1].Length == 10) { t = tipstaq.Апартамент; }
                    else if (s[1].Length == 8) { t = tipstaq.Единична; }
                    else if (s[1].Length == 6) { t = tipstaq.Двойна; }

                    if (s[2] == "0") { s[2] = "Да"; }
                    else if (s[2] == "1") { s[2] = "Не"; }

                    staii[i] = new Staii //syzdavame  masiv ot obekti
                    {
                        Nomer = s[0],
                        Tip = t,
                        Svobodna = s[2]
                    };
                    i++;
                }

                ListStai.DataSource = staii; //dobavqme danite v datagrdi vew
            }
            sr.Close();
            file.Close(); //zatvarqme faila
        }

        private void LoadListStaiiFree() //funkciq koqto pokazva samo svobodnite stai
        {
            ListStai.DataSource = "";//praznim lista

            FileStream file = new FileStream(@"staii.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s = new string[3]; //masiv s 3 elemnta za zapisvane na danite ot redovete

            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                s = sr.ReadLine().Split('\t');
                if (s[2] == "0") { redove++; }
            }

           
            Staii[] staii = new Staii[redove]; //masiv ot obekti Staii

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                tipstaq t = new tipstaq();

                s = sr.ReadLine().Split('\t'); //4etem red po red
                if(s[2] == "0") {
                if (s[1].Length == 10) { t = tipstaq.Апартамент; }
                else if (s[1].Length == 8) { t = tipstaq.Единична; }
                else if (s[1].Length == 6) { t = tipstaq.Двойна; }

                if (s[2] == "0") { s[2] = "Да"; }
                else if (s[2] == "1") { s[2] = "Не"; }

                staii[i] = new Staii //syzdavame  masiv ot obekti
                {
                    Nomer = s[0],
                    Tip = t,
                    Svobodna = s[2]
                };
                i++;
            }

            ListStai.DataSource = staii; //dobavqme danite v datagrdi vew
            }
            sr.Close();
            file.Close(); //zatvarqme faila
        }


        private void LoadListStaii()
        {
            ListStai.DataSource = "";//praznim lista
           
            FileStream file = new FileStream(@"staii.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                sr.ReadLine();
                redove++;
            }

            string[] s = new string[3]; //masiv s 3 elemnta za zapisvane na danite ot redovete

            Staii[] staii = new Staii[redove]; //masiv ot obekti Staii

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                tipstaq t = new tipstaq();
             
                s = sr.ReadLine().Split('\t'); //4etem red po red
              
                if (s[1].Length == 10) { t = tipstaq.Апартамент; }
                else if (s[1].Length == 8) { t = tipstaq.Единична; }
                else if (s[1].Length == 6) { t = tipstaq.Двойна; }

                if (s[2] == "0") { s[2] = "Да"; }
                else if (s[2] == "1") { s[2] = "Не"; }
                
                staii[i] = new Staii //syzdavame  masiv ot obekti
                {
                    Nomer = s[0],
                    Tip = t,
                    Svobodna = s[2]
                };
                i++;
            }

            ListStai.DataSource = staii; //dobavqme danite v datagrdi vew

            sr.Close();
            file.Close(); //zatvarqme faila
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();//zatvarqme prilojenieto
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox6.Visible = false; //skrivame group-boxa
            groupBox5.Visible = false;//skrivame group-boxa
            ListStai.Visible = false; //skviravame lista s staite
            ListKlienti.Visible = true; //pokazvame lista s klientite
            vpisvane.Visible = false; // skrivame group-boxa 
            groupBox4.Enabled = false;//izklu4vame kontrolite v group-boxa
            LoadListKlienti(); //izvikvame funkciqta koqto pylni lista s klientite
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false; //skrivame group-boxa
            groupBox6.Visible = false; //skrivame group-boxa
            ListStai.Visible = false; //skviravame lista s staite
            ListKlienti.Visible = true; //pokazvame lista s klientite
            vpisvane.Visible = false; // skrivame group-boxa 
            groupBox3.Enabled = true; //vklu4vame kontrolite v group-boxa
            groupBox4.Enabled = false; //izklu4vame kontrolite v group-boxa
            LoadListKlienti(); //funkciq za pylnene na lista s klientite
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false; //skrivame group-boxa
            groupBox5.Visible = false;//skrivame group-boxa
            ListStai.Visible = false; //skviravame lista s staite
            ListKlienti.Visible = false; //skrivame lista s klientite
            vpisvane.Visible = true; // pokazvame group-boxa 
            groupBox3.Enabled = false; //izklu4vame kontrolite v group-boxa
            groupBox4.Enabled = false; //izklu4vame kontrolite v group-boxa
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false; //skrivame group-boxa
            groupBox5.Visible = true;//pokazvame group-boxa
            ListStai.Visible = false; //skviravame lista s staite
            ListKlienti.Visible = false; //skrivame lista s klientite
            vpisvane.Visible = false; // skrivame group-boxa 
            groupBox3.Enabled = false; //izklu4vame kontrolite v group-boxa
            groupBox4.Enabled = false; //izklu4vame kontrolite v group-boxa
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false; //skrivame group-boxa
            groupBox5.Visible = false;//skrivame group-boxa
            ListStai.Visible = true; //pokazvame lista s staite
            ListKlienti.Visible = false; //skrivame lista s klientite
            vpisvane.Visible = false; // skrivame group-boxa 
            groupBox3.Enabled = false; //izklu4vame kontrolite v group-boxa
            groupBox4.Enabled = true; //vklu4vame kontrolite v group-boxa

            LoadListStaii();//izvikvame funkciq koqto pylni lsita sys stai
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = true; //pokazvame group-boxa
            groupBox7.Visible = false; //skrivame group-boxa
            groupBox5.Visible = false;//skrivame group-boxa
            ListStai.Visible = false; //skviravame lista s staite
            ListKlienti.Visible = false; //skrivame lista s klientite
            vpisvane.Visible = false; // skrivame group-boxa 
            groupBox3.Enabled = false; //izklu4vame kontrolite v group-boxa
            groupBox4.Enabled = false; //izklu4vame kontrolite v group-boxa
        }

        private void button7_Click(object sender, EventArgs e)
        {
            serchime tyrsi1 = new serchime();
            tyrsi1.ShowDialog();
            LoadListKlientiPoIme(tyrsi1.ime);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length <= 0) { MessageBox.Show("Моля попълнете полето", "Грешка"); } //proverka za korektnost na danite
            else if (int.Parse(textBox7.Text) < 0 || int.Parse(textBox7.Text) > 10) { MessageBox.Show("Няма такава стая","Грешка"); } //proverka dali ima takava staq
            else { groupBox7.Visible = true; }
        }

        private void button13_Click(object sender, EventArgs e) //buton za nastanqvane na klienti
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "") { MessageBox.Show("Моля попълнете всички полета", "Грешка"); } //proverka za validnost na danii
            else if (int.Parse(textBox6.Text) < 1 || int.Parse(textBox6.Text) > 10) { MessageBox.Show("Няма такава стая","Грешка"); } //proverka za validnost na staq
            else if (klient.IsKlientAlready(textBox3.Text)) { MessageBox.Show("Вече съществува клиент с това ЕГН","Грешка"); }//proverka dali ve4e ima takyv klient
            else if (staq.IsRoomFree(textBox6.Text) == false) { MessageBox.Show("Стаята е заета", "Грешка"); } //proverka dali staqta e svobodna
            else //ako vsi4ko e nared
            {
                klient.AddKlient(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text, textBox6.Text); //dobavqme klienta
                MessageBox.Show("Клиента беше настанен в стая " + textBox6.Text, "Настаняване"); //izvejdame MSG 4e vsi4ko e nared
                textBox1.Text = ""; //nulirame poletata
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LoadListStaii();//izvikvame funkciq koqto pylni lsita sys stai
        }

        private void button11_Click(object sender, EventArgs e)
        {
            LoadListStaiiFree();//funkciq pokazva6ta samo svobodnite stai
        }

        private void button12_Click(object sender, EventArgs e)
        {
            LoadListStaiiTaken();//funkciq pokazva6ta samo zaetite stai
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length != 0)
            {

                FileStream file = new FileStream("staii.txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(file);

                int red = 0;
                string[] s2 = new string[3];
                ArrayList list = new ArrayList();

                while (sr.EndOfStream != true)
                {
                    list.Add(sr.ReadLine());
                }
                file.Position = 0;
                while (sr.EndOfStream != true)
                {
                    s2 = sr.ReadLine().Split();
                    if (s2[0] == textBox7.Text) { break; }
                    red++;
                }

                list[red] = s2[0] + '\t' + comboBox1.Text + '\t' + s2[2];

                sr.Close();
                file.Close();

                File.Delete(@"staii.txt");
                file = new FileStream("staii.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);

                foreach (object i in list)
                {
                    sw.WriteLine(i);
                }
                sw.Close();
                file.Close();
                MessageBox.Show("Данните за стаята бяха променени", "Промяна на стая");
                textBox7.Text = "";
                groupBox7.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            serchegn tyrsi2 = new serchegn();
            tyrsi2.ShowDialog();//pokazvame dialoga
            LoadListKlientiPoEGN(tyrsi2.egn);//izvikvame funkciq
        }

        private void button9_Click(object sender, EventArgs e)
        {
            serchstaq tyrsi3 = new serchstaq(); //nov obekt
            tyrsi3.ShowDialog(); //pokazvame dialoga
            LoadListKlientiPoStaq(tyrsi3.staq); //izvikvame funkciq
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length <= 0) { MessageBox.Show("Моля попълнете полето", "Грешка"); } //proverka za validnost na dannite
            else if (klient.IsKlientAlready(textBox5.Text) != true) { MessageBox.Show("Няма клиент с това ЕГН", "Грешка"); } //proverka dali ima takyv klient
            else { 
                klient.OtpisvaneNaKlient(textBox5.Text); //izvikvame funkciqta za otpisvane
                MessageBox.Show("Клиента беше отписан","Отписване"); //izvikvame msg
                textBox5.Text = ""; //izprazvame poleto
            
            }
        }
    }
}
