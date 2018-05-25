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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            skorListele();
        }


        public void skorListele()
        {
            string dosya_yolu = "skor.txt";
            
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



    }
}
