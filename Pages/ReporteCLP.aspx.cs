using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QMS.Pages
{
    public partial class ReporteCLP : System.Web.UI.Page
    {
        List<Herramienta> listaHerramientas = new List<Herramienta>();
        List<Danio> listaDanio = new List<Danio>();
        List<TipoDeformacion> listaTipoDeformacion = new List<TipoDeformacion>();
        public int IdReporte { get; set; }
        public Reporte Reporte { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (!IsPostBack)
            {
                if (Session["IdReporte"] == null)
                {
                    Response.Redirect("Reportes.aspx");
                }
                else
                {
                    IdReporte = (int)Session["IdReporte"];
                    Reporte reporte = new Reporte();
                    ReporteNegocio reporteNegocio = new ReporteNegocio();

                    HerramientaNegocio herramientaNegocio = new HerramientaNegocio();
                    listaHerramientas = herramientaNegocio.listarHerramientas((int)EnumTipoHerramienta.CLP);

                    Herramienta herramienta = new Herramienta();
                    

                    DanioNegocio danioNegocio = new DanioNegocio();
                    listaDanio = danioNegocio.listarDanio();

                    reporte = reporteNegocio.buscarReporte(IdReporte);
                    lblLinea.Text = reporte.DatosLinea.NombreLinea;

                    Dictionary<string, bool> opciones = new Dictionary<string, bool>
                    {         
                     { "No", false },
                     { "Sí", true }
                    };

                    ddlSensores.DataSource = opciones;
                    ddlSensores.DataTextField = "Key"; // El texto que se mostrará en el DropDownList
                    ddlSensores.DataValueField = "Value"; // El valor asociado al texto
                    ddlSensores.DataBind();

                    ddlHerramienta.DataSource = listaHerramientas;
                    ddlHerramienta.DataTextField = "Nombre";
                    ddlHerramienta.DataValueField = "IdHerramienta";
                    ddlHerramienta.DataBind();

                    ddlDanio.DataSource = listaDanio;
                    ddlDanio.DataTextField = "danio";
                    ddlDanio.DataValueField = "IdDanio";
                    ddlDanio.DataBind();

                    if (ddlHerramienta.Items.Count > 0)
                    {
                        ddlHerramienta.SelectedIndex = 0; // Establece el primer elemento como seleccionado por defecto
                    }
                    /*
                    herramienta = herramientaNegocio.buscarHerramienta(int.Parse(ddlHerramienta.SelectedItem.Value));

                    // Limpia el ListBox antes de agregar nuevos elementos
                    listBoxFlaps.Items.Clear();

                    // Genera dinámicamente los valores desde 1 hasta el valor de la cantidad de sensores
                    for (short i = 1; i <= herramienta.cantSensores; i++)
                    {
                        listBoxFlaps.Items.Add(i.ToString()); // Agrega cada número al ListBox
                    }*/
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int ultimoID = 0;

            try
            {
                IdReporte = (int)Session["IdReporte"];
                Domain.ReporteCLP reporteCLP = new Domain.ReporteCLP();

                ReporteNegocio reporteNegocio = new ReporteNegocio();
                HerramientaNegocio herramientaNegocio = new HerramientaNegocio();

                Reporte reporte = new Reporte();
                reporte = reporteNegocio.buscarReporte(IdReporte);

                reporteCLP.Herramienta = new Herramienta();
                reporteCLP.Herramienta = herramientaNegocio.buscarHerramienta(int.Parse(ddlHerramienta.SelectedItem.Value));
                reporteCLP.DatosLinea = new DatosLinea();
                reporteCLP.DatosLinea.IdLinea = reporte.DatosLinea.IdLinea;
                reporteCLP.Danio = new Danio();
                reporteCLP.Danio.IdDanio = short.Parse(ddlDanio.SelectedItem.Value);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlSensores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSensores.SelectedValue == "false")
            {
                lblFlaps.Visible = true;
                listBoxFlaps.Visible = true;
            }
            else
            {
                lblFlaps.Visible = false;
                listBoxFlaps.Visible = false;
            }
        }

        protected void ddlHerramienta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Herramienta herramienta = new Herramienta();
            HerramientaNegocio herramientaNegocio = new HerramientaNegocio();

            // Limpia el ListBox antes de agregar nuevos elementos
            listBoxFlaps.Items.Clear();

            herramienta = herramientaNegocio.buscarHerramienta(int.Parse(ddlHerramienta.SelectedItem.Value));

            // Genera dinámicamente los valores desde 1 hasta el valor de la cantidad de sensores
            for (short i = 1; i <= herramienta.cantSensores; i++)
            {
                listBoxFlaps.Items.Add(i.ToString()); // Agrega cada número al ListBox
            }
        }
    }
}