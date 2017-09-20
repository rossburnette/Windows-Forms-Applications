using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace N1KRabota
{
    public partial class Form1 : Form
    {
        public Form1() //konstruktor
        {
            InitializeComponent();
        }

        Stoki stoka = new Stoki(); //obekt ot tip stoki
        Klienti klient = new Klienti(); //obekt ot tip klienti

        public void LoadListKlienti() //funkciq za pylnene na ListStoki
        {
            ListKlienti.DataSource = ""; //izprazvame lista

            FileStream file = new FileStream(@"klienti.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                sr.ReadLine(); //4etem
                redove++;
            }

            string[] s = new string[4]; //masiv s 6 elemnta za zapisvane na danite ot redovete

            Klienti[] klienti = new Klienti[redove]; //masiv ot obekti Klienti

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s = sr.ReadLine().Split('\t');
                klienti[i] = new Klienti //syzdavame obekt ot tip Klienti
                {
                    Ime = s[0],
                    Bulstat = s[1],
                    Dannomer = s[2],
                    Adres = s[3]

                };
                i++;
            }
            ListKlienti.DataSource = klienti; //dobavqme danite v datagrdi vew

            sr.Close();
            file.Close(); //zatvarqme faila

        }

        public void LoadListStokiProizvoditel(string proizvoditel) //funkciq za izvejdane na stoki po kriterii porizvoditel
        {
            ListStoki.DataSource = ""; //izprazvame lista

            FileStream file = new FileStream(@"stoki.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s = new string[6]; //masiv s 6 elemnta za zapisvane na danite ot redovete

            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                s = sr.ReadLine().Split('\t'); //deli reda na 4asti
                if (s[4] == proizvoditel)
                {
                    redove++;
                }
            }

            Stoki[] stoki = new Stoki[redove]; //masiv ot obekti Stoki

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s = sr.ReadLine().Split('\t');
                if (s[4] == proizvoditel)
                {
                    stoki[i] = new Stoki //syzdavame obekt ot tip Stoki
                    {
                        Nomer = s[0],
                        Ime = s[1],
                        Kolichestvo = double.Parse(s[2]),
                        Edcena = double.Parse(s[3]),
                        Proizvoditel = s[4],
                        Dostavchik = s[5]

                    };
                    i++;
                }

                ListStoki.DataSource = stoki; //dobavqme danite v datagrdi vew
            }
            sr.Close();
            file.Close(); //zatvarqme faila
        }

        public void LoadListStokiDostavchik(string dostavchik) //funkciq za izvejdane na stoki po kriterii dostav4ik
        {
            ListStoki.DataSource = ""; //izprazvame lista

            FileStream file = new FileStream(@"stoki.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s = new string[6]; //masiv s 6 elemnta za zapisvane na danite ot redovete

            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                s = sr.ReadLine().Split('\t');
                if (s[5] == dostavchik)
                {
                    redove++;
                }
            }

            Stoki[] stoki = new Stoki[redove]; //masiv ot obekti Stoki

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s = sr.ReadLine().Split('\t');
                if (s[5] == dostavchik)
                {
                    stoki[i] = new Stoki //syzdavame obekt ot tip Stoki
                    {
                        Nomer = s[0],
                        Ime = s[1],
                        Kolichestvo = double.Parse(s[2]),
                        Edcena = double.Parse(s[3]),
                        Proizvoditel = s[4],
                        Dostavchik = s[5]

                    };
                    i++;
                }

                ListStoki.DataSource = stoki; //dobavqme danite v datagrdi vew
            }
            sr.Close();
            file.Close(); //zatvarqme faila
        }

        public void LoadListStokiIme(string ime)  //funkciq za izvejdane na stoki po kriterii ime
        {
            ListStoki.DataSource = ""; //izprazvame lista

            FileStream file = new FileStream(@"stoki.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s = new string[6]; //masiv s 6 elemnta za zapisvane na danite ot redovete

            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                s = sr.ReadLine().Split('\t');
                if (s[1] == ime)
                {
                    redove++;
                }
            }

            Stoki[] stoki = new Stoki[redove]; //masiv ot obekti Stoki

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s = sr.ReadLine().Split('\t');
                if (s[1] == ime)
                {
                    stoki[i] = new Stoki //syzdavame obekt ot tip Stoki
                    {
                        Nomer = s[0],
                        Ime = s[1],
                        Kolichestvo = double.Parse(s[2]),
                        Edcena = double.Parse(s[3]),
                        Proizvoditel = s[4],
                        Dostavchik = s[5]

                    };
                    i++;
                }
            
            ListStoki.DataSource = stoki; //dobavqme danite v datagrdi vew
                }
            sr.Close();
            file.Close(); //zatvarqme faila
        }

        public void LoadListStoki() //funkciq za pylnene na ListStoki
        {
            ListStoki.DataSource = "";

            FileStream file = new FileStream(@"stoki.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                sr.ReadLine();
                redove++;
            }

            string[] s = new string[6]; //masiv s 6 elemnta za zapisvane na danite ot redovete

            Stoki[] stoki = new Stoki[redove]; //masiv ot obekti Stoki

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s = sr.ReadLine().Split('\t');
                 stoki[i] = new Stoki //syzdavame obekt ot tip Stoki
                {
                    Nomer = s[0],
                    Ime = s[1],
                    Kolichestvo = double.Parse(s[2]),
                    Edcena = double.Parse(s[3]),
                    Proizvoditel = s[4],
                    Dostavchik = s[5]                   
                    
                };
                i++;
            }
            ListStoki.DataSource = stoki; //dobavqme danite v datagrdi vew

            sr.Close();
            file.Close(); //zatvarqme faila

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button10.Enabled = false; //izklu4vame butona
            ListKlienti.Visible = false; //skrivame lista s klientite
            EditKlient.Visible = false; //skrivame group-boxa
            DelKlient.Visible = false; // skrivame group-boxa
            AddKlient.Visible = false; // skrivame group-boxa
            editstoka.Visible = false; // skrivame group-boxa
            ListStoki.Visible = true; // pokazvam lista sys stokite
            addstoka.Visible = false; // skrivame group-boxa
            delstoka.Visible = false; // slrivame group-boxa
            LoadListStoki();//izvikvame funkciqta za zarejdane na spisyka
        }

        private void izhod_Click(object sender, EventArgs e) //pri natiskane na butona Izhod
        {
            this.Close();//zatvarq prozoreca
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button10.Enabled = false; //izklu4vame butona
            ListKlienti.Visible = false; //skrivame lista s klientite
            EditKlient.Visible = false; //skrivame group-boxa
            DelKlient.Visible = false; // skrivame group-boxa
            AddKlient.Visible = false; // skrivame group-boxa
            delstoka.Visible = false; // slrivame group-boxa
            editstoka.Visible = false; // skrivame group-boxa
            addstoka.Visible = false; // skrivame group-boxa

            tyrsiime serch1 = new tyrsiime(); //nov obekt
            serch1.ShowDialog(); //pokazvame prozoreca
            LoadListStokiIme(serch1.ime); //izvikvame funkciqta s parametyr ot predniq prozorec

        }

        private void button12_Click(object sender, EventArgs e)
        {
            button10.Enabled = false; //izklu4vame butona
            ListKlienti.Visible = false; //skrivame lista s klientite
            EditKlient.Visible = false; //skrivame group-boxa
            DelKlient.Visible = false; // skrivame group-boxa
            AddKlient.Visible = false; // skrivame group-boxa
            editstoka.Visible = false; // skrivame group-boxa
            delstoka.Visible = false; // slrivame group-boxa
            addstoka.Visible = false; // skrivame group-boxa

            tyrsiproizvoditel serch2 = new tyrsiproizvoditel(); //nov obekt
            serch2.ShowDialog(); //pokazvame prozoreca
            LoadListStokiProizvoditel(serch2.prozivoditel); ///izvikvame funckiqta s parametyr ot predniq prozorec
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button10.Enabled = false; //izklu4vame butona
            ListKlienti.Visible = false; //skrivame lista s klientite
            EditKlient.Visible = false; //skrivame group-boxa
            DelKlient.Visible = false; // skrivame group-boxa
            AddKlient.Visible = false; // skrivame group-boxa
            editstoka.Visible = false; // skrivame group-boxa
            delstoka.Visible = false; // slrivame group-boxa
            addstoka.Visible = false; // skrivame group-boxa

            tyrsidostavchik serch3 = new tyrsidostavchik(); //nov obekt
            serch3.ShowDialog(); //pokazvame prozoreca
            LoadListStokiDostavchik(serch3.dostavchik); //izvikvame funkciqta
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button10.Enabled = false; //izklu4vame butona
            ListKlienti.Visible = false; //skrivame lista s klientite
            EditKlient.Visible = false; //skrivame group-boxa
            DelKlient.Visible = false; // skrivame group-boxa
            AddKlient.Visible = false; // skrivame group-boxa
            editstoka.Visible = false; // skrivame group-boxa
            delstoka.Visible = false; // slrivame group-boxa
            addstoka.Visible = false; // skrivame group-boxa


            if (ListStoki.SelectedCells.Count <= 0) { MessageBox.Show("Не сте избрал клиент"); } //izvejda msg
            else
            {
                string nomer = ListStoki.Rows[ListStoki.SelectedCells[0].RowIndex].Cells[0].Value.ToString(); //vzemema nomera na stokata po red
                prodajba prodai = new prodajba(nomer); //deklarirame nov obekt
                prodai.ShowDialog(); //pokazvame prozoreca

                LoadListStoki(); //refreshvame lista
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button10.Enabled = false; //izklu4vame butona
            actions.Enabled = true; //vklu4vame group-boxa
            serch.Enabled = true; //vklu4vame group-boxa
            ListKlienti.Visible = false; //skrivame lista s klientite
            EditKlient.Visible = false; //skrivame group-boxa
            DelKlient.Visible = false; // skrivame group-boxa
            AddKlient.Visible = false; // skrivame group-boxa
            ListStoki.Visible = true; // pokazvame lista sys stokite
            editstoka.Visible = false; // skrivame group-boxa
            delstoka.Visible = false; // slrivame group-boxa
            addstoka.Visible = false; // skrivame group-boxa
            LoadListStoki();//izvikvame funkciqta za zarejdane na spisyka
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button10.Enabled = false; //izklu4vame butona
            actions.Enabled = false; //izklu4vame group-boxa
            serch.Enabled = false; //izklu4vame groupboxa
            ListKlienti.Visible = false; //skrivame lista s klientite
            EditKlient.Visible = false; //skrivame group-boxa
            DelKlient.Visible = false; // skrivame group-boxa
            AddKlient.Visible = false; // skrivame group-boxa
            ListStoki.Visible = false; //skrivame lista sys stokite
            editstoka.Visible = false; // skrivame group-boxa
            delstoka.Visible = false; // slrivame group-boxa
            addstoka.Visible = true; // pokazvame group-boxa
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button10.Enabled = false; //izklu4vame butona
            actions.Enabled = false; //izklu4vame group-boxa
            serch.Enabled = false; //izklu4vame groupboxa
            ListKlienti.Visible = false; //skrivame lista s klientite
            EditKlient.Visible = false; //skrivame group-boxa
            DelKlient.Visible = false; // skrivame group-boxa
            AddKlient.Visible = false; // skrivame group-boxa
            ListStoki.Visible = false; //skrivame lista sys stokite
            editstoka.Visible = false; // skrivame group-boxa
            delstoka.Visible = true; // pokazvame group-boxa
            addstoka.Visible = false; // skrivame group-boxa
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button10.Enabled = false; //izklu4vame butona
            actions.Enabled = false; //izklu4vame group-boxa
            serch.Enabled = false; //izklu4vame groupboxa
            ListKlienti.Visible = false; //skrivame lista s klientite
            EditKlient.Visible = false; //skrivame group-boxa
            DelKlient.Visible = false; // skrivame group-boxa
            AddKlient.Visible = false; // skrivame group-boxa
            ListStoki.Visible = false; //skrivame lista sys stokite
            editstoka.Visible = true; // pokazvame group-boxa
            delstoka.Visible = false; // slrivame group-boxa
            addstoka.Visible = false; // skrivame group-boxa
            groupBox1.Visible = false; //skrivame poleto
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button10.Enabled = true; //vklu4vame butona
            actions.Enabled = false; //izklu4vame group-boxa
            serch.Enabled = false; //izklu4vame groupboxa
            ListKlienti.Visible = true; //pokazvame lista s klientite
            EditKlient.Visible = false; //skrivame group-boxa
            DelKlient.Visible = false; // skrivame group-boxa
            AddKlient.Visible = false; // skrivame group-boxa
            ListStoki.Visible = false; //skrivame lista sys stokite
            editstoka.Visible = false; // skrivame group-boxa
            delstoka.Visible = false; // slrivame group-boxa
            addstoka.Visible = false; // skrivame group-boxa
            LoadListKlienti();//izvikvame funkciqta za pylnene na lista
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button10.Enabled = false; //izklu4vame butona
            actions.Enabled = false; //izklu4vame group-boxa
            serch.Enabled = false; //izklu4vame groupboxa
            ListKlienti.Visible = false; //skrivame lista s klientite
            EditKlient.Visible = false; //skrivame group-boxa
            DelKlient.Visible = false; // skrivame group-boxa
            AddKlient.Visible = true; // pokazvame group-boxa
            ListStoki.Visible = false; //skrivame lista sys stokite
            editstoka.Visible = false; // skrivame group-boxa
            delstoka.Visible = false; // slrivame group-boxa
            addstoka.Visible = false; // skrivame group-boxa
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button10.Enabled = false; //izklu4vame butona
            actions.Enabled = false; //izklu4vame group-boxa
            serch.Enabled = false; //izklu4vame groupboxa
            ListKlienti.Visible = false; //skrivame lista s klientite
            EditKlient.Visible = false; //skrivame group-boxa
            DelKlient.Visible = true; // pokazvame group-boxa
            AddKlient.Visible = false; // skrivame group-boxa
            ListStoki.Visible = false; //skrivame lista sys stokite
            editstoka.Visible = false; // skrivame group-boxa
            delstoka.Visible = false; // slrivame group-boxa
            addstoka.Visible = false; // skrivame group-boxa
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button10.Enabled = false; //izklu4vame butona
            actions.Enabled = false; //izklu4vame group-boxa
            serch.Enabled = false; //izklu4vame groupboxa
            ListKlienti.Visible = false; //skrivame lista s klientite
            EditKlient.Visible = true; //pokazvame group-boxa
            DelKlient.Visible = false; // skrivame group-boxa
            AddKlient.Visible = false; // skrivame group-boxa
            ListStoki.Visible = false; //skrivame lista sys stokite
            editstoka.Visible = false; // skrivame group-boxa
            delstoka.Visible = false; // slrivame group-boxa
            addstoka.Visible = false; // skrivame group-boxa
            groupBox4.Visible = false;//skrivame poleto
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (ListKlienti.SelectedCells.Count <= 0) { MessageBox.Show("Не сте избрал клиент"); } //proverka za validnost na dannite
            else
            {
                string bulstat = ListKlienti.Rows[ListKlienti.SelectedCells[0].RowIndex].Cells[1].Value.ToString(); //vzemame bulstata ot reda na selektnatiq klient
                spravkaklient spravka = new spravkaklient(bulstat); //nov obekt 
                spravka.ShowDialog(); //pokazvame prozoreca

                actions.Enabled = false; //izklu4vame group-boxa
                serch.Enabled = false; //izklu4vame groupboxa
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "") { MessageBox.Show("Моля попълнете всички полета", "Грешка"); } //proverka za validnost

            else
            {
                stoka.DobavqneNaStoka(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);//izvikvane na funkciqta
                MessageBox.Show("Стоката беше добавена", "Добавяне на стока");//msg
                //izprazvame poletata
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "") { MessageBox.Show("Моля попълнете полето", "Грешка"); }//proverka za validnost na dannite
            else
            {
                stoka.PremahvaneNaStoka(textBox7.Text);//izvikvane na funkciqta
                MessageBox.Show("Стоката беше изтрита", "Изтриване на стока");//msg
                //izprazvame poleto
                textBox7.Text = "";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "") { MessageBox.Show("Моля попълнете всички полета", "Грешка"); } //proverka za validnost na dannite
            else
            {

                FileStream file = new FileStream(@"stoki.txt", FileMode.OpenOrCreate, FileAccess.Read); //failov potok
                StreamReader sr = new StreamReader(file); //potok za 4etene

                int red = 0;
                string[] s2 = new string[6];
                ArrayList list = new ArrayList();

                while (sr.EndOfStream != true)
                {
                    list.Add(sr.ReadLine());
                }
                file.Position = 0;
                while (sr.EndOfStream != true)
                {
                    s2 = sr.ReadLine().Split();
                    if (s2[0] == textBox8.Text) { break; }
                    red++;
                }

                list[red] = textBox8.Text + '\t' + textBox9.Text + '\t' + textBox10.Text + '\t' + textBox11.Text + '\t' + textBox12.Text + '\t' + textBox13.Text;

                sr.Close();
                file.Close();

                File.Delete(@"stoki.txt");
                file = new FileStream(@"stoki.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);

                foreach (object i in list)
                {
                    sw.WriteLine(i);
                }

                sw.Close();
                file.Close();
                MessageBox.Show("Данните за стоката бяха променени", "Промяна на данни");
                textBox8.Text = "";
                groupBox1.Visible = false;
                //izprazvame poletata
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox14.Text == "" || textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "") { MessageBox.Show("Моля попълнете всички полета", "Грешка"); } //proverka za validnost na danni
            else
            {
                klient.DobavqneNaKlient(textBox14.Text, textBox15.Text, textBox16.Text, textBox17.Text);//izvikvame funkciqta za dobavqne na klient
                MessageBox.Show("Клиента беше добавен", "Добавяне на клиент");//msg
                //izprazvame poletata
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox24.Text == "") { MessageBox.Show("Моля попълнете полето","Грешка"); } //proverka za validnost na dannite
            else if (klient.ProverkaZaSyshtestvuvashtKlient(textBox24.Text) != true) { MessageBox.Show("Няма клиент с този булстат", "Грешка"); } //proverka dali ima takyv klient
            else { groupBox4.Visible = true; //pokazvane na kontrolite
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox19.Text == "" || textBox20.Text == "" || textBox23.Text == "") { MessageBox.Show("Моля попълнете всички полета","Грешка"); }
            else {

                FileStream file = new FileStream(@"klienti.txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(file);

                int red = 0;
                string[] s2 = new string[4];
                ArrayList list = new ArrayList();

                while (sr.EndOfStream != true)
                {
                    list.Add(sr.ReadLine());//pylnim lista
                }
                file.Position = 0;
                while (sr.EndOfStream != true) //obhojdame faila
                {
                    s2 = sr.ReadLine().Split();
                    if (s2[1] == textBox24.Text) { break; }
                    red++;
                }

                list[red] = textBox23.Text + '\t' + textBox24.Text + '\t' + textBox20.Text + '\t' + textBox19.Text; //promenqme reda

                sr.Close();
                file.Close();//zatvarqme faila

                File.Delete(@"klienti.txt");//iztrivame faila
                file = new FileStream(@"klienti.txt", FileMode.OpenOrCreate, FileAccess.Write); //failov potok
                StreamWriter sw = new StreamWriter(file);//potok za pisane

                foreach (object i in list) //obhojdame elementite na lista i gi zapisvame vyv faila
                {
                    sw.WriteLine(i);
                }

                sw.Close();
                file.Close();//zatvarqme aila
                MessageBox.Show("Данните за клиента бяха променени", "Промяна на данни"); //msg
                textBox24.Text = ""; //praznim poleto
                groupBox4.Visible = false; //skrivame poleto
              
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "") { MessageBox.Show("Моля попълнете полето", "Грешка"); } //proverka za validni danni
            else
            {
                klient.PremahvaneNaKlient(textBox18.Text);//izvikvane na funkciq
                MessageBox.Show("Клиента беше изтрит", "Изтриване"); //izvikvane na prozorec za syob6tenie
                textBox18.Text = "";//nulirane na poleto
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "") { MessageBox.Show("Моля попълнете данните","Грешка"); } //proverka za validnost na danni
            else if (stoka.ProverkaZaSyshtestvuvashtastoka(textBox8.Text) != true) { MessageBox.Show("Няма стока с този номер","Грешка"); }//proverka dali sy66testvuva takava stoka
            else {
                groupBox1.Visible = true; //pokazvane na kontrolite
            }
        }
    }
}
