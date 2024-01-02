using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;

namespace QMS
{
    public partial class Reportes : System.Web.UI.Page
    {
        List<Reporte> listaReportes = new List<Reporte>();
        List<Cliente> listaClientes = new List<Cliente>();
        List<int> listaAnios = new List<int>();
        List<Reporte> ListaFiltrada = new List<Reporte>();
        public string FiltroSeleccionado { get; set; }
        public int ClienteSeleccionado { get; set; }
        public int AnioSeleccionado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void dgvReportes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDetalle")
            {
                int IdReporte = Convert.ToInt32(e.CommandArgument.ToString());
                ReporteNegocio reporteNegocio = new ReporteNegocio();
                Reporte aux = reporteNegocio.buscarReporte(IdReporte);
                Session["TipoReporte"] = aux.TipoInspeccion.IdTipoInspeccion;
                Response.Redirect("DetalleQMS.aspx?id=" + IdReporte);
            }
        }

        protected void dgvReportes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ButtonFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = DropDownListFiltro.SelectedIndex.ToString();
            string opcion;

            if (DropDownListFiltro.SelectedIndex == 1)
            {
                opcion = ddlClientes.SelectedItem.Value.ToString();

                Response.Redirect("Reportes.aspx?Filtro=" + filtro + "&Cliente=" + opcion, false);
            }
            else if (DropDownListFiltro.SelectedIndex == 2)
            {
                opcion = ddlAnio.SelectedItem.Value.ToString();

                Response.Redirect("Reportes.aspx?Filtro=" + filtro + "&Anio=" + opcion, false);
            }
        }

        private void CargarGrilla()
        {
            if (!IsPostBack)
            {

                //Agrega opciones de filtro
                ListItem item0 = new ListItem("--------", "0");
                ListItem item1 = new ListItem("Cliente", "1");
                ListItem item2 = new ListItem("Año", "2");

                DropDownListFiltro.Items.Add(item0);
                DropDownListFiltro.Items.Add(item1);
                DropDownListFiltro.Items.Add(item2);

                //Listado de reportes
                ReporteNegocio reporteNegocio = new ReporteNegocio();
                listaReportes = reporteNegocio.listarReportes();

                dgvReportes.DataSource = listaReportes;
                dgvReportes.DataBind();

                //Listado de clientes para filtro
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                listaClientes = clienteNegocio.listarClientes();

                ddlClientes.DataSource = listaClientes;
                ddlClientes.DataValueField = "IdCliente";
                ddlClientes.DataTextField = "NombreCliente";
                ddlClientes.DataBind();

                //Listado de años de reportes realizados
                List<int> listaFechas = new List<int>();

                foreach (var item in listaReportes)
                {
                    int fecha = item.FechaCreacion.Year;
                    listaFechas.Add(fecha);
                }

                listaAnios = listaFechas.GroupBy(fecha => fecha).Select(grupo => grupo.Key).ToList();

                ddlAnio.DataSource = listaAnios;
                ddlAnio.DataBind();

                //Captura datos de filtro si es utilizado
                FiltroSeleccionado = Request.QueryString["Filtro"];

                if (Request.QueryString["Cliente"] != null)
                {
                    ClienteSeleccionado = Convert.ToInt32(Request.QueryString["Cliente"]);
                }
                if (Request.QueryString["Anio"] != null)
                {
                    AnioSeleccionado = Convert.ToInt32(Request.QueryString["Anio"]);
                }

                if (Request.QueryString["Filtro"] != null)
                {
                    if (FiltroSeleccionado == "1")
                    {
                        for (int i = 0; i < listaReportes.Count; i++)
                        {
                            if (listaReportes[i].DatosLinea.cliente.IdCliente == ClienteSeleccionado)
                            {
                                ListaFiltrada.Add(listaReportes[i]);
                            }
                        }
                    }
                    else if (FiltroSeleccionado == "2")
                    {
                        for (int i = 0; i < listaReportes.Count; i++)
                        {
                            if (listaReportes[i].FechaCreacion.Year == AnioSeleccionado)
                            {
                                ListaFiltrada.Add(listaReportes[i]);
                            }
                        }
                    }

                    dgvReportes.DataSource = ListaFiltrada;
                    dgvReportes.DataBind();
                }

            }
        }

        protected void btnAgregarReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaReporte.aspx", false);
        }
    }
}