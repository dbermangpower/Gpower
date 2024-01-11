using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
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

                // Generar los meses dinámicamente
                for (int i = 1; i <= 12; i++)
                {
                    ddlMes.Items.Add(new ListItem(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i), i.ToString()));
                }

                // Generar los años dinámicamente (por ejemplo, desde 2000 hasta 2050)
                int anioActual = DateTime.Now.Year;
                for (int i = anioActual; i <= anioActual + 30; i++)
                {
                    ddlAnio.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                //Selecciona por default el mes y año en curso
                int mesActual = DateTime.Now.Month;
                anioActual = DateTime.Now.Year;

                ddlMes.SelectedValue = mesActual.ToString();
                ddlAnio.SelectedValue = anioActual.ToString();
                
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
                if (cbIMU.Checked)
                {
                    //reporte.ReporteIMU = true;
                } else
                {
                    //reporte.IMU = false;
                }

                int mesSeleccionado = Convert.ToInt32(ddlMes.SelectedValue);
                int anioSeleccionado = Convert.ToInt32(ddlAnio.SelectedValue);

                reporte.FechaInspeccion = new DateTime(anioSeleccionado, mesSeleccionado, 1);

                reporteNegocio.agregarReporte(reporte);
                Response.Redirect("Reportes.aspx",false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx",false);
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