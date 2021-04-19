using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiPrimeraAppASP
{
    public partial class PaginaOrigen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("pulsaron aceptar");
            string valorTexto = this.txtCajaTexto.Text;
            string producto = this.listaProductos.SelectedItem.Text;

            this.lblCajaTextoDigitada.Text = valorTexto;
            this.lblItemCombo.Text = producto + " - " + this.listaProductos.SelectedItem.Value;
        }
    }
}