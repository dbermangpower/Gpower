using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using DataAccess;
using System.Globalization;

namespace QMS.Pages
{
    public partial class ReporteBIDI : System.Web.UI.Page
    {
        List<Herramienta> listaHerramientas = new List<Herramienta>();
        List<Danio> listaDanio = new List<Danio>();
        List<TipoDeformacion> listaTipoDeformacion = new List<TipoDeformacion>();
        public int IdReporte {  get; set; }
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
                    listaHerramientas = herramientaNegocio.listarHerramientas((int)EnumTipoHerramienta.BIDI);

                    DanioNegocio danioNegocio = new DanioNegocio();
                    listaDanio = danioNegocio.listarDanio();

                    TipoDeformacionNegocio tipoDeformacion = new TipoDeformacionNegocio();
                    listaTipoDeformacion = tipoDeformacion.listarTipoDeforacion();

                    reporte = reporteNegocio.buscarReporte(IdReporte);
                    lblLinea.Text = reporte.DatosLinea.NombreLinea;

                    ddlHerramienta.DataSource = listaHerramientas;
                    ddlHerramienta.DataTextField = "Nombre";
                    ddlHerramienta.DataValueField = "IdHerramienta";
                    ddlHerramienta.DataBind();

                    ddlDanio.DataSource = listaDanio;
                    ddlDanio.DataTextField = "danio";
                    ddlDanio.DataValueField = "IdDanio";
                    ddlDanio.DataBind();

                    ddlTipoDeformacion.DataSource = listaDanio;
                    ddlTipoDeformacion.DataTextField = "tipoDeformacion";
                    ddlTipoDeformacion.DataValueField = "IdTipoDeformacion";
                    ddlTipoDeformacion.DataBind();
                }
            }          
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int ultimoID = 0;
            
            try
            {
                IdReporte = (int)Session["IdReporte"];
                Domain.ReporteBIDI reporteBIDI = new Domain.ReporteBIDI();
                ReporteBIDINegocio reporteBIDINegocio = new ReporteBIDINegocio();
                ReporteNegocio reporteNegocio = new ReporteNegocio();
                HerramientaNegocio herramientaNegocio = new HerramientaNegocio();       

                Reporte reporte = new Reporte();
                reporte = reporteNegocio.buscarReporte(IdReporte);

                reporteBIDI.Herramienta = new Herramienta();
                reporteBIDI.Herramienta = herramientaNegocio.buscarHerramienta(int.Parse(ddlHerramienta.SelectedItem.Value));
                reporteBIDI.DatosLinea = new DatosLinea();
                reporteBIDI.DatosLinea.IdLinea = reporte.DatosLinea.IdLinea;
                reporteBIDI.danio = new Danio();
                reporteBIDI.danio.IdDanio = short.Parse(ddlDanio.SelectedItem.Value);
                reporteBIDI.TipoDeformacion = new TipoDeformacion();
                reporteBIDI.TipoDeformacion.IdTipoDeformacion = short.Parse(ddlTipoDeformacion.SelectedItem.Value);

                DateTime fechaOperacion = DateTime.ParseExact(txtFechaOperacion.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                DateTime horaOperacion;
                
                if (DateTime.TryParseExact(txtHoraOperacion.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out horaOperacion))
                {
                    reporteBIDI.fechaOperacion = fechaOperacion.Date + horaOperacion.TimeOfDay;
                }
                else
                {

                }

                DateTime fechaRecepcion = DateTime.ParseExact(txtFechaRecepcion.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                DateTime horaRecepcion;

                if (DateTime.TryParseExact(txtHoraRecepcion.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out horaRecepcion))
                {
                    reporteBIDI.fechaRecepcion = fechaRecepcion.Date + horaRecepcion.TimeOfDay;
                }
                else
                {

                }

                reporteBIDI.maximaReduccion = int.Parse(txtReduccionMax.Text);
                reporteBIDI.residuosRecolectados = int.Parse(txtResiduos.Text);

                ultimoID = reporteBIDINegocio.agregarReporte(reporteBIDI);
                reporteNegocio.actualizarReporte(ultimoID, IdReporte, reporteBIDI.Herramienta);
                Session.Clear();
                Response.Redirect("DetalleQMS.aspx?=id" + IdReporte,false);
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
    }
}