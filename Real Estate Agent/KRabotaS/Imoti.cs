using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace KRabotaS
{
    public class Imoti
    {
        public bool ProverkaDaliImaTakyvImot(string kod) //funkciq koqto proverqva dali ima imot s tozi kod
        {
            FileStream file = new FileStream(@"imoti.txt", FileMode.OpenOrCreate, FileAccess.Read);//syzdavame failov potok
            StreamReader sr = new StreamReader(file); //syzdavame potok za 4etene ot file

            string[] s2 = new string[7]; 
            while (sr.EndOfStream != true) //obhojdame faila
            {
                s2 = sr.ReadLine().Split('\t'); //razdelqme danite na vseki red ot faila v masiva s2
                if (kod == s2[1]) 
                {
                    sr.Close();
                    file.Close();
                    return true; //ako ima takyv imot vry6ta true
                }
            }
            sr.Close();
            file.Close();
            return false; //ina4e false
        }

        private string ime, kod, mqsto, razmer, cena, prodavach, broker; //promenlivi

        public string Razmer
        {
            get { return razmer; }
            set { razmer = value; }
        }

        public string Prodavach
        {
            get { return prodavach; }
            set { prodavach = value; }
        }

        public string Mqsto
        {
            get { return mqsto; }
            set { mqsto = value; }
        }

        public string Kod
        {
            get { return kod; }
            set { kod = value; }
        }

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public string Cena
        {
            get { return cena; }
            set { cena = value; }
        }

        public string Broker
        {
            get { return broker; }
            set { broker = value; }
        }
    }
}
