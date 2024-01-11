using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;

namespace QMS.Pages
{
    public partial class AltaContacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            if (!IsPostBack)
            {
                List<Cliente> listaClientes = new List<Cliente>();
                ClienteNegocio clienteNegocio = new ClienteNegocio();

                listaClientes = clienteNegocio.listarClientes();

                ddlCliente.DataSource = listaClientes;
                ddlCliente.DataTextField = "NombreCliente";
                ddlCliente.DataValueField = "IdCliente";
                ddlCliente.DataBind();

                if (Request.QueryString["Id"] != null)
                {
                    ContactoClienteNegocio contactoClienteNegocio = new ContactoClienteNegocio();
                    ContactoCliente contactoCliente = new ContactoCliente();
                    int IdContacto = int.Parse(Request.QueryString["Id"]);

                    contactoCliente = contactoClienteNegocio.buscarContacto(IdContacto);

                    txtNombre.Text = contactoCliente.Nombre;
                    txtApellido.Text = contactoCliente.Apellido;
                    txtTelefono.Text = contactoCliente.Telefono;
                    txtEmail.Text = contactoCliente.Mail;

                    ListItem item = ddlCliente.Items.FindByValue(contactoCliente.cliente.IdCliente.ToString());
                    if (item != null)
                    {
                        item.Selected = true;
                    }

                    btnAgregar.Text = "Guardar cambios";
                    btnAgregar.CssClass = "btn btn-secondary";
                }
                if (Request.QueryString["IdCliente"] != null)
                {
                    int IdCliente = int.Parse(Request.QueryString["IdCliente"]);
                    ListItem item = ddlCliente.Items.FindByValue(IdCliente.ToString());
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ContactoCliente contactoCliente = new ContactoCliente();
                ContactoClienteNegocio contactoClienteNegocio = new ContactoClienteNegocio();

                contactoCliente.cliente = new Cliente();

                contactoCliente.cliente.IdCliente = int.Parse(ddlCliente.SelectedItem.Value);
                contactoCliente.Nombre = txtNombre.Text;
                contactoCliente.Apellido = txtApellido.Text;
                contactoCliente.Telefono = txtTelefono.Text;
                contactoCliente.Mail = txtEmail.Text;

                if (Request.QueryString["Id"] != null)
                {
                    contactoCliente.IdContactoCliente = int.Parse(Request.QueryString["Id"]);
                    contactoClienteNegocio.actualizarContacto(contactoCliente);
                }
                else
                {
                    contactoClienteNegocio.agregarContacto(contactoCliente);
                }
                Response.Redirect("DetalleCliente.aspx?Id=" + contactoCliente.cliente.IdCliente, false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }


        }
    }
}