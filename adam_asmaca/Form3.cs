using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace adam_asmaca
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            kelime_goster();
        }


        public void kelime_goster()
        {
            string dosya_yolu = "kelimeler.txt";
           
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
          
            StreamReader sw = new StreamReader(fs);
           
            string yazi = sw.ReadLine();
            while (yazi != null)
            {
                listBox1.Items.Add(yazi);
                yazi = sw.ReadLine();
            }
            
            sw.Close();
            fs.Close();
        }

        public void kelime_ekle(string kelime)
        {
            string dosya_yolu = "kelimeler.txt";
            
            StreamWriter sw = new StreamWriter(dosya_yolu,true);
           
            sw.WriteLine(kelime);

            sw.Flush();
            
            sw.Close();
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            kelime_ekle(textBox1.Text.Trim());
            textBox1.Clear();
            listBox1.Items.Clear();
            kelime_goster();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            kelime_sil(listBox1.Text);
            listBox1.Items.Clear();
            kelime_goster();

        }


        public void kelime_sil(string silinecek)
        {
            string dosya_yolu = "kelimeler.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            StreamWriter sw = new StreamWriter("kelimeler_gecici.txt", true);
            
            String yazi = sr.ReadLine();

            while (yazi != null)
            {
                if (yazi != silinecek)
                {
                    sw.WriteLine(yazi);
                }
                yazi=sr.ReadLine();


            }
            
            fs.Close();
            sr.Close();
            sw.Close();

            File.Delete("kelimeler.txt");
            File.Move("kelimeler_gecici.txt", "kelimeler.txt");
            
      

                


        }


    

        
    }
}
