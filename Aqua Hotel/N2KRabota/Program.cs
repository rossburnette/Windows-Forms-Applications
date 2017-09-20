using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace N2KRabota
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Klienti
    {

        public void OtpisvaneNaKlient(string egn)
        {
            int red = 0;
            //premahvane na klient-a
            FileStream file = new FileStream(@"klienti.txt", FileMode.OpenOrCreate, FileAccess.Read); //failov potok
            StreamReader sr = new StreamReader(file);//Potok za 4etene

            ArrayList list = new ArrayList(); //Arai list za zapazvane na danite ot faila
             red = 0; //int promenliva 
            string[] s2 = new string[6]; //masiv s 6 elementa  

            while (sr.EndOfStream != true) //obhojdame faila i pylnim listAray
            {
                list.Add(sr.ReadLine());
            }
            file.Position = 0; //vry6tame pointera na faila v na4aloto

            while (sr.EndOfStream != true) //obhojdame faila i stigame do reda s vyprosnite danni
            {
                s2 = sr.ReadLine().Split('\t');
                if (egn == s2[2]) { break; }
                else { red++; }

            }
            string staq = s2[5];

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

            

        



            //promenqme danite za staite

            file = new FileStream(@"staii.txt", FileMode.OpenOrCreate, FileAccess.Read); //failov potok
            sr = new StreamReader(file);//potok za 4etene

             red = 0; //promenliva
            string []s = new string[3]; //masiv
             list = new ArrayList(); //list array

            while (sr.EndOfStream != true) //obhojdame faila
            {
                list.Add(sr.ReadLine()); //pylnim lista
            }
            file.Position = 0;
            while (sr.EndOfStream != true) //obhojdame faila 
            {
                s = sr.ReadLine().Split();
                if (s[0] == staq) { break; } //ako ima syvpadenie spri
                red++;
            }

            list[red] = s[0] + '\t' + s[1] + '\t' + "0"; //promenqme danite za reda

            sr.Close();
            file.Close();

            File.Delete(@"staii.txt"); //triem faila

            file = new FileStream(@"staii.txt", FileMode.OpenOrCreate, FileAccess.Write);
             sw = new StreamWriter(file);

            foreach (object i in list) //pylnim novi fail s danite ot lista
            {
                sw.WriteLine(i);
            }

            sw.Close();
            file.Close(); //zatvarqme faila



        }
        public bool IsKlientAlready(string egn) //funckiq s koqto preverqvame dali ve4e ima takyv klient
        {

            FileStream file = new FileStream("klienti.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene

            string[] s = new string[3]; //masiv s 3elemnta za zapisvane na danite ot redovete



            while (sr.EndOfStream != true) //obhojdame faila
            {
                s = sr.ReadLine().Split('\t');
                if (s[2] == egn) //ako ima takyv 
                {

                    sr.Close();
                    file.Close();
                    return true; //vry6ta true
                }
                
            }


            sr.Close();
            file.Close(); //zatvarqme faila
            return false;
        
        }

        public void AddKlient(string ime,string familiq,string egn,string lichnakarta,string data,string staq) //funkciq za dobavqne na klienti
        {
            //dobavqme noviq klient
            FileStream file = new FileStream(@"klienti.txt", FileMode.Append, FileAccess.Write);//syzdavame failov potok
            StreamWriter sw = new StreamWriter(file); //syzdavame potok za pisane vyv file

            sw.WriteLine(ime + '\t' + familiq + '\t' + egn + '\t' + lichnakarta + '\t' + data+ '\t' + staq);//zapisva red vyv faila

            sw.Close();
            file.Close();//zatavarqme faila

            //promenqme danite za staite

            file = new FileStream(@"staii.txt", FileMode.OpenOrCreate, FileAccess.Read); //failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene

            int red = 0; //promenliva
            string[] s = new string[3]; //masiv
            ArrayList list = new ArrayList(); //list array

            while (sr.EndOfStream != true) //obhojdame faila
            {
                list.Add(sr.ReadLine()); //pylnim lista
            }
            file.Position = 0;
            while (sr.EndOfStream != true) //obhojdame faila 
            {
                s = sr.ReadLine().Split();
                if (s[0] == staq) { break; } //ako ima syvpadenie spri
                red++;
            }
             
            list[red] = s[0] + '\t' + s[1] + '\t' + "1" ; //promenqme danite za reda

            sr.Close();
            file.Close();

            File.Delete(@"staii.txt"); //triem faila

            file = new FileStream(@"staii.txt", FileMode.OpenOrCreate, FileAccess.Write);
            sw = new StreamWriter(file);

            foreach (object i in list) //pylnim novi fail s danite ot lista
            {
                sw.WriteLine(i);
            }

            sw.Close();
            file.Close(); //zatvarqme faila

        }

        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        private string familiq;

        public string Familiq
        {
            get { return familiq; }
            set { familiq = value; }
        }
        private string egn;

        public string Egn
        {
            get { return egn; }
            set { egn = value; }
        }
        private string lichnakarta;

        public string Lichnakarta
        {
            get { return lichnakarta; }
            set { lichnakarta = value; }
        }
        private DateTime datapostypvane;

        public DateTime Datapostypvane
        {
            get { return datapostypvane; }
            set { datapostypvane = value; }
        }
        private int staq;

        public int Staq
        {
            get { return staq; }
            set { staq = value; }
        }
    }

    public enum tipstaq
    {
        Единична,
        Двойна,
        Апартамент,
    }

    public class Staii
    {
        public bool IsRoomFree(string nomer) //funkciq koqto proverqva dali staqta e daden pod naem
        {

            FileStream file = new FileStream("staii.txt", FileMode.OpenOrCreate, FileAccess.Read);//failov potok
            StreamReader sr = new StreamReader(file);//potok za 4etene

            string[] s = new string[3]; //masiv s 3elemnta za zapisvane na danite ot redovete
            
           

            while (sr.EndOfStream != true) //obhojdame faila
            {
                s = sr.ReadLine().Split('\t');
                if (s[0] == nomer) //ako iam syvpadenie
                {
                    if (s[2] == "0") //ako e svobodna 
                    {
                        sr.Close();
                        file.Close(); return true; //vry6ta true
                    }
                    else if (s[2] == "1") //ako ne e svobodna
                    {
                        sr.Close();
                        file.Close(); return false; //vry6ta false
                    }
                }
            }

            
            sr.Close();
            file.Close(); //zatvarqme faila
            return false;
        }
        private string nomer;

        public string Nomer
        {
            get { return nomer; }
            set { nomer = value; }
        }
        private tipstaq tip;

        public tipstaq Tip
        {
            get { return tip; }
            set { tip = value; }
        }
        private string svobodna;

        public string Svobodna
        {
            get { return svobodna; }
            set { svobodna = value; }
        }
    }
}
