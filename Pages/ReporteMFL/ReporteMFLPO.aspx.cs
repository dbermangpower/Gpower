using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMS.Pages.ReporteMFL
{
    public partial class ReporteMFLPO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            ListItem item0 = new ListItem("bar", "0");
            ListItem item1 = new ListItem("psi", "1");
            ListItem item2 = new ListItem("Mpa", "2");

            ListItem itemT0 = new ListItem("°C", "0");
            ListItem itemT1 = new ListItem("°F", "1");

            ddlUPresionL.Items.Add(item0);
            ddlUPresionL.Items.Add(item1);
            ddlUPresionL.Items.Add(item2);

            ddlUPresionR.Items.Add(item0);
            ddlUPresionR.Items.Add(item1);
            ddlUPresionR.Items.Add(item2);

            ddlUTempMin.Items.Add(itemT0);
            ddlUTempMin.Items.Add(itemT1);

            ddlUTempMax.Items.Add(itemT0);
            ddlUTempMax.Items.Add(itemT1);
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Domain.ReporteMFL reporteMFL = new Domain.ReporteMFL();
                ReporteMFLNegocio reporteMFLNegocio = new ReporteMFLNegocio();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("~/Pages/Error.aspx");
            }
        }

        protected void btnCD_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Reportes.aspx");
        }
    }
}