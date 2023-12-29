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
               /* if (Session["IdReporte"] == null)
                {
                    Response.Redirect("Reportes.aspx");
                }
                else
                {*/
                   // IdReporte = (int)Session["IdReporte"];
                    Reporte reporte = new Reporte();
                    ReporteNegocio reporteNegocio = new ReporteNegocio();

                    HerramientaNegocio herramientaNegocio = new HerramientaNegocio();
                    listaHerramientas = herramientaNegocio.listarHerramientas((int)EnumTipoHerramienta.BIDI);

                    DanioNegocio danioNegocio = new DanioNegocio();
                    listaDanio = danioNegocio.listarDanio();

                    TipoDeformacionNegocio tipoDeformacion = new TipoDeformacionNegocio();
                    listaTipoDeformacion = tipoDeformacion.listarTipoDeforacion();

                    //reporte = reporteNegocio.buscarReporte(IdReporte);
                    //lblLinea.Text = reporte.DatosLinea.NombreLinea;

                    ddlHerramienta.DataSource = listaHerramientas;
                    ddlHerramienta.DataTextField = "Nombre";
                    ddlHerramienta.DataValueField = "IdHerramienta";
                    ddlHerramienta.DataBind();

                    ddlDanio.DataSource = listaDanio;
                    ddlDanio.DataTextField = "danio";
                    ddlDanio.DataValueField = "IdDanio";
                    ddlDanio.DataBind();

                    ddlTipoDeformacion.DataSource = listaTipoDeformacion;
                    ddlTipoDeformacion.DataTextField = "tipoDeformacion";
                    ddlTipoDeformacion.DataValueField = "IdTipoDeformacion";
                    ddlTipoDeformacion.DataBind();
                /*}*/
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}