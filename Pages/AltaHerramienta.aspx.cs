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

                herramientaNegocio.altaHerramienta(herramienta);
                Response.Redirect("Herramientas.aspx",false);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
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
        }
    }
}