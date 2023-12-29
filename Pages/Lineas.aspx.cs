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
    public partial class Lineas : System.Web.UI.Page
    {
        List<DatosLinea> listaLineas = new List<DatosLinea>();
        List<Cliente> listaClientes = new List<Cliente>();
        List<int> listaAnios = new List<int>();
        List<DatosLinea> ListaFiltrada = new List<DatosLinea>();
        public string FiltroSeleccionado { get; set; }
        public int ClienteSeleccionado { get; set; }
        public int AnioSeleccionado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaLinea.aspx");
        }

        protected void dgvLineas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDetalle")
            {
                int IdLinea = Convert.ToInt32(e.CommandArgument.ToString());

                Response.Redirect("DetalleLinea.aspx?id=" + IdLinea);
            }
        }

        private void CargarGrilla()
        {
            if (!IsPostBack)
            {
                DatosLineaNegocio datosLineaNegocio = new DatosLineaNegocio();
                listaLineas = datosLineaNegocio.listarLineas();

                ClienteNegocio clienteNegocio = new ClienteNegocio();
                listaClientes = clienteNegocio.listarClientes();

                List<int> listaFechas = new List<int>();

                foreach (var item in listaLineas)
                {
                    int fecha = item.AnioInspeccionPrevia;
                    listaFechas.Add(fecha);
                }

                listaAnios = listaFechas.GroupBy(fecha => fecha).Select(grupo => grupo.Key).ToList();

                FiltroSeleccionado = Request.QueryString["Filtro"];

                if (Request.QueryString["Cliente"] != null)
                {
                    ClienteSeleccionado = Convert.ToInt32(Request.QueryString["Cliente"]);
                }
                if (Request.QueryString["AnioUltima"] != null)
                {
                    AnioSeleccionado = Convert.ToInt32(Request.QueryString["AnioUltima"]);
                }

                ListItem item0 = new ListItem("--------", "0");
                ListItem item1 = new ListItem("Cliente", "1");
                ListItem item2 = new ListItem("Última inspección", "2");

                DropDownListFiltro.Items.Add(item0);
                DropDownListFiltro.Items.Add(item1);
                DropDownListFiltro.Items.Add(item2);

                ddlClientes.DataSource = listaClientes;
                ddlClientes.DataValueField = "IdCliente";
                ddlClientes.DataTextField = "NombreCliente";
                ddlClientes.DataBind();

                ddlUltimaInspeccion.DataSource = listaAnios;
                ddlUltimaInspeccion.DataBind();

                if (Request.QueryString["Filtro"] != null)
                {
                    if (FiltroSeleccionado == "1")
                    {
                        for (int i = 0; i < listaLineas.Count; i++)
                        {
                            if (listaLineas[i].cliente.IdCliente == ClienteSeleccionado)
                            {
                                ListaFiltrada.Add(listaLineas[i]);
                            }
                        }
                    }
                    else if (FiltroSeleccionado == "2")
                    {
                        for (int i = 0; i < listaLineas.Count; i++)
                        {
                            if (listaLineas[i].AnioInspeccionPrevia == AnioSeleccionado)
                            {
                                ListaFiltrada.Add(listaLineas[i]);
                            }
                        }
                    }

                    dgvLineas.DataSource = ListaFiltrada;
                    dgvLineas.DataBind();
                }
                else
                {
                    dgvLineas.DataSource = listaLineas;
                    dgvLineas.DataBind();
                }
            }
        }

        protected void ButtonFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = DropDownListFiltro.SelectedIndex.ToString();
            string opcion;

            if (DropDownListFiltro.SelectedIndex == 1)
            {
                opcion = ddlClientes.SelectedItem.Value.ToString();

                Response.Redirect("Lineas.aspx?Filtro=" + filtro + "&Cliente=" + opcion, false);
            }
            else if (DropDownListFiltro.SelectedIndex == 2)
            {
                opcion = ddlUltimaInspeccion.SelectedItem.Value.ToString();

                Response.Redirect("Lineas.aspx?Filtro=" + filtro + "&AnioUltima=" + opcion, false);
            }
        }
    }
}