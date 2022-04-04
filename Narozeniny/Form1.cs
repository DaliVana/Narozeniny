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

namespace Narozeniny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Otevření souborů
            StreamReader nacti = new StreamReader(textBox1.Text, Encoding.Default);

            // Přečtení a zápis prvního řádku (záhlaví)
            string zahlavi = nacti.ReadLine();

            // Čtení z výchozího, vyhodnocení a případný zápis do výsledného
            string radek;
            DateTime dneska = DateTime.Today;
            while ((radek = nacti.ReadLine()) != null)
            {
                // Částečné dekódování řádku
                string[] hodnoty = radek.Split(';');

                string jmeno = hodnoty[2] + " " + hodnoty[1];
                DateTime narozeniny = DateTime.Parse(hodnoty[3]);
                if (narozeniny.Day == dneska.Day && narozeniny.Month == dneska.Month)
                {
                    listBox1.Items.Add(jmeno);
                }
            }
            // Zavření obou souborů
            nacti.Close();

            MessageBox.Show("HOTOVO!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = openFileDialog1.FileName;
        }
    }
}
