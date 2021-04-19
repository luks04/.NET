using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiPrimeraAppASP
{
    public partial class CapturaDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCapturarDatos_Click(object sender, EventArgs e)
        {
            string generos = "";
            string plataforma = "";
            int cont = 0;
            string generosCapturados = "";
            for (int i = 0; i < this.CheckBoxListGenerosMusica.Items.Count; i++)
            {
                if (this.CheckBoxListGenerosMusica.Items[i].Selected)
                {
                    cont++;
                    generosCapturados += "<br /> - " + this.CheckBoxListGenerosMusica.Items[i].Text;
                }
            }
            string plataformaCapturada = this.DropDownListPlataformasMusica.SelectedValue;
            if (plataformaCapturada != "-1")
            {
                plataforma += "<span style='font-weight: bold'>Plataforma favorita:</span> " + plataformaCapturada;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Seleccione una plataforma')", true);
            }
            if (cont != 0)
            {
                generos += "<br />"
                + "<span style='font-weight: bold'>Generos preferidos:</span> "
                + generosCapturados;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ningun genero ha sido seleccionado')", true);
            }
            
            this.LabelCapturaPlataforma.Text = plataforma;
            this.LabelCapturaGeneros.Text = generos;
        }
    }
}