using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using DataAccess;
using System.Data;

namespace QMS
{
    public partial class Clientes : System.Web.UI.Page
    {
        List<Cliente> listaClientes = new List<Cliente>();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaCliente.aspx",false);
        }

        private void CargarGrilla()
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            listaClientes = clienteNegocio.listarClientes();

            dgvClientes.DataSource = listaClientes;
            dgvClientes.DataBind();
        }

        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnEditar")
            {
                int IdContactoCliente = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("AltaCliente.aspx?Id=" + IdContactoCliente);
            }
            if (e.CommandName == "btnDetalle")
            {
                int IdContactoCliente = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("DetalleCliente.aspx?Id=" + IdContactoCliente);
            }
            if (e.CommandName == "btnEliminar") {
                int IdContactoCliente = Convert.ToInt32(e.CommandArgument.ToString());

            }
        }

        protected void dgvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnAgregarContacto_Click(object sender, EventArgs e)
        {       
            Response.Redirect("AltaContacto.aspx",false);
        }
    }
}