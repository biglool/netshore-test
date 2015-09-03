using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        Processaherois llegint = new Processaherois();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            llegir();
        }

        private void llegir(Boolean sobrescribir = false) {

            int resultat = llegint.procesa(sobrescribir);
            if (resultat == 1)
            {
                textBox1.AppendText("Todo bien" + Environment.NewLine);
            }
            else if (resultat == 2)
            {
                textBox1.AppendText("problema al acceder a los archivos de salida comprueba que no esten abiertos y tiene permisos,consulta al Administrador y vuelve a intentar" + Environment.NewLine);
            }
            else if (resultat == 3)
            {
                textBox1.AppendText("problema al leer el archivo de entrada comprueba que no este abierto y tiene permisos,consulta al Administrador y vuelve a intentar" + Environment.NewLine);
            }
            else if (resultat == 4)
            {
                if (MessageBox.Show("Los archivos de salida ya existen, desea sobreescribir", "HEY!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                {
                    textBox1.AppendText("Los archivos de salida ya existen, no se ha sobreescrito" + Environment.NewLine);
                }
                else {
                    llegir(true);
                }
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "dat files (*.dat)|*.dat|txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button2.Text = openFileDialog1.FileName;
                llegint.Fentrada = openFileDialog1.FileName;
                button1.Enabled = true;
            }
        }
    }
}
