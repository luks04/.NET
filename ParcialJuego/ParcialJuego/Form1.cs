using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParcialJuego.dao;

/*
    Maycol Andres Canastero Soler
    Lucas Alejandro Patiño Dorado
 */

namespace ParcialJuego
{
    public partial class Form1 : Form
    {
        private static DAOJuegoParcial dataAccessObject = new DAOJuegoParcial(ConfigurationManager.ConnectionStrings["OrigenDatosSQLServerDemo"].ConnectionString);
        private string[] arregloLetras = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };

        public Form1()
        {
            InitializeComponent();
        }

        private List<int> getCodigosLetrasPalabra(string palabraValidada)
        {
            char[] arrayPalabra = palabraValidada.ToCharArray(0, palabraValidada.Length);
            List<int> arrayCodigosLetrasPalabra = new List<int>();

            foreach (char i in arrayPalabra)
            {
                int codLetra = Array.IndexOf(arregloLetras, i.ToString()) + 1;
                arrayCodigosLetrasPalabra.Add(codLetra);
            }
            return arrayCodigosLetrasPalabra;
        }

        private bool validarTextoIngresado(string palabra)
        {
            bool validPalabra = true;
            char[] arr;
            if (palabra.Length != 0)
            {
                arr = palabra.ToCharArray(0, palabra.Length);
                foreach (char c in arr)
                {
                    if (!arregloLetras.Contains(c.ToString()))
                    {
                        validPalabra = false;
                        break;
                    }
                }
            }
            else
            {
                validPalabra = false;
            }
            return validPalabra;
        }

        private string codificarPalabra(List<int> arregloCodigosPalabra)
        {
            List<double> arregloPalabraCifrada = new List<double>();
            int codigoLetraPista = Int32.Parse(this.letraPistaCod.SelectedValue.ToString());
            for (int i = 0; i < arregloCodigosPalabra.Count; i++)
            {
                double valorCifrado = (arregloCodigosPalabra[i] + codigoLetraPista) / 2.0;
                arregloPalabraCifrada.Add(valorCifrado);
            }

            string palabraCodificada = String.Join(" - ", arregloPalabraCifrada);

            return palabraCodificada;
        }

        private string codificarPalabraCoincidencia(List<int> arregloCodigosPalabra)
        {
            List<double> arregloPalabraCifrada = new List<double>();
            int codigoLetraPista = Int32.Parse(this.letraPistaDec.SelectedValue.ToString());
            for (int i = 0; i < arregloCodigosPalabra.Count; i++)
            {
                double valorCifrado = (arregloCodigosPalabra[i] + codigoLetraPista) / 2;
                arregloPalabraCifrada.Add(valorCifrado);
            }

            string palabraCodificada = String.Join(" - ", arregloPalabraCifrada);

            return palabraCodificada;
        }

        private bool validarCodigoIngresado(List<double> listaCodigosPalabra)
        {
            bool validPalabra = true;
            if (listaCodigosPalabra.Count != 0)
            {
                for (int i = 0; i < listaCodigosPalabra.Count(); i++)
                {
                    double valorCodigo = listaCodigosPalabra[i];
                    if (valorCodigo < 1 || valorCodigo > arregloLetras.Length)
                    {
                        validPalabra = false;
                        break;
                    }
                    else if ((valorCodigo % (int)valorCodigo) != 0.5 && (valorCodigo % (int)valorCodigo) != 0.0)
                    {
                        validPalabra = false;
                        break;
                    }
                    else
                    {
                        validPalabra = true;
                    }
                }
            }
            else
            {
                validPalabra = false;
            }
            return validPalabra;
        }

        private List<double> getListaParaDecodificar(string codigosCifrados)
        {
            string auxCodigosCifrados = codigosCifrados.Replace(" ", String.Empty);
            string[] auxArray = auxCodigosCifrados.Split('-');
            List<double> listaCodigosCifrados = new List<double>(Array.ConvertAll(auxArray, Double.Parse));
            return listaCodigosCifrados;
        }

        private string decodificarPalabra(List<double> listaCodigosPalabra)
        {
            List<string> listaPalabraDescifrada = new List<string>();
            int codigoLetraPista = Int32.Parse(this.letraPistaDec.SelectedValue.ToString());
            for (int i = 0; i < listaCodigosPalabra.Count; i++)
            {
                double valorDescifrado = (2.0 * listaCodigosPalabra[i]) - codigoLetraPista;
                if ((2.0 * listaCodigosPalabra[i]) < codigoLetraPista)                    
                {
                    MessageBox.Show("Desde esta letra pista ya no es");
                }
                if ((2.0 * listaCodigosPalabra[i]) == codigoLetraPista)
                {
                    MessageBox.Show("Al parece falta el ,5 en la letra de la posición " + (i+1));
                }
                else if (valorDescifrado > 0)
                {
                    for (int j = 0; j <= arregloLetras.Length; j++)
                    {
                        if (valorDescifrado == j)
                        {
                            listaPalabraDescifrada.Add(arregloLetras[j - 1]);
                        }
                    }
                }

            }

            string palabraCodificada = String.Join("", listaPalabraDescifrada);
            return palabraCodificada;
        }

        private (bool, string) buscarCoincidenciaCifrado(int ronda, string codigoPalabraSinDecimales)
        {
            bool exists = false;
            string palabra = "";
            List <PalabraCifrar> listaPalabras = dataAccessObject.consultarListaPalabras(ronda);
            List<string> listaCodigos = new List<string>();
            for (int i = 0; i < listaPalabras.Count; i++)
            {
                List<int> codigosPalabra = getCodigosLetrasPalabra(listaPalabras[i].Palabra);
                string cifrado = codificarPalabraCoincidencia(codigosPalabra);
                listaCodigos.Add(cifrado);
                if (listaCodigos.Contains(codigoPalabraSinDecimales))
                {
                    exists = true;
                    break;
                }
            }
            if (listaCodigos.Contains(codigoPalabraSinDecimales))
            {
                int indicePalabra = listaCodigos.IndexOf(codigoPalabraSinDecimales);
                palabra = listaPalabras[indicePalabra].Palabra;
            }

            return (exists, palabra);
        }
        //*******************************************************************************************
        //************************************ BOTON CIFRAR *****************************************
        //*******************************************************************************************
        private void btnCifrar_Click(object sender, EventArgs e)
        {
            this.tbCodigosCifrados.Clear();
            string entradaTexto = "";
            if (this.dropDownRonda.SelectedIndex != -1)
            {
                (string palabra, string categoria) = dataAccessObject.consultarPalabrasParaCifrar(this.dropDownRonda.SelectedIndex + 1);
                this.inputTexto.Text = palabra;
                this.lblCategoria.Text = categoria;
            }
            entradaTexto = this.inputTexto.Text;
            bool isValid = validarTextoIngresado(entradaTexto);
            if (entradaTexto.Length == 0)
            {
                MessageBox.Show("Error, debe ingresar un texto para cifrar");
            }
            else if(!isValid)
            {
                MessageBox.Show("Error, verifique el texto ingresado. Recuerde que deben ser minúsculas y sin acentos");
            }
            else if (this.letraPistaCod.SelectedIndex == -1)
            {
                MessageBox.Show("Error, escoja una letra pista para cifrar");
            }
            else
            {
                List<int> codigosPalabra = getCodigosLetrasPalabra(entradaTexto);
                this.tbCodigosCifrados.Text = codificarPalabra(codigosPalabra);
            }
        }
        //*******************************************************************************************
        //********************************** BOTON DESCIFRAR ****************************************
        //*******************************************************************************************

        private void btnDescifrar_Click(object sender, EventArgs e)
        {
            this.tbTexto.Clear();
            string entradaCodigos = this.inputCodigos.Text;

            if (entradaCodigos.Length == 0)
            {
                MessageBox.Show("Error, debe ingresar el código para descifrar");
            }
            else
            {
                List<double> listaCodigos = getListaParaDecodificar(entradaCodigos);
                bool isValid = validarCodigoIngresado(listaCodigos);
                if (!isValid)
                {
                    MessageBox.Show("Error, verifique los códigos ingresados. Recuerde que deben ser números mayores o iguales a 1 y menores o iguales a {0}" + arregloLetras.Count());
                }
                else if (this.letraPistaDec.SelectedIndex == -1)
                {
                    MessageBox.Show("Error, escoja una letra pista para descifrar");
                }
                else
                {
                    this.tbTexto.Text = decodificarPalabra(listaCodigos);
                }
            }
        }
        //*******************************************************************************************
        //********************************** LIMPIAR VALORES ****************************************
        //*******************************************************************************************
        private void btnCleanFields_Click(object sender, EventArgs e)
        {
            this.inputTexto.Clear();
            this.lblCategoria.Text = "...";
            this.tbCodigosCifrados.Clear();
            this.dropDownRonda.SelectedIndex = -1;
            this.letraPistaCod.SelectedIndex = -1;
            this.letraPistaDec.SelectedIndex = -1;
            this.inputCodigos.Clear();
            this.tbTexto.Clear();
        }
        //*******************************************************************************************
        //*************************************** SALIR *********************************************
        //*******************************************************************************************
        private void btnSalir_Click(object sender, EventArgs e)
        {
            string message = "¿Desea confirmar el cierre de la aplicación?";
            string title = "Cerrar Aplicación";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //*******************************************************************************************
        //**************************************** LOAD *********************************************
        //*******************************************************************************************
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSetLetrasPistaDec.LetraPista' Puede moverla o quitarla según sea necesario.
            this.letraPistaTableAdapter1.Fill(this.dataSetLetrasPistaDec.LetraPista);
            // TODO: esta línea de código carga datos en la tabla 'dataSetLetrasPistaCod.LetraPista' Puede moverla o quitarla según sea necesario.
            this.letraPistaTableAdapter.Fill(this.dataSetLetrasPistaCod.LetraPista);
            this.dropDownRonda.SelectedIndex = -1;
            this.letraPistaCod.SelectedIndex = -1;
            this.letraPistaDec.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int ronda = this.dropDownRonda.SelectedIndex + 1;
            string codigoPalabra = this.inputCodigos.Text;
            if (this.letraPistaDec.SelectedIndex == -1)
            {
                MessageBox.Show("Error, escoja una letra pista para descifrar");
            }
            else
            {
                (bool exists, string palabraCoincide) = buscarCoincidenciaCifrado(ronda, codigoPalabra);
                if (exists)
                {
                    MessageBox.Show("La palabra existe en la base de datos y es: " + palabraCoincide);
                    this.tbTexto.Text = palabraCoincide;
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna coincidencia en la base de datos");
                }
            }
        }
    }
}
