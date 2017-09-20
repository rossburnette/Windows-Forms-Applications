using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace KRabotaS
{
    public class Brokeri //klas za danite na brokerite
    {
        public bool PreverkaDaliImaTakyvBroker(string egn)  //funkciq koqto proverqva dali sy6testvuva broker s dadeno egn
        {
            FileStream file = new FileStream(@"brokeri.txt", FileMode.OpenOrCreate, FileAccess.Read);//syzdavame failov potok
            StreamReader sr = new StreamReader(file); //syzdavame potok za 4etene ot file

            string[] s2 = new string[7];
            while (sr.EndOfStream != true) //obhojdame faila
            {
                s2 = sr.ReadLine().Split('\t'); //razdelqme danite na vseki red ot faila v masiva s2
                if (egn == s2[3])
                {
                    sr.Close();
                    file.Close();
                    return true;//ako ima takyv broker funkciqta vry6ta true
                }
            }
            sr.Close();
            file.Close();
            return false; //ina4e false
        }

        private string ime, prezime, familiq, tel, email, adres, egn; //promenlivi

        public string Egn
        {
            get { return egn; }
            set { egn = value; }
        }

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public string Familiq
        {
            get { return familiq; }
            set { familiq = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

    }
}
