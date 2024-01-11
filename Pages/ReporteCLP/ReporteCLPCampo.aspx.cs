using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QMS.Pages.ReporteCLP
{
    public partial class ReporteCLPCampo : System.Web.UI.Page
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
                    Response.Redirect("~/Pages/Reportes.aspx");
                }
                else
                {
                    btnPO.Visible = false;

                    IdReporte = (int)Session["IdReporte"];
                    Reporte reporte = new Reporte();
                    ReporteNegocio reporteNegocio = new ReporteNegocio();

                    HerramientaNegocio herramientaNegocio = new HerramientaNegocio();
                    listaHerramientas = herramientaNegocio.listarHerramientas((int)EnumTipoHerramienta.CLP);

                    Herramienta herramienta = new Herramienta();

                    DanioNegocio danioNegocio = new DanioNegocio();
                    listaDanio = danioNegocio.listarDanio();

                    //Busca datos del reporte
                    reporte = reporteNegocio.buscarReporte(IdReporte);
                    lblLinea.Text = reporte.DatosLinea.NombreLinea;

                    ListItem item0 = new ListItem("No", "0");
                    ListItem item1 = new ListItem("Si", "1");

                    ddlSensores.Items.Add(item0);
                    ddlSensores.Items.Add(item1);

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
                    if (ddlSensores.SelectedValue == "0")
                    {
                        chkbFlaps.Visible = false;
                        lblFlaps.Visible = false;
                    }

                    herramienta = herramientaNegocio.buscarHerramienta(int.Parse(ddlHerramienta.SelectedItem.Value));

                    // Limpia el Checkbox list antes de agregar nuevos elementos
                    chkbFlaps.Items.Clear();

                    // Genera dinámicamente los valores desde 1 hasta el valor de la cantidad de sensores
                    for (short i = 1; i <= herramienta.cantSensores; i++)
                    {
                        chkbFlaps.Items.Add(i.ToString()); // Agrega cada número al Checkbox List
                    }
                    int numItems = chkbFlaps.Items.Count;
                    if (numItems > 5)
                    {
                        chkbFlaps.Style["column-count"] = "2";
                        chkbFlaps.Style["column-gap"] = "10px";
                    }
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
                ReporteCLPNegocio reporteCLPNegocio = new ReporteCLPNegocio();

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
                reporteCLP.residuosRecolectados = int.Parse(txtResiduos.Text);
                DateTime fechaOperacion = DateTime.ParseExact(txtFechaOperacion.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                DateTime horaOperacion;

                if (DateTime.TryParseExact(txtHoraOperacion.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out horaOperacion))
                {
                    reporteCLP.fechaOperacion = fechaOperacion.Date + horaOperacion.TimeOfDay;
                }
                else
                {

                }

                DateTime fechaRecepcion = DateTime.ParseExact(txtFechaRecepcion.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                DateTime horaRecepcion;

                if (DateTime.TryParseExact(txtHoraRecepcion.Text, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out horaRecepcion))
                {
                    reporteCLP.fechaRecepcion = fechaRecepcion.Date + horaRecepcion.TimeOfDay;
                }
                else
                {

                }

                string valoresSeleccionados = "";

                // Almaceno en valoresSeleccionados todos los sensores seleccionados    
                foreach (ListItem item in chkbFlaps.Items)
                {
                    if (item.Selected)
                    {
                        valoresSeleccionados += item.Text + ";"; 
                    }
                }

                reporteCLP.sensoresD = valoresSeleccionados;
                ultimoID = reporteCLPNegocio.agregarReporteCampo(reporteCLP);
                reporteNegocio.actualizarReporte(ultimoID, IdReporte,reporteCLP.Herramienta);

                Session.Add("IdReporteCLP", ultimoID);
                btnAceptar.Visible = false;
                btnVolver.Visible = true;
                btnPO.Visible = true;
                btnCancelar.Visible = false;

                
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
            Response.Redirect("~/Pages/Reportes.aspx");
        }

        protected void ddlSensores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSensores.SelectedValue == "1")
            {
                lblFlaps.Visible = true;
                chkbFlaps.Visible = true;
            }
            else
            {
                lblFlaps.Visible = false;
                chkbFlaps.Visible = false;
            }
        }

        protected void ddlHerramienta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Herramienta herramienta = new Herramienta();
            HerramientaNegocio herramientaNegocio = new HerramientaNegocio();

            // Limpia el chkbFlaps antes de agregar nuevos elementos
            chkbFlaps.Items.Clear();

            herramienta = herramientaNegocio.buscarHerramienta(int.Parse(ddlHerramienta.SelectedItem.Value));

            // Genera dinámicamente los valores desde 1 hasta el valor de la cantidad de sensores
            for (short i = 1; i <= herramienta.cantSensores; i++)
            {
                chkbFlaps.Items.Add(i.ToString()); // Agrega cada número al ListBox
            }
        }

        protected void btnPO_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReporteCLPPO.aspx", false);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Reportes.aspx", false);
        }
    }
}