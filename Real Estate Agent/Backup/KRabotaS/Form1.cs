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
    public partial class Form1 : Form
    {
        public Form1() //konstruktor
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();//zatvarqme formata
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddImot dobavqne = new AddImot(); // nov obekt
            dobavqne.ShowDialog(); //pokazvame prozoreca
            LoadListImoti();//popylvame lista s imoti

        }

        public void LoadListImoti() //funkciq za zarejdane na lista s imotite ot faila
        {
            ListImoti.DataSource = "";//izprazvame lista ako iam ne6tu izvedeno

            FileStream file = new FileStream("imoti.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                sr.ReadLine();
                redove++;
            }

            string[] s2 = new string[7]; //masiv s 7 elemnta za zapisvane na danite ot redovete

            Imoti[] imoti = new Imoti[redove]; //masiv ot obekti Imoti

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s2 = sr.ReadLine().Split('\t'); //4etem red po red
                imoti[i] = new Imoti //syzdavame obekt ot tip imoti
                {
                   Ime = s2[0],
                   Kod = s2[1],
                   Mqsto = s2[2],
                   Razmer = s2[3],
                   Cena = s2[4],
                   Prodavach = s2[5],
                   Broker = s2[6]                   
                };
                i++;
            }
            ListImoti.DataSource = imoti; //dobavqme danite v datagrdi vew

            sr.Close();
            file.Close(); //zatvarqme faila

        }

        public void LoadListImotiPoRazmer(string razmer) //funkciq za zarejdane na danite v lista po razmer
        {
           
            ListImoti.DataSource = "";
            FileStream file = new FileStream("imoti.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s3 = new string[7];

            while (sr.EndOfStream != true) //obhojdame faila
            {

                s3 = sr.ReadLine().Split('\t'); //4etem red po red
                if (s3[3] == razmer) { redove++; } //ako iam syvpadenie 
             }

            string[] s2 = new string[7]; //masiv s 7 elemnta za zapisvane na danite ot redovete

            Imoti[] imoti = new Imoti[redove]; //masiv ot obekti Imoti

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s2 = sr.ReadLine().Split('\t'); //4etem red po red
                if (s2[3] == razmer)
                {
                    imoti[i] = new Imoti //syzdavame obekt ot tip imoti
                    {
                        Ime = s2[0],
                        Kod = s2[1],
                        Mqsto = s2[2],
                        Razmer = s2[3],
                        Cena = s2[4],
                        Prodavach = s2[5],
                        Broker = s2[6]
                    };
                    i++;

                    ListImoti.DataSource = imoti; //dobavqme danite v datagrdi vew
                }
            }
            sr.Close();
            file.Close(); //zatvarqme faila
        }

        public void LoadListImotiPoCena(string cena) //funkciq za dobavqne v list na imoti po cena
        {
            ListImoti.DataSource = ""; //praznim lista
            FileStream file = new FileStream("imoti.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s3 = new string[7]; //masiv ot stringove

            while (sr.EndOfStream != true) //4etem red po red
            {

                s3 = sr.ReadLine().Split('\t');
                if (s3[4] == cena) { redove++; }
            }

            string[] s2 = new string[7]; //masiv s 7 elemnta za zapisvane na danite ot redovete

            Imoti[] imoti = new Imoti[redove]; //masiv ot obekti Aparatament

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s2 = sr.ReadLine().Split('\t'); //4etem red po red
                if (s2[4] == cena)
                {
                    imoti[i] = new Imoti //syzdavame obekt ot tip imoti
                    {
                        Ime = s2[0],
                        Kod = s2[1],
                        Mqsto = s2[2],
                        Razmer = s2[3],
                        Cena = s2[4],
                        Prodavach = s2[5],
                        Broker = s2[6]
                    };
                    i++;

                    ListImoti.DataSource = imoti; //dobavqme danite v datagrdi vew
                }
            }
            sr.Close();
            file.Close(); //zatvarqme faila
        }

        public void LoadListImotiNaiEftini() //funkciq za izvejdane na 5te nai eftini imota
        {
            ListImoti.DataSource = ""; //paznim lista

            FileStream file = new FileStream("imoti.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s2 = new string[7]; //masiv

            while (sr.EndOfStream != true) //4etem red po red 
            {
                sr.ReadLine();
                redove++; 
            }

            Imoti[] imoti = new Imoti[redove]; //masiv ot obekti Aparatament
            Imoti help = new Imoti(); //pomo6tna promenliva izpolzvana pri sortiraneto na masiva ot obekti
            Imoti[] imotinew = new Imoti[5]; //nov masiv ot obekti v kito 6te zapi6em 5te nai eftini imota

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s2 = sr.ReadLine().Split('\t'); //4etem red po red
               
                    imoti[i] = new Imoti //syzdavame obekt ot tip imoti
                    {
                        Ime = s2[0],
                        Kod = s2[1],
                        Mqsto = s2[2],
                        Razmer = s2[3],
                        Cena = s2[4],
                        Prodavach = s2[5],
                        Broker = s2[6]
                    };
                    i++;

                    
                
            }
            sr.Close();
            file.Close(); //zatvarqme faila


            //sortirane 
            for( i = 0;i<imoti.Length;i++ ) //obhojdame
                for (int j = i + 1; j < imoti.Length; j++) //obhojdame
                {
                    if (double.Parse(imoti[i].Cena) > double.Parse(imoti[j].Cena)) { help = imoti[i]; imoti[i] = imoti[j]; imoti[j] = help; } //sortirame

                }

            for (int h = 0; h <= 4; h++) //pylnim vtoriq masiv
            {
                if (h >= redove) { break; } //ako imotite sa po malko ot 5 da spre
                imotinew[h] = imoti[h]; 
            }
           


            ListImoti.DataSource = imotinew; //dobavqme danite v datagrdi vew

           
        }

        public void LoadListImotiPoKod(string kod) //funkciq za dobavqne na imoti v lista
        {
            ListImoti.DataSource = ""; //praznim lista
            FileStream file = new FileStream("imoti.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s3 = new string[7]; //masiv ot stringove

            while (sr.EndOfStream != true) //4etem ot faial red po red
            {

                s3 = sr.ReadLine().Split('\t');
                if (s3[1] == kod) { redove++; }
            }

            string[] s2 = new string[7]; //masiv s 7 elemnta za zapisvane na danite ot redovete

            Imoti[] imoti = new Imoti[redove]; //masiv ot obekti Imoti

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s2 = sr.ReadLine().Split('\t'); //4etem red po red
                if (s2[1] == kod)
                {
                    imoti[i] = new Imoti //syzdavame obekt ot tip imoti
                    {
                        Ime = s2[0],
                        Kod = s2[1],
                        Mqsto = s2[2],
                        Razmer = s2[3],
                        Cena = s2[4],
                        Prodavach = s2[5],
                        Broker = s2[6]
                    };
                    i++;

                    ListImoti.DataSource = imoti; //dobavqme danite v datagrdi vew
                }
            }
            sr.Close();
            file.Close(); //zatvarqme faila
        }

        public void LoadListBrokeri(string egn) //funkciq za pylnene na lista s brokeri ot faila po egn
        {
            ListBrokeri.DataSource = ""; //praznim lista
            FileStream file = new FileStream("brokeri.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva
            string[] s3 = new string[7]; //masiv

            while (sr.EndOfStream != true) //4etem red po red
            {

                s3 = sr.ReadLine().Split('\t');
                if (s3[3] == egn) { redove++; }
            }

            string[] s2 = new string[7]; //masiv s 7 elemnta za zapisvane na danite ot redovete

            Brokeri[] brokeri = new Brokeri[redove]; //masiv ot obekti Brokeri

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s2 = sr.ReadLine().Split('\t'); //4etem red po red
                if (s2[3] == egn)
                {
                    brokeri[i] = new Brokeri //syzdavame obekt ot tip brokeri
                    {
                        Ime = s2[0],
                        Prezime = s2[1],
                        Familiq = s2[2],
                        Egn = s2[3],
                        Tel = s2[4],
                        Email = s2[5],
                        Adres = s2[6]
                    };
                    i++;

                    ListBrokeri.DataSource = brokeri; //dobavqme danite v datagrdi vew
                }
            }
            sr.Close();
            file.Close(); //zatvarqme faila
        }

        public void LoadListBrokeri() //funkciq za pylnne na lista s brokeri
        {
            ListBrokeri.DataSource = "";//izprazvame lista ako iam ne6tu izvedeno

            FileStream file = new FileStream("brokeri.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene
            int redove = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila i broim redovete
            {
                sr.ReadLine();
                redove++;
            }

            string[] s2 = new string[7]; //masiv s 7 elemnta za zapisvane na danite ot redovete

            Brokeri[] brokeri = new Brokeri[redove]; //masiv ot obekti Brokeri

            file.Position = 0; //vry6tame pointera v na4aloto na faila
            int i = 0; //promenliva

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s2 = sr.ReadLine().Split('\t'); //4etem red po red
                brokeri[i] = new Brokeri //syzdavame obekt ot tip brokeri
                {
                    Ime = s2[0],
                    Prezime = s2[1],
                    Familiq = s2[2],
                    Egn = s2[3],
                    Tel = s2[4],
                    Email = s2[5],
                    Adres = s2[6]
                };
                i++;
            }
            ListBrokeri.DataSource = brokeri; //dobavqme danite v datagrdi vew

            sr.Close();
            file.Close(); //zatvarqme faila

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button6.Enabled = false; //izklu4vame butona
            ListImoti.Visible = true; //pokazvame lista s imoti
            ListBrokeri.Visible = false; //skrivame lista s brokeri
            LoadListImoti();//popylvame lista s imoti
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DelImot delimot = new DelImot(); //nov obekt za nov prozorec
            delimot.ShowDialog(); //pokazvame prozoreca
            LoadListImoti();//popylvame lista s imoti
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kod = ListImoti.Rows[ListImoti.SelectedCells[0].RowIndex].Cells[1].Value.ToString(); //vzemame koda na selectnatiq imot
            EditImot editimot = new EditImot(kod); //nov obekt za nov prozorec
            editimot.ShowDialog(); //pokazvame prozoreca
            LoadListImoti();//popylvame lista s imoti 
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox4.Enabled = true; //vklu4vame butona
            ListImoti.Visible = true; //pokazvame lista s imoti
            ListBrokeri.Visible = false; //skrivame lista s brokeri
            button6.Enabled = false; //izklu4vame butona
            LoadListImoti(); //zarejdame lista s imoti
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox4.Enabled = false; //spirame butonite ot group-boxa
            ListImoti.Visible = false; //skrivame lista s imoti
            button6.Enabled = true; //vklu4vame butona
            ListBrokeri.Visible = true; //pokazvame lista s brokeri
            LoadListBrokeri(); //zarejdame lisa s brokeri
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddBroker dobavibroker = new AddBroker(); //nov obekt za nov prozorec
            dobavibroker.ShowDialog(); //pokazvame prozoreca
            LoadListBrokeri(); //zarejdame lsita s brokeri

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DelBroker delbroker = new DelBroker(); //nov obekt za nov prozorec
            delbroker.ShowDialog(); //pokazvame prozoreca
            LoadListBrokeri(); //zarejdame lista s brokeri
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string egn = ListBrokeri.Rows[ListBrokeri.SelectedCells[0].RowIndex].Cells[3].Value.ToString(); //vzemame egn-to ot selektnatiq red
            EditBroker editborker = new EditBroker(egn);//nov obekt za nov proorec
            editborker.ShowDialog(); //pokazvame prozoreca
            LoadListBrokeri(); //zarejdame lisa s brokeri
        }

        private void button7_Click(object sender, EventArgs e)
        {
            simotkod serch1 = new simotkod();//nov obekt za nov proorec
            serch1.ShowDialog();            //pokazvame prozoreca
            LoadListImotiPoKod(serch1.kod);//zarejdame lisa s imoti
        }

        private void button8_Click(object sender, EventArgs e)
        {
            simotcena serch2 = new simotcena();//nov obekt za nov proorec
            serch2.ShowDialog();//pokazvame prozoreca
            LoadListImotiPoCena(serch2.cena);//zarejdame lisa s imoti
        }

        private void button9_Click(object sender, EventArgs e)
        {
            simotrazmer serch3 = new simotrazmer();//nov obekt za nov proorec
            serch3.ShowDialog();//pokazvame prozoreca
            LoadListImotiPoRazmer(serch3.razmer);//zarejdame lisa s imoti
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sbroker serch4 = new sbroker();//nov obekt za nov proorec
            serch4.ShowDialog();//pokazvame prozoreca
            ListBrokeri.Visible = true; //pokazvame lista s borkeri
            ListImoti.Visible = false; //skrivame lsita s imoti
            LoadListBrokeri(serch4.egn);//zarejdame lista s brokeri
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ListBrokeri.Visible = false; //skrivame lista s brokeri
            ListImoti.Visible = true;  //pokazvame lista s imoti
            LoadListImotiNaiEftini(); //zarejdame lsita s nai-eftinite imoti
        }
    }
}
