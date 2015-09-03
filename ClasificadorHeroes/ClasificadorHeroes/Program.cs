using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{



    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

       
    }
    public class Processaherois {

        static string rutacarpetadesti = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string fentrada = rutacarpetadesti + @"\RESGISTRADOS.DAT";
        private string fherois = rutacarpetadesti + @"\SuperHeroes.dat";
        private string fsvillanos = rutacarpetadesti + @"\Villanos.dat";
        private string reglaValidacio = "[Dd]";

        public string Fentrada
        {
            get{return fentrada;}
            set { fentrada = value;}
        }

        public string Fherois
        {
            get{ return fherois;}
            set {fherois = value;}
        }

        public string Fsvillanos
        {
            get{return fsvillanos;}
            set{fsvillanos = value;}
        }

        public string ReglaValidacio
        {
            get{return reglaValidacio;}
            set{ reglaValidacio = value;}
        }


        // procesar el arxivo  devuelve valores segun tipo de fallo
        public int procesa(Boolean sobrescribir=false) {

            TextWriter twh;
            TextWriter twv;

            try
            {
                if (!File.Exists(fherois) && !File.Exists(fsvillanos))
                {
                    var  tempfitx = File.Create(fherois);
                    tempfitx.Close();
                    tempfitx =  File.Create(fherois);
                    tempfitx.Close();
                    twh = new StreamWriter(fherois);
                    twv = new StreamWriter(fsvillanos);
                }
                else if (sobrescribir)
                {
                    twh = new StreamWriter(fherois);
                    twv = new StreamWriter(fsvillanos);
                }
                else {
                    // los arxivos existen i no se ha pedido sobrescribir
                    return 4;
                }
                if (OmpleLlistes(fentrada, twh, twv))
                {
                    //todo bien
                    return 1;
                }
                else {
                    // no se pudo leer el archivo de entrada
                    return 3;
                }            
            }
            catch 
            {
                // problema al acceder y/o crear archivos de salida
                return 2;
            }
        }


        // abre el arxivo de entrada comprueva los nombres i rellena los arxivos de salida, devuelva true= todos bien, devuelve false= fallo al leer
        private Boolean OmpleLlistes(string fitxerentrada, TextWriter fitxersherois, TextWriter fitxersvillanos)
        {
            
            try
            {
                using (StreamReader sr = new StreamReader(fitxerentrada))
                {
                    while (sr.Peek() >= 0)
                    {
                        string linea = sr.ReadLine();
                        if (Regex.IsMatch(linea, reglaValidacio)) {
                            //villano
                            fitxersvillanos.WriteLine(linea); ;
                           
                        } else {
                            //heroe
                            fitxersherois.WriteLine(linea);
                        }
                      
                    }
                }
                fitxersherois.Close();
                fitxersvillanos.Close();
                return true;
            }
            catch 
            {
                fitxersherois.Close();
                fitxersvillanos.Close();
                return false ;
            }
        }
    }

   
}
