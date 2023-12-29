using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QMS
{
    public partial class AltaReporte : System.Web.UI.Page
    {
        List<TipoInspeccion> listaTipoInspeccion = new List<TipoInspeccion>();
        List<Cliente> listaClientes = new List<Cliente>();
        List<DatosLinea> listaLineas = new List<DatosLinea>();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarListas();
        }

        private void CargarListas()
        {
            if (!IsPostBack)
            {
                //Lista los tipos de inspeccion
                TipoInspeccionNegocio tipoInspeccionNegocio = new TipoInspeccionNegocio();
                listaTipoInspeccion = tipoInspeccionNegocio.listarTipoInspeccion();

                rdbTipoInspeccion.DataSource = listaTipoInspeccion;
                rdbTipoInspeccion.DataValueField = "IdTipoInspeccion";
                rdbTipoInspeccion.DataTextField = "tipoInspeccion";
                rdbTipoInspeccion.DataBind();

                //Lista los clientes dados de alta
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                listaClientes = clienteNegocio.listarClientes();

                ddlClente.DataSource = listaClientes;
                ddlClente.DataValueField = "IdCliente";
                ddlClente.DataTextField = "NombreCliente";
                ddlClente.DataBind();


                DatosLineaNegocio datosLineaNegocio = new DatosLineaNegocio();
                listaLineas = datosLineaNegocio.listarLineas();

                List<DatosLinea> listaFiltrada = listaLineas.Where(linea => linea.cliente.IdCliente == int.Parse(ddlClente.SelectedItem.Value)).ToList();

                ddlLinea.DataSource = listaFiltrada;
                ddlLinea.DataValueField = "IdLinea";
                ddlLinea.DataTextField = "NombreLinea";
                ddlLinea.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            ReporteNegocio reporteNegocio = new ReporteNegocio();
            try
            {
                reporte.DatosLinea = new DatosLinea();
                reporte.DatosLinea.IdLinea = int.Parse(ddlLinea.SelectedItem.Value);
                reporte.TipoInspeccion = new TipoInspeccion();
                reporte.TipoInspeccion.IdTipoInspeccion = short.Parse(rdbTipoInspeccion.SelectedItem.Value);
                
                reporteNegocio.agregarReporte(reporte);
                Response.Redirect("Reportes.aspx",false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void ddlClente_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatosLineaNegocio datosLineaNegocio = new DatosLineaNegocio();
            listaLineas= datosLineaNegocio.listarLineas();

            int idClienteSeleccionado = int.Parse(ddlClente.SelectedItem.Value);

            List<DatosLinea> listaFiltrada = listaLineas.Where(linea => linea.cliente.IdCliente == idClienteSeleccionado).ToList();

            ddlLinea.DataSource = listaFiltrada;
            ddlLinea.DataValueField = "IdLinea";
            ddlLinea.DataTextField = "NombreLinea";
            ddlLinea.DataBind();
        }
    }
}