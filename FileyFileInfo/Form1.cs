using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileyFileInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists("Archivo2.txt"))
            {
                //File.Create("Archivo1.txt");
                FileInfo archivo = new FileInfo("Archivo2.txt");
                archivo.Create();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete("Archivo2.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Archivo3.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("esta es la linea uno");
            sw.WriteLine("linea 2 prueba");
            sw.Flush(); //para mandar lo escrito
            sw.Close();
            fs.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Archivo3.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string texto = "";
            //ciclo while nos permite leer hasta cierta condicion "hasta que no existan caracteres"
            while(!sr.EndOfStream) 
            {
                texto += sr.ReadLine() + Environment.NewLine;
            }
            sr.Close();
            fs.Close(); 

            textBox1.Text = texto;
        }
    }
}
