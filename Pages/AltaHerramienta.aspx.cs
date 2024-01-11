using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMS.Pages
{
    public partial class AltaHerramienta : System.Web.UI.Page
    {
        List<TipoHerramienta> listaTipoHerramientas = new List<TipoHerramienta>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar();
                OcultarMostrarTxtCantSensores();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                HerramientaNegocio herramientaNegocio = new HerramientaNegocio();

                Herramienta herramienta = new Herramienta();
                herramienta.tipoHerramienta = new TipoHerramienta();

                herramienta.tipoHerramienta.IdTipoHerramienta = int.Parse(ddlTipoHerramienta.SelectedItem.Value);

                herramienta.Nombre = txtNombreHerramienta.Text;

                if (short.TryParse(txtDiametro.Text, out short valorDiametro))
                {
                    herramienta.Diametro = valorDiametro;
                }

                if (short.TryParse(txtCantSensores.Text, out short cantSensores))
                {
                    herramienta.cantSensores = cantSensores;
                }

                //Verifica que no exista otra herramienta con el mismo nombre
                if (Request.QueryString["Id"] != null)
                {
                    int IdHerramienta = int.Parse(Request.QueryString["Id"]);
                    herramienta.IdHerramienta = IdHerramienta;

                    if (herramientaNegocio.validarCambioNombre(txtNombreHerramienta.Text, IdHerramienta) == false){
                        herramientaNegocio.actualizarHerramienta(herramienta);
                    } else
                    {
                        lblError.Text = "Ya existe una herramienta con el mismo nombre.";
                        lblError.Visible = true;
                    }
                }
                else if (herramientaNegocio.validarNombre(txtNombreHerramienta.Text) == false)
                {
                    
                    herramientaNegocio.altaHerramienta(herramienta);

                    Response.Redirect("Herramientas.aspx", false);
                }
                else
                {
                    lblError.Text = "Ya existe una herramienta con el mismo nombre.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx",false);
            }
        }

        private void cargar()
        {

            // Lista los tipos de herramienta solo si no es un postback
            foreach (EnumTipoHerramienta tipoEnum in Enum.GetValues(typeof(EnumTipoHerramienta)))
            {
                TipoHerramienta herramienta = new TipoHerramienta
                {
                    IdTipoHerramienta = (int)tipoEnum,
                    tipoHerramienta = tipoEnum.ToString()
                };

                listaTipoHerramientas.Add(herramienta);
            }

            // Carga los tipos de herramienta al DropDownList
            ddlTipoHerramienta.DataSource = listaTipoHerramientas;
            ddlTipoHerramienta.DataTextField = "tipoHerramienta";
            ddlTipoHerramienta.DataValueField = "IdTipoHerramienta";
            ddlTipoHerramienta.DataBind();

            if (Request.QueryString["Id"] != null)
            {
                int IdHerramienta = int.Parse(Request.QueryString["Id"]);
                HerramientaNegocio herramientaNegocio = new HerramientaNegocio();
                Herramienta herramienta = new Herramienta();

                herramienta = herramientaNegocio.buscarHerramienta(IdHerramienta);

                //Completa el contenido de los textbox si se pone editar
                txtNombreHerramienta.Text = herramienta.Nombre;
                txtDiametro.Text = herramienta.Diametro.ToString();
                txtCantSensores.Text = herramienta.cantSensores.ToString();

                // Encuentra el ListItem por valor y lo selecciona en el DropDownList
                ListItem item = ddlTipoHerramienta.Items.FindByValue(herramienta.tipoHerramienta.IdTipoHerramienta.ToString());
                if (item != null)
                {
                    item.Selected = true;
                }

                btnAgregar.Text = "Guardar cambios";
            }
        }

        protected void ddlTipoHerramienta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoHerramienta.SelectedValue == "1")
            {
                txtCantSensores.Visible = false;
            }
            else
            {
                txtCantSensores.Visible = true;
            }
        }

        private void OcultarMostrarTxtCantSensores()
        {
            if (ddlTipoHerramienta.SelectedValue == "1")
            {
                txtCantSensores.Visible = false;
            }
            else
            {
                txtCantSensores.Visible = true;
            }
        }
    }
}