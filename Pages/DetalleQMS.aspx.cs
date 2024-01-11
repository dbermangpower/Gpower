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
                if(Request.QueryString["Id"] != null)
                {
                    //Capturo el valor de Id del reporte seleccionado
                    IdReporteSeleccionado = Convert.ToInt32(Request.QueryString["Id"]);

                    //Busco el reporte en la base de datos
                    ReporteNegocio reporteNegocio = new ReporteNegocio();
                    reporte = reporteNegocio.buscarReporte(IdReporteSeleccionado);

                    //Verifico si tiene ingresado un reporte BIDI
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
                        TimeSpan diferenciaBIDI = ReporteBIDIDatos.fechaRecepcion - ReporteBIDIDatos.fechaOperacion;

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
                    if(reporte.TipoInspeccion.IdTipoInspeccion != 1)
                    {
                        if(reporte.ReporteCLP != null)
                        {
                            reporteCLP = true;

                            Domain.ReporteCLP repCLP = new Domain.ReporteCLP();
                            ReporteCLPNegocio reporteCLPnegocio = new ReporteCLPNegocio();

                            //Busco los datos almacenados en la BD del reporte
                            repCLP = reporteCLPnegocio.buscarReporte(reporte.ReporteCLP.IdReporteCLP);
                            lblHerramientaCLP.Text = repCLP.Herramienta.Nombre;
                            lblFOCLP.Text = repCLP.fechaOperacion.Date.ToString("dd/MM/yyyy");
                            lblHOCLP.Text = repCLP.fechaOperacion.TimeOfDay.ToString();
                            lblFRCLP.Text = repCLP.fechaRecepcion.Date.ToString("dd/MM/yyyy");
                            lblHRCLP.Text = repCLP.fechaRecepcion.TimeOfDay.ToString();

                            // ver funcion para automatizar el numero de inspeccion
                            lblNumInspCLP.Text = "1";

                            lblResiduosCLP.Text = repCLP.residuosRecolectados.ToString();
                            lblDanioCLP.Text = repCLP.Danio.danio;

                            if(repCLP.sensoresDaniados == true)
                            {
                                lblSensoresCLPDaniados.Text = "Si";
                                lblSensoresCLP.Text = repCLP.sensoresD;
                            } else
                            {
                                lblSensoresCLPDaniados.Text = "No";
                                lblSensoresCLP.Visible = false;
                            }
                            if (repCLP.presionLanzador != 0)
                            {
                                lblPLCLP.Text = repCLP.presionLanzador.ToString();
                            }
                            if (repCLP.presionRecibidor != 0)
                            {
                                lblPRCLP.Text = repCLP.presionRecibidor.ToString();
                            }
                            if (repCLP.temperaturaMin != 0)
                            {
                                lblTminCLP.Text = repCLP.temperaturaMin.ToString();
                            }
                            if (repCLP.temperaturaMax != 0)
                            {
                                lblTmaxCLP.Text = repCLP.temperaturaMax.ToString();
                            }
                            if (repCLP.tasaFlujo != 0)
                            {
                                lblFlujoCLP.Text = repCLP.tasaFlujo.ToString();
                            }

                            //Calculo de duración
                            TimeSpan diferenciaCLP = repCLP.fechaRecepcion - repCLP.fechaOperacion;

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
                        if(reporte.ReporteMFL != null)
                        {
                            reporteMFL = true;

                            /* Domain.ReporteMFL repMFL = new Domain.ReporteMFL();
                             ReporteMFLNegocio reporteMFLNegocio = new ReporteMFLNegocio();

                             repMFL = reporteMFLNegocio.buscarReporte(reporte.ReporteMFL.IdReporteMFL);

                             lblHerramientaMFL.Text = repMFL.Herramienta.Nombre;
                             lblFOMFL.Text = repMFL.fechaOperacion.Date.ToString("dd/MM/yyyy");
                             lblHOMFL.Text = repMFL.fechaOperacion.TimeOfDay.ToString();
                             lblFRMFL.Text = repMFL.fechaRecepcion.Date.ToString("dd/MM/yyyy");
                             lblHRMFL.Text = repMFL.fechaRecepcion.TimeOfDay.ToString();
                            */

                            lblHerramientaMFL.Text = reporte.ReporteMFL.Herramienta.Nombre;
                            //lblFOMFL.Text = reporte.ReporteMFL.fechaOperacion.Date.ToString("dd/MM/yyyy");
                           // lblHOMFL.Text = reporte.ReporteMFL.fechaOperacion.TimeOfDay.ToString();
                            //lblFRMFL.Text = reporte.ReporteMFL.fechaRecepcion.Date.ToString("dd/MM/yyyy");
                            //lblHRMFL.Text = reporte.ReporteMFL.fechaRecepcion.TimeOfDay.ToString();

                            //Calculo de duración
                            //TimeSpan diferenciaMFL = reporte.ReporteMFL.fechaRecepcion - reporte.ReporteMFL.fechaOperacion;

                          //  double totalHoras = diferenciaMFL.TotalHours;
                           // double totalSegundos = diferenciaMFL.TotalSeconds;

                            //int horas = (int)totalHoras; // Obtiene la parte entera (horas)
                          //  int minutos = (int)((totalHoras - horas) * 60); // Calcula los minutos

                            // Formatea para mostrar en formato "hh:mm"
                          //  string duracionFormateada = $"{horas:00}:{minutos:00}";

                            // Calcular la velocidad promedio en metros por segundo con un decimal
                         //   decimal velocidadPromedio = (decimal)(reporte.DatosLinea.LargoTuberia * 1000) / (decimal)totalSegundos;

                          //  lblDuracionMFL.Text = duracionFormateada; // Asigna al texto del label la duración formateada
                        }
                    } else
                    {
                        reporteMFL = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx",false);
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