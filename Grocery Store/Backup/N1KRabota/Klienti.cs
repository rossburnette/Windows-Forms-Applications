using System;
using System.Collections;
using System.Text;
using System.IO;

namespace N1KRabota
{
    public class Klienti //tuk 6te se sahranqvat danite za klientite
    {
        public bool ProverkaZaSyshtestvuvashtKlient(string bulstat)
        {
            FileStream file = new FileStream(@"klienti.txt", FileMode.OpenOrCreate, FileAccess.Read);//syzdavame failov potok
            StreamReader sr = new StreamReader(file); //syzdavame potok za 4etene ot file

            string[] s = new string[4]; //deklarirame masiv ot stringove s 4 elemnta
            while (sr.EndOfStream != true) //obhojdame faila
            {
                s = sr.ReadLine().Split('\t'); //razdelqme danite na vseki red ot faila v masiva s
                if (bulstat == s[1]) //ako bulstata e ednakyv kato pyrvata 4ast na reda funkciqta vry6ta ture v protiven slu4ai vry6ta false
                {
                    sr.Close();
                    file.Close();
                    return true;
                }
            }
            sr.Close();
            file.Close();
            return false; 
        }

        public void PremahvaneNaKlient(string bulstat) //funkciq za premahvane ot fail
        {
            FileStream file = new FileStream(@"klienti.txt", FileMode.OpenOrCreate, FileAccess.Read); //failov potok
            StreamReader sr = new StreamReader(file);//Potok za 4etene

            ArrayList list = new ArrayList(); //Arai list za zapazvane na danite ot faila
            int red = 0; //int promenliva 
            string[] s = new string[4]; //masiv s 4 elementa  

            while (sr.EndOfStream != true) //obhojdame faila i pylnim listAray
            {
                list.Add(sr.ReadLine());
            }
            file.Position = 0; //vry6tame pointera na faila v na4aloto

            while (sr.EndOfStream != true) //obhojdame faila i stigame do reda s vyprosnite danni
            {
                s = sr.ReadLine().Split('\t');
                if (bulstat == s[1]) { break; }
                else { red++; }

            }

            list.RemoveAt(red); //premahvame vyprosniq red

            sr.Close(); //zatvarqme 
            file.Close(); //zatvarqme faila


            File.Delete(@"klienti.txt"); //triem faila
            file = new FileStream(@"klienti.txt", FileMode.OpenOrCreate, FileAccess.Write); //syzdavame nov fail
            StreamWriter sw = new StreamWriter(file); //potok za pisane

            foreach (object i in list) //zapisvame seki red ot listaray bez iztritiq v noviq fail
            {
                sw.WriteLine(i);
            }

            sw.Close();
            file.Close(); //zatvarqme faila
        }

        public void DobavqneNaKlient(string ime, string bulstat, string dannomer, string adres) //funkciq za dobavqne na danni vyv fail
        {
            FileStream file = new FileStream(@"klienti.txt", FileMode.Append, FileAccess.Write);//syzdavame failov potok
            StreamWriter sw = new StreamWriter(file); //syzdavame potok za pisane vyv file

            sw.WriteLine(ime + '\t' + bulstat + '\t' + dannomer + '\t' + adres );//zapisva red vyv faila

            sw.Close();
            file.Close();
        }
        
        private string ime; //promenliva

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        private string bulstat;//promenliva

        public string Bulstat
        {
            get { return bulstat; }
            set { bulstat = value; }
        }
        private string dannomer;//promenliva

        public string Dannomer
        {
            get { return dannomer; }
            set { dannomer = value; }
        }
        private string adres;//promenliva

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }
    }
}
