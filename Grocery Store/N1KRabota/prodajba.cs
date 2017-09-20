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
    public partial class prodajba : Form
    {
        public string nomer;
        public double sega;
        public prodajba(string nomer)
        {
            InitializeComponent();
            this.nomer = nomer;
        }

        private void prodajba_Load(object sender, EventArgs e)
        {
            label2.Text = nomer;

            FileStream file = new FileStream(@"stoki.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            string[] s = new string[6];
            while (sr.EndOfStream != true)
            {
                s = sr.ReadLine().Split('\t');
                if (s[0] == nomer)
                {
                    label4.Text = s[1];
                    sega = double.Parse(s[2]);
                    break;
                }
            }

            sr.Close();
            file.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.Parse(textBox1.Text) > sega) { MessageBox.Show("В склада няма толкова налична стока", "Грешка"); }
            else {
                FileStream file = new FileStream(@"stoki.txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(file);

                int red = 0;
                string[] s2 = new string[6];
                ArrayList list = new ArrayList();

                while (sr.EndOfStream != true)
                {
                    list.Add(sr.ReadLine());//pylnim lista
                }
                file.Position = 0;
                while (sr.EndOfStream != true) //obhojdame faila
                {
                    s2 = sr.ReadLine().Split();
                    if (s2[0] == nomer) { break; }
                    red++;
                }
                double ostanalo;
                ostanalo = double.Parse(s2[2]) - double.Parse(textBox1.Text);
                list[red] = s2[0] + '\t' + s2[1] + '\t' + ostanalo.ToString()  + '\t' + s2[3] + '\t' + s2[4] + '\t' + s2[5]; //promenqme reda

                sr.Close();
                file.Close();//zatvarqme faila

                File.Delete(@"stoki.txt");//iztrivame faila
                file = new FileStream(@"stoki.txt", FileMode.OpenOrCreate, FileAccess.Write); //failov potok
                StreamWriter sw = new StreamWriter(file);//potok za pisane

                foreach (object i in list) //obhojdame elementite na lista i gi zapisvame vyv faila
                {
                    sw.WriteLine(i);
                }

                sw.Close();
                file.Close();//zatvarqme aila
             
            


                this.Close(); }

        }
    }
}
