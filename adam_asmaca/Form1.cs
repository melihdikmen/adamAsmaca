using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using adam_asmaca.Properties;
using System.IO;

namespace adam_asmaca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int hak;
        string kelime;
        TextBox[] texdizi = new TextBox[100];
           

        public  void dosyadanOku()
        {
            string dosya_yolu = "kelimeler.txt";
          
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
           
            StreamReader sw = new StreamReader(fs);
        
            Random rnd = new Random();
            int rand = rnd.Next(3, 7);
          
            string yazi = sw.ReadLine();
            int uzunluk;
            string[] okunan =new string[100];
            int i=0;
            
            while (yazi!=null)
            {
                uzunluk = yazi.Length;
                if (uzunluk == rand)
                {
                    okunan[i] = yazi;
                    i++;
                }

                yazi = sw.ReadLine();
               
            }

           int rast= rnd.Next(0, i);
            kelime = okunan[rast];
           

            for ( i = 0; i < rand; i++)
            {

                TextBox textbox = new TextBox();
                textbox.Top = 50;
                textbox.Left = 400 + (i * 50);
                textbox.Width = 25;
                textbox.Text = null;
                textbox.ReadOnly = true;
                texdizi[i] = textbox;

                this.Controls.Add(textbox);

            }

            haklabel.Text = (kelime.Length + 2).ToString();
            hak = kelime.Length+2;
           
            sw.Close();
            fs.Close();
           
        }
        
        


        public  void dosyadanOku_2(int deger)
        {
            string dosya_yolu = "kelimeler.txt";
           
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
          
            StreamReader sw = new StreamReader(fs);
           
            string[] okunan = new string[100];
            int i = 0;
            Random rnd = new Random();

            string yazi = sw.ReadLine();
            int uzunluk;

            while (yazi != null)
            {
                uzunluk = yazi.Length;
                if (uzunluk == deger)
                {
                    okunan[i] = yazi;
                    i++;
                }

                yazi = sw.ReadLine();

            }

            int rast = rnd.Next(0, i);
            kelime = okunan[rast];
           
           
            for ( i = 0; i < deger; i++)
            {
                TextBox textbox = new TextBox();
                textbox.Top = 50;
                textbox.Left = 400+(i*50);
                textbox.Width = 25;
                textbox.Text = null;
                textbox.ReadOnly = true;

                texdizi[i] = textbox;

                this.Controls.Add(textbox);
 
            }

            haklabel.Text = (kelime.Length + 2).ToString();
            hak = kelime.Length+2;

            sw.Close();
            fs.Close();
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
          
           
            if (radioButton1.Checked == true)
            {
                int deger = (int)numericUpDown1.Value;
                dosyadanOku_2(deger);
            }

            if (radioButton2.Checked == true)
            {
                dosyadanOku();
            }

            textBox1.Enabled = true;


        }






       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
        }

       
        
        
        private void button2_Click(object sender, EventArgs e)
        {
             int tekrar=label1.Text.IndexOf(textBox1.Text);
             int dogru=0;
            
            if (textBox1.Text != "")
             {


                 if (tekrar == -1)
                 {
                   
                     label1.Text += textBox1.Text + " ";
                     char aranacak = char.Parse(textBox1.Text);

                     for (int i = 0; i < kelime.Length; i++)
                     {
                         if (kelime[i] == aranacak)
                         {
                             texdizi[i].Text = textBox1.Text;
                              dogru = 1;
                         }

                     }

                     int sayac = 0;


                     for (int i = 0; i < kelime.Length; i++)
                     {
                         if (texdizi[i].Text != "")
                         {
                             sayac++;
                         }

                     }





                     int puan = sayac * 5;
                     skorLabel.Text = puan.ToString();







                     if (sayac == kelime.Length)
                     {
                         skorYaz(puan);
                         MessageBox.Show("oyun bitti kazandınız.");
                         Application.Restart();


                     }

                     if (hak == 1)
                     {

                          skorYaz(puan);  
                         MessageBox.Show("Hakkınız Bitmiştir!!!");
                         MessageBox.Show("kelime: " + kelime);
                         Application.Restart();
                     }


                     if (dogru==0)
                     {
                         hak--;
                         
                     }

                     haklabel.Text = hak.ToString();

                 }


                 else

                 {
                     MessageBox.Show("Her Harf Bir Kez Denenmelidir.");
                 }




                
             }

             else
             {
                 MessageBox.Show("Lütfen Bir Karakter Giriniz!!!");
             }

            

            textBox1.Text = "";
        }






        public void skorYaz(int skor)
        {
            string dosya_yolu = "skor.txt";
           
           
            StreamWriter sw = new StreamWriter(dosya_yolu,true);
            //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
            sw.WriteLine("Onceki Oyuncu Puanı:"+skor);
            sw.WriteLine("--------------------");
        
            
            //Dosyaya ekleyeceğimiz iki satırlık yazıyı WriteLine() metodu ile yazacağız.
            sw.Flush();
            //Veriyi tampon bölgeden dosyaya aktardık.
            sw.Close();
          
 

        }


       
        
        
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            FileStream fs = new FileStream("skor_yeni.txt", FileMode.Create, FileAccess.ReadWrite);
            fs.Close();
            File.Delete("skor.txt");
            File.Move("skor_yeni.txt", "skor.txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text=textBox1.Text.ToLower();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122 || (int)e.KeyChar == 231 || (int)e.KeyChar == 305 || (int)e.KeyChar == 287 || (int)e.KeyChar == 246 || (int)e.KeyChar == 351 || (int)e.KeyChar == 252)
            {
                e.Handled = false;
            }
            
            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
 
            
            else
            {
                e.Handled = true;
                MessageBox.Show("sadece harf girişi yapılmaldır.");
            }

        }

       
        
 
        }
       

      
        }



        
        
       
    


