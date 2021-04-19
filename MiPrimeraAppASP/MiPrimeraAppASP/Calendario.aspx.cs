using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiPrimeraAppASP
{
    public partial class Calendario : System.Web.UI.Page
    {

        protected void btnCalcularDias_Click(object sender, EventArgs e)
        {
            int diaFechaInicial = this.Calendar1.SelectedDate.Day;
            int mesFechaInicial = this.Calendar1.SelectedDate.Month;
            int añoFechaInicial = this.Calendar1.SelectedDate.Year;
            int diaFechaFinal = this.Calendar2.SelectedDate.Day;
            int mesFechaFinal = this.Calendar2.SelectedDate.Month;
            int añoFechaFinal = this.Calendar2.SelectedDate.Year;
            this.Comprobar.Text = "";

            if (añoFechaInicial == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se selecciono fecha inicial. No se puede procesar la solicitud')", true);
            }
            else if (añoFechaFinal == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se selecciono fecha final. No se puede procesar la solicitud')", true);
            }
            else if (añoFechaInicial > añoFechaFinal)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El año de la fecha inicial es mayor al año de la fecha final. No se puede procesar la solicitud')", true);
            }
            else if (añoFechaInicial == añoFechaFinal && mesFechaInicial > mesFechaFinal)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El mes de la fecha inicial es mayor al mes de la fecha final. No se puede procesar la solicitud')", true);
            }
            else if (añoFechaInicial == añoFechaFinal && mesFechaInicial == mesFechaFinal && diaFechaInicial > diaFechaFinal)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El día de la fecha inicial es mayor al día de la fecha final. No se puede procesar la solicitud')", true);
            }
            else
            {
                DateTime FechaInicial = Calendar1.SelectedDate;
                DateTime FechaFinal = Calendar2.SelectedDate;
                this.Comprobar.Text = ((FechaFinal - FechaInicial).TotalDays).ToString() + " día(s) transcurrido(s)";
            }
        }
    }
}