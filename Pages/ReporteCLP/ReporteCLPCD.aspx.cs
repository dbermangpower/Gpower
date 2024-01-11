using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMS.Pages.ReporteCLP
{
    public partial class ReporteCLPCD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Reportes.aspx");
        }
    }
}