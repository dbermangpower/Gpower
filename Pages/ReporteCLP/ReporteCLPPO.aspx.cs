using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMS.Pages.ReporteCLP
{
    public partial class ReporteCLPPO : System.Web.UI.Page
    {
        public int IdReporte { get; set; }
        public int IdReporteCLP { get; set; }
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
                    //Redirecciona si se accede desde otro lugar
                    Response.Redirect("~/Pages/Reportes.aspx");
                }
                else
                {

                    IdReporte = (int)Session["IdReporte"];
                    IdReporteCLP = (int)Session["IdReporteCLP"];

                    Reporte reporte = new Reporte();
                    ReporteNegocio reporteNegocio = new ReporteNegocio();

                    Domain.ReporteCLP reporteCLP = new Domain.ReporteCLP();
                    ReporteCLPNegocio reporteCLPNegocio = new ReporteCLPNegocio();

                    HerramientaNegocio herramientaNegocio = new HerramientaNegocio();

                    reporte = reporteNegocio.buscarReporte(IdReporte);

                    reporteCLP = reporteCLPNegocio.buscarReporte(IdReporteCLP);

                    lblLinea.Text = reporte.DatosLinea.NombreLinea;

                    //Calculo duración de la inspección
                    TimeSpan diferenciaCLP = reporteCLP.fechaRecepcion - reporteCLP.fechaOperacion;
                    double totalSegundos = diferenciaCLP.TotalSeconds;

                    // Calcular la velocidad promedio en metros por segundo con un decimal
                    decimal velocidadPromedio = (decimal)(reporte.DatosLinea.LargoTuberia * 1000) / (decimal)totalSegundos;

                    // Convertir el resultado a cadena y asignarlo al Label
                    lblVelocidadProm.Text = velocidadPromedio.ToString("#,0.00"); // Muestra el resultado con 2 decimales
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Domain.ReporteCLP reporteCLP = new Domain.ReporteCLP();
                ReporteCLPNegocio reporteCLPNegocio = new ReporteCLPNegocio();

                reporteCLP.IdReporteCLP = (int)Session["IdReporteCLP"];
                reporteCLP.presionLanzador = decimal.Parse(txtPresionLanzador.Text);
                reporteCLP.presionRecibidor = decimal.Parse(txtPresionRecepcion.Text);
                reporteCLP.temperaturaMin = decimal.Parse(txtTemperaturaMax.Text);
                reporteCLP.temperaturaMax = decimal.Parse(txtTemperaturaMax.Text);
                reporteCLP.tasaFlujo = decimal.Parse(txtTasaFlujo.Text);

                reporteCLPNegocio.agregarReporteOP(reporteCLP);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("~/Pages/Error.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Reportes.aspx");
        }

        protected void btnCD_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ReporteCLPCD.aspx");
        }
    }
}