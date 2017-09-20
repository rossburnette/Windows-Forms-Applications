using System;
using System.IO;
using System.Collections;
using System.Text;

namespace N1KRabota
{
    public class Stoki //klas za dannite ot tip stoki tuk 6te se zapazvat !!
    {
        public bool ProverkaZaSyshtestvuvashtastoka(string nomer)
        {
            FileStream file = new FileStream(@"stoki.txt", FileMode.OpenOrCreate, FileAccess.Read);//syzdavame failov potok
            StreamReader sr = new StreamReader(file); //syzdavame potok za 4etene ot file

            string[] s = new string[6]; //deklarirame masiv ot stringove s 6 elemnta
            while (sr.EndOfStream != true) //obhojdame faila
            {
                s = sr.ReadLine().Split('\t'); //razdelqme danite na vseki red ot faila v masiva s2
                if (nomer == s[0]) //ako nomer e ednakyv kato pyrvata 4ast na reda funkciqta vry6ta ture v protiven slu4ai vry6ta false
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
        
        public void PremahvaneNaStoka(string nomer) //funkciq za premahvane ot fail
        {
            FileStream file = new FileStream(@"stoki.txt", FileMode.OpenOrCreate, FileAccess.Read); //failov potok
            StreamReader sr = new StreamReader(file);//Potok za 4etene

            ArrayList list = new ArrayList(); //Arai list za zapazvane na danite ot faila
            int red = 0; //int promenliva 
            string[] s = new string[6]; //masiv s 6 elementa  

            while (sr.EndOfStream != true) //obhojdame faila i pylnim listAray
            {
                list.Add(sr.ReadLine());
            }
            file.Position = 0; //vry6tame pointera na faila v na4aloto

            while (sr.EndOfStream != true) //obhojdame faila i stigame do reda s vyprosnite danni
            {
                s = sr.ReadLine().Split('\t');
                if (nomer == s[0]) { break; }
                else { red++; }

            }

            list.RemoveAt(red); //premahvame vyprosniq red

            sr.Close(); //zatvarqme 
            file.Close(); //zatvarqme faila


            File.Delete(@"stoki.txt"); //triem faila
            file = new FileStream(@"stoki.txt", FileMode.OpenOrCreate, FileAccess.Write); //syzdavame nov fail
            StreamWriter sw = new StreamWriter(file); //potok za pisane

            foreach (object i in list) //zapisvame seki red ot listaray bez iztritiq v noviq fail
            {
                sw.WriteLine(i);
            }

            sw.Close();
            file.Close(); //zatvarqme faila
        }

        public void DobavqneNaStoka(string nomer,string ime,string kolichestvo,string edcena,string proizvoditel,string dostavchik) //funkciq za dobavqne na danni vyv fail
        {
            FileStream file = new FileStream(@"stoki.txt", FileMode.Append, FileAccess.Write);//syzdavame failov potok
            StreamWriter sw = new StreamWriter(file); //syzdavame potok za pisane vyv file

            sw.WriteLine(nomer + '\t' + ime + '\t' + kolichestvo + '\t' + edcena + '\t' + proizvoditel + '\t' + dostavchik);//zapisva red vyv faila

            sw.Close();
            file.Close();
           
        }

        private string nomer; //promenliva

        public string Nomer
        {
            get { return nomer; }
            set { nomer = value; }
        }
        private string ime;//promenliva

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        private double kolichestvo;//promenliva

        public double Kolichestvo
        {
            get { return kolichestvo; }
            set { kolichestvo = value; }
        }
        private double edcena;//promenliva

        public double Edcena
        {
            get { return edcena; }
            set { edcena = value; }
        }
        private string proizvoditel;//promenliva

        public string Proizvoditel
        {
            get { return proizvoditel; }
            set { proizvoditel = value; }
        }
        private string dostavchik;//promenliva

        public string Dostavchik
        {
            get { return dostavchik; }
            set { dostavchik = value; }
        }
    }
}
