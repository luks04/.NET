using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiPrimeraAppASP.modelo;

namespace MiPrimeraAppASP
{
    public partial class CalculadorASPNET : System.Web.UI.Page
    {
        private LogicaCalculadora miFachadaCalculadora;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Control del postback (para evitar el recargue en cada refresco
            //de la página
            if (!Page.IsPostBack)
            {
                System.Diagnostics.Debug.WriteLine("objeto de negocio creado: " + miFachadaCalculadora);
            }
            else
            {
                //Cargar codigo
                miFachadaCalculadora = new LogicaCalculadora();
                System.Diagnostics.Debug.WriteLine("objeto de negocio creado 2 vez: " + miFachadaCalculadora);
            }

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            double n1 = 0.0;
            double n2 = 0.0;

            try
            {
                n1 = double.Parse(this.txtNumero1.Text);
                n2 = double.Parse(this.txtNumero2.Text);
                //Actualizar la vista
                this.txtResultado.Text = ejecutarOperacionCalculadora(n1, n2, obtenerOperacion(this.btnSumar.Text));
            }

            catch (Exception errorSuma)
            {
                System.Diagnostics.Debug.WriteLine("Error ocurrido: " + errorSuma.ToString());
                System.Diagnostics.Debug.WriteLine("Ingrese por favor valores numéricos");
            }
        }

        //Método universal para ejecutar cualquier operación de la
        //calculadora, llamando la fachada del servicio de negocio
        private string ejecutarOperacionCalculadora(double n1, double n2, string op)
        {
            string salida = "";
            double resultado = 0.0;
            resultado = miFachadaCalculadora.EjecutarOperacion(n1, n2, op);
            System.Console.WriteLine("Resultado operacion: " + resultado);

            //Lógica de presentación
            //Control en la forma de presentar los datos
            if (resultado == 0 && op.Equals("d"))
            {
                salida = "No se puede dividir por cero";
            }
            else
            {
                salida = resultado.ToString();
            }

            return (salida);
        }

        //***************************************************************
        //***************************************************************
        //***************************************************************
        private string obtenerOperacion(string nombreBoton)
        {
            string operacion = "";
            System.Console.WriteLine("Operacion: " + nombreBoton);

            switch (nombreBoton)
            {
                case "Sumar":
                    operacion = "a";
                    break;
                case "Restar":
                    operacion = "s";
                    break;
                case "Multiplicar":
                    operacion = "m";
                    break;
                default:
                    operacion = "d";
                    break;
            }

            System.Console.WriteLine("letra operacion: " + operacion);
            return (operacion);
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            double n1 = 0.0;
            double n2 = 0.0;

            try
            {
                n1 = double.Parse(this.txtNumero1.Text);
                n2 = double.Parse(this.txtNumero2.Text);
                //Actualizar la vista
                this.txtResultado.Text = ejecutarOperacionCalculadora(n1, n2, obtenerOperacion(this.btnRestar.Text));
            }

            catch (Exception errorSuma)
            {
                System.Console.WriteLine("Error ocurrido: " + errorSuma.ToString());
                System.Diagnostics.Debug.WriteLine("Ingrese por favor valores numéricos");
            }
        }

        protected void btnMultiplicar_Click(object sender, EventArgs e)
        {
            double n1 = 0.0;
            double n2 = 0.0;

            try
            {
                n1 = double.Parse(this.txtNumero1.Text);
                n2 = double.Parse(this.txtNumero2.Text);
                //Actualizar la vista
                this.txtResultado.Text = ejecutarOperacionCalculadora(n1, n2, obtenerOperacion(this.btnMultiplicar.Text));
            }

            catch (Exception errorSuma)
            {
                System.Console.WriteLine("Error ocurrido: " + errorSuma.ToString());
                System.Diagnostics.Debug.WriteLine("Ingrese por favor valores numéricos");
            }
        }

        protected void btnDividir_Click(object sender, EventArgs e)
        {
            double n1 = 0.0;
            double n2 = 0.0;

            try
            {
                n1 = double.Parse(this.txtNumero1.Text);
                n2 = double.Parse(this.txtNumero2.Text);
                //Actualizar la vista
                this.txtResultado.Text = ejecutarOperacionCalculadora(n1, n2, obtenerOperacion(this.btnDividir.Text));
            }

            catch (Exception errorSuma)
            {
                System.Console.WriteLine("Error ocurrido: " + errorSuma.ToString());
                System.Diagnostics.Debug.WriteLine("Ingrese por favor valores numéricos");
            }
        }

        protected void btnReestablecer_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.txtResultado.Text = "";
            this.txtNumero1.Focus();
        }

        protected void btnAcercaDe_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Pulsando el boton acerca de");
            ClientScript.RegisterStartupScript(GetType(), "mostrarAcercaDe",
            "mostrarAcercaDe();", true);
        }

        protected void enlaceRegresar_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Direccionando al home");
            Response.Redirect("~/Default.aspx");
        }
        //***************************************************************
        //***************************************************************
        //***************************************************************

    }//Fin clase

}//Fin namespace