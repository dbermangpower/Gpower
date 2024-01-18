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
        public bool reporteIMU { get; set; }

        public Reporte reporte = null;
        protected bool reporteBIDI = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] == null)
            {
                Response.Redirect("Reportes.aspx", false);
            }
            cargar();
        }

        private void cargar()
        {
            try
            {
                if (Request.QueryString["Id"] != null)
                {
                    //Capturo el valor de Id del reporte seleccionado
                    IdReporteSeleccionado = Convert.ToInt32(Request.QueryString["Id"]);

                    //Busco el reporte en la base de datos
                    ReporteNegocio reporteNegocio = new ReporteNegocio();
                    reporte = reporteNegocio.buscarReporte(IdReporteSeleccionado);

                    //Verifico si tiene ingresado un reporte BIDI
                    if (reporte.ReporteBIDI != null)
                    {
                        reporteBIDI = true;

                        ReporteBIDINegocio reporteBIDINegocio = new ReporteBIDINegocio();
                        reporte.ReporteBIDI = reporteBIDINegocio.buscarReporte(reporte.ReporteBIDI.IdReporteBIDI);

                        lblHerramienta.Text = reporte.ReporteBIDI.Herramienta.Nombre;
                        lblFechaOperacion.Text = reporte.ReporteBIDI.fechaOperacion.Date.ToString("dd/MM/yyyy");
                        lblHoraOperacion.Text = reporte.ReporteBIDI.fechaOperacion.TimeOfDay.ToString();
                        lblFechaRecepcion.Text = reporte.ReporteBIDI.fechaRecepcion.Date.ToString("dd/MM/yyyy");
                        lblHoraRecepcion.Text = reporte.ReporteBIDI.fechaRecepcion.TimeOfDay.ToString();
                        lblResiduosRecolectados.Text = reporte.ReporteBIDI.residuosRecolectados.ToString();
                        lblMaximaReduccion.Text = reporte.ReporteBIDI.maximaReduccion.ToString();
                        lblDanioPlaca.Text = reporte.ReporteBIDI.danio.danio;
                        if (reporte.ReporteBIDI.danio.IdDanio == 1)
                        {
                            lblTipoDeformacion.Visible = false;
                            lblTipo.Visible = false;
                        }
                        else
                        {
                            lblTipoDeformacion.Text = reporte.ReporteBIDI.TipoDeformacion.tipoDeformacion;
                        }

                        //Calculo de duración
                        TimeSpan diferenciaBIDI = reporte.ReporteBIDI.fechaRecepcion - reporte.ReporteBIDI.fechaOperacion;

                        double totalHoras = diferenciaBIDI.TotalHours;

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
                    if (reporte.TipoInspeccion.IdTipoInspeccion != 1)
                    {
                        if (reporte.ReporteCLP != null)
                        {
                            reporteCLP = true;
                            ReporteCLPNegocio reporteCLPNegocio = new ReporteCLPNegocio();

                            reporte.ReporteCLP = reporteCLPNegocio.buscarReporte(reporte.ReporteCLP.IdReporteCLP);

                            lblHerramientaCLP.Text = reporte.ReporteCLP.Herramienta.Nombre;
                            lblFOCLP.Text = reporte.ReporteCLP.fechaOperacion.Date.ToString("dd/MM/yyyy");
                            lblHOCLP.Text = reporte.ReporteCLP.fechaOperacion.TimeOfDay.ToString();
                            lblFRCLP.Text = reporte.ReporteCLP.fechaRecepcion.Date.ToString("dd/MM/yyyy");
                            lblHRCLP.Text = reporte.ReporteCLP.fechaRecepcion.TimeOfDay.ToString();

                            // ver funcion para automatizar el numero de inspeccion
                            lblNumInspCLP.Text = "1";

                            lblResiduosCLP.Text = reporte.ReporteCLP.residuosRecolectados.ToString();
                            lblDanioCLP.Text = reporte.ReporteCLP.Danio.danio;

                            if (reporte.ReporteCLP.sensoresDaniados == true)
                            {
                                lblSensoresCLPDaniados.Text = "Si";
                                lblSensoresCLP.Text = reporte.ReporteCLP.sensoresD;
                            }
                            else
                            {
                                lblSensoresCLPDaniados.Text = "No";
                                lblSensoresCLP.Visible = false;
                            }
                            if (reporte.ReporteCLP.presionLanzador != 0)
                            {
                                lblPLCLP.Text = reporte.ReporteCLP.presionLanzador.ToString();
                            }
                            if (reporte.ReporteCLP.presionRecibidor != 0)
                            {
                                lblPRCLP.Text = reporte.ReporteCLP.presionRecibidor.ToString();
                            }
                            if (reporte.ReporteCLP.temperaturaMin != 0)
                            {
                                lblTminCLP.Text = reporte.ReporteCLP.temperaturaMin.ToString();
                            }
                            if (reporte.ReporteCLP.temperaturaMax != 0)
                            {
                                lblTmaxCLP.Text = reporte.ReporteCLP.temperaturaMax.ToString();
                            }
                            if (reporte.ReporteCLP.tasaFlujo != 0)
                            {
                                lblFlujoCLP.Text = reporte.ReporteCLP.tasaFlujo.ToString();
                            }

                            //Calculo de duración
                            TimeSpan diferenciaCLP = reporte.ReporteCLP.fechaRecepcion - reporte.ReporteCLP.fechaOperacion;

                            double totalHoras = diferenciaCLP.TotalHours;
                            double totalSegundos = diferenciaCLP.TotalSeconds;

                            int horas = (int)totalHoras; // Obtiene la parte entera (horas)
                            int minutos = (int)((totalHoras - horas) * 60); // Calcula los minutos

                            // Formatea para mostrar en formato "hh:mm"
                            string duracionFormateada = $"{horas:00}:{minutos:00}";

                            // Calcular la velocidad promedio en metros por segundo con un decimal
                            decimal velocidadPromedio = (decimal)(reporte.DatosLinea.LargoTuberia * 1000) / (decimal)totalSegundos;

                            lblDuracionCLP.Text = duracionFormateada; // Asigna al texto del label la duración formateada

                            // Convertir el resultado a cadena y asignarlo al Label
                            lblVelProm.Text = velocidadPromedio.ToString("#,0.00"); // Muestra el resultado con 2 decimales
                        }
                    }
                    if (reporte.TipoInspeccion.IdTipoInspeccion != 2)
                    {
                        if (reporte.ReporteMFL != null)
                        {
                            reporteMFL = true;
                            ReporteMFLNegocio reporteMFLNegocio = new ReporteMFLNegocio();

                            reporte.ReporteMFL = reporteMFLNegocio.buscarReporte(reporte.ReporteMFL.IdReporteMFL);

                            lblHerramientaMFL.Text = reporte.ReporteMFL.Herramienta.Nombre;
                            lblFOMFL.Text = reporte.ReporteMFL.fechaOperacion.Date.ToString("dd/MM/yyyy");
                            lblHOMFL.Text = reporte.ReporteMFL.fechaOperacion.TimeOfDay.ToString();
                            lblFRMFL.Text = reporte.ReporteMFL.fechaRecepcion.Date.ToString("dd/MM/yyyy");
                            lblHRMFL.Text = reporte.ReporteMFL.fechaRecepcion.TimeOfDay.ToString();

                            lblHerramientaMFL.Text = reporte.ReporteMFL.Herramienta.Nombre;


                            //Calculo de duración
                            TimeSpan diferenciaMFL = reporte.ReporteMFL.fechaRecepcion - reporte.ReporteMFL.fechaOperacion;

                            double totalHoras = diferenciaMFL.TotalHours;
                            double totalSegundos = diferenciaMFL.TotalSeconds;

                            int horas = (int)totalHoras; // Obtiene la parte entera (horas)
                            int minutos = (int)((totalHoras - horas) * 60); // Calcula los minutos

                            //Formatea para mostrar en formato "hh:mm"
                            string duracionFormateada = $"{horas:00}:{minutos:00}";

                            // Calcular la velocidad promedio en metros por segundo con un decimal
                            decimal velocidadPromedio = (decimal)(reporte.DatosLinea.LargoTuberia * 1000) / (decimal)totalSegundos;

                            lblDuracionMFL.Text = duracionFormateada; // Asigna al texto del label la duración formateada
                        }
                    }
                    else
                    {
                        reporteMFL = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAgregarBIDI_Click(object sender, EventArgs e)
        {
            Session.Add("IdReporte", IdReporteSeleccionado);
            Response.Redirect("ReporteBIDI.aspx");
        }

        protected void btnAgregarCLP_Click(object sender, EventArgs e)
        {
            Session.Add("IdReporte", IdReporteSeleccionado);
            Response.Redirect("ReporteCLP/ReporteCLPCampo.aspx");
        }

        protected void btnAgregarMFL_Click(object sender, EventArgs e)
        {
            Session.Add("IdReporte", IdReporteSeleccionado);
            Response.Redirect("ReporteMFL/ReporteMFLCampo.aspx");
        }
    }
}