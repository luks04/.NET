using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejoControlesFormulario
{
    public partial class Form1 : Form
    {
        private double[] sueldos = new double[6] { 100000,200000,300000,400000,50000,60000};
        private double porcentajeDescuento = 1.0;
        private int cantidadSelectedCheckBoxes = 0;
        private int bono = 0;

        public Form1()
        {
            InitializeComponent();
        }
        //****************************************************************************************************************
        private void clearBonoScreen()
        {
            this.labelTituloBono.Text = "";
            this.lblBono.Text = "";
        }
        //****************************************************************************************************************
        private void clearDescuentoScreen()
        {
            this.labelTituloDescuento.Text = "";
            this.lblDescuento.Text = "";
        }
        //****************************************************************************************************************
        private string actualizarSueldoCargo(int indiceCargo, int bonoSueldo)
        {
            double salario = sueldos[indiceCargo];
            salario = salario + bonoSueldo;
            return (salario.ToString());
        }
        //****************************************************************************************************************
        private string calcularDescuento(int indiceCargo, double porcentajeDcto)
        {
            double salario = sueldos[indiceCargo];
            double descuento = salario * porcentajeDcto;
            return (descuento.ToString());
        }
        //****************************************************************************************************************
        private int countCheckedBoxes()
        {
            int numberOfCheckedBoxes = 0;
            foreach (Control control in Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox checkbox = control as CheckBox;
                    if (checkbox.Checked)
                        numberOfCheckedBoxes += 1;
                }
            }
            return numberOfCheckedBoxes;
        }
        //****************************************************************************************************************
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int i = 0;
            //Recuperación del dato de la lista
            if (this.listaSeleccionItems.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un ítem de la lista");
            }
            else
            {
                List<string> resultado = new List<string>();

                // Recorremos todos los controles
                foreach (Control control in Controls)
                {
                    // Si algún control es un CheckBox
                    if (control is CheckBox)
                    {
                        // Entonces revisamos su valor
                        CheckBox checkbox = control as CheckBox;
                        // Si está seleccionado, entonces lo agregamos a una lista temporal
                        if (checkbox.Checked)
                            resultado.Add(checkbox.Text);
                    }
                }

                string salidaTexto = "";
                for (i = 0; i < resultado.Count; i++)
                {
                    salidaTexto += (string)resultado.ElementAt(i) + Environment.NewLine;
                }
                this.txtSalidaPasatiempos.Text = salidaTexto;
            }
        }
        //****************************************************************************************************************
        private void radioOpcion1_CheckedChanged(object sender, EventArgs e)
        {
            porcentajeDescuento = 0.10;
        }

        private void radioOpcion2_CheckedChanged(object sender, EventArgs e)
        {
            porcentajeDescuento = 0.25;
        }

        private void radioOpcion3_CheckedChanged(object sender, EventArgs e)
        {
            porcentajeDescuento = 0.40;
        }
        //****************************************************************************************************************
        private void listaSeleccionItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearBonoScreen();
            clearDescuentoScreen();
            int indice = this.listaSeleccionItems.SelectedIndex;
            this.lblSueldo.Text = actualizarSueldoCargo(indice, 0);
        }
        //****************************************************************************************************************
        private void btnBonoSueldo_Click(object sender, EventArgs e)
        {
            if (this.listaSeleccionItems.SelectedItem == null)
            {
                MessageBox.Show("Para calcular un bono es necesario seleccionar un ítem de la lista");
            }
            else
            {
                cantidadSelectedCheckBoxes = countCheckedBoxes();
                if (cantidadSelectedCheckBoxes == 3)
                {
                    bono = 300000;
                }
                else if (cantidadSelectedCheckBoxes == 2)
                {
                    bono = 50000;
                }
                else if (cantidadSelectedCheckBoxes == 1)
                {
                    bono = 10000;
                }
                else
                {
                    if(bono == 0)
                    {
                        MessageBox.Show("Para calcular un bono es necesario marcar al menos 1 pasatiempo");
                    }
                    bono = 0;
                }

                int indice = this.listaSeleccionItems.SelectedIndex;

                if (cantidadSelectedCheckBoxes != 0)
                {
                    MessageBox.Show("Se sumará un bono de un valor de " + bono + " al sueldo del cargo original por marcar " + cantidadSelectedCheckBoxes + " pasatiempo(s).");
                    this.lblTituloSueldo.Text = "Sueldo del cargo + bono:";
                    this.labelTituloBono.Text = "Bono:";
                    this.lblBono.ForeColor = Color.Green;
                    this.lblBono.Text = bono.ToString();
                }
                else
                {
                    this.lblTituloSueldo.Text = "Sueldo del cargo:";
                    clearBonoScreen();
                }
                this.lblSueldo.Text = actualizarSueldoCargo(indice, bono);
            }
        }
        //****************************************************************************************************************
        private void btnDescuento_Click(object sender, EventArgs e)
        {
            if (this.listaSeleccionItems.SelectedItem == null)
            {
                MessageBox.Show("Para calcular un descuento es necesario seleccionar un ítem de la lista");
            }
            else
            {
                bool isRadioBtnChecked = true;

                //Recuperación de la colección de radio botones
                if (this.radioOpcion1.Checked)
                {
                    MessageBox.Show("El porcentaje de descuento para " + this.radioOpcion1.Text + " es el %" + (porcentajeDescuento * 100) + " del sueldo original");
                }
                else if (this.radioOpcion2.Checked)
                {
                    MessageBox.Show("El porcentaje de descuento para " + this.radioOpcion2.Text + " es el %" + (porcentajeDescuento * 100) + " del sueldo original");
                }
                else if (this.radioOpcion3.Checked)
                {
                    MessageBox.Show("El porcentaje de descuento para " + this.radioOpcion3.Text + " es el %" + (porcentajeDescuento * 100) + " del sueldo original");
                }
                else
                {
                    isRadioBtnChecked = false;
                    MessageBox.Show("Para calcular un descuento es necesario seleccionar una opción de pago");
                }

                if (isRadioBtnChecked)
                {
                    int indiceCargo = this.listaSeleccionItems.SelectedIndex;
                    this.labelTituloDescuento.Text = "Descuento:";
                    this.lblDescuento.ForeColor = Color.Red;
                    this.lblDescuento.Text = calcularDescuento(indiceCargo, porcentajeDescuento);
                }
            }
        }
    }
}
