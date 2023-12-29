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
    public partial class DetalleQMS : System.Web.UI.Page
    {
        public int IdReporteSeleccionado { get; set; }
        public bool reporteMFL { get; set; }
        public bool reporteCLP { get; set; }

        public Reporte reporte = null;
        protected bool reporteBIDI = false;
        public Domain.ReporteBIDI ReporteBIDIDatos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            try
            {
                if(Request.QueryString["id"] != null)
                {
                    IdReporteSeleccionado = Convert.ToInt32(Request.QueryString["Id"]);
                    //int IdReporteBIDISeleccionado = Convert.ToInt32(Request.QueryString["IdBIDI"]);
                    ReporteNegocio reporteNegocio = new ReporteNegocio();

                    reporte = reporteNegocio.buscarReporte(IdReporteSeleccionado);

                    if(reporte.ReporteBIDI != null)
                    {
                        reporteBIDI = true;

                        ReporteBIDINegocio reporteBIDINegocio = new ReporteBIDINegocio();
                        ReporteBIDIDatos = new Domain.ReporteBIDI();

                        ReporteBIDIDatos = reporteBIDINegocio.buscarReporte(reporte.ReporteBIDI.IdReporteBIDI);

                        lblHerramienta.Text = ReporteBIDIDatos.Herramienta.Nombre;
                        lblFechaOperacion.Text = ReporteBIDIDatos.fechaOperacion.Date.ToString("dd/MM/yyyy");
                        lblHoraOperacion.Text = ReporteBIDIDatos.fechaOperacion.TimeOfDay.ToString();
                        lblFechaRecepcion.Text = ReporteBIDIDatos.fechaRecepcion.Date.ToString("dd/MM/yyyy");
                        lblHoraRecepcion.Text = ReporteBIDIDatos.fechaRecepcion.TimeOfDay.ToString();
                        lblResiduosRecolectados.Text = ReporteBIDIDatos.residuosRecolectados.ToString();
                        lblMaximaReduccion.Text = ReporteBIDIDatos.maximaReduccion.ToString();
                        lblDanioPlaca.Text = ReporteBIDIDatos.danio.danio;
                        if(ReporteBIDIDatos.danio.IdDanio == 1)
                        {
                            lblTipoDeformacion.Visible = false;
                            lblTipo.Visible = false;
                        } else
                        {
                            lblTipoDeformacion.Text = ReporteBIDIDatos.TipoDeformacion.tipoDeformacion;
                        }

                        //Calculo de duración
                        TimeSpan diferencia = ReporteBIDIDatos.fechaRecepcion - ReporteBIDIDatos.fechaOperacion;

                        double totalHoras = diferencia.TotalHours;

                        int horas = (int)totalHoras; // Obtiene la parte entera (horas)
                        int minutos = (int)((totalHoras - horas) * 60); // Calcula los minutos

                        // Formatea para mostrar en formato "hh:mm"
                        string duracionFormateada = $"{horas:00}:{minutos:00}";

                        lblDuracion.Text = duracionFormateada; // Asigna al texto del label la duración formateada

                    }
                    else
                    {
                        reporteBIDI = false;
                    }
                }
            }

            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregarBIDI_Click(object sender, EventArgs e)
        {
            Session.Add("IdReporte", IdReporteSeleccionado);
            Response.Redirect("ReporteBIDI.aspx");
        }
    }
}