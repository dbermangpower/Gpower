using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace QMS
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            List<Reporte> reportes = new List<Reporte>();
            ReporteNegocio reporteNegocio = new ReporteNegocio();

            reportes = reporteNegocio.listarReportes();

            Reporte proximaInspeccion = reportes
                .Where(r => r.FechaInspeccion > DateTime.Now)
                .OrderBy(r => r.FechaInspeccion)
                .FirstOrDefault();

            lblClienteProx.Text = proximaInspeccion.DatosLinea.cliente.NombreCliente;
            lblLineaProx.Text = proximaInspeccion.DatosLinea.NombreLinea;
            lblFechaProx.Text = proximaInspeccion.FechaInspeccion.Date.ToString("dd/MM/yyyy");

            // Agrega el ID de la próxima inspección como un atributo al botón
            btnDetalles.Attributes["data-idInspeccion"] = proximaInspeccion.IdReporte.ToString();

            // Filtra los reportes para obtener solo los del año en curso
            int añoActual = DateTime.Now.Year;

            var reportesAñoActual = reportes.Where(r => r.FechaInspeccion.Year == añoActual).ToList();

            // Agrupa los reportes por el nombre del cliente y cuenta la cantidad de reportes para cada cliente
            var datosGrafico = reportesAñoActual.GroupBy(r => r.DatosLinea.cliente.NombreCliente)
                                               .Select(g => new { Cliente = g.Key, CantidadReportes = g.Count() })
                                               .ToList();

            foreach (var dato in datosGrafico)
            {
                // Agrega un nuevo DataPoint con el valor del eje X y el valor del eje Y
                DataPoint dataPoint = new DataPoint();
                dataPoint.AxisLabel = dato.Cliente;  // Nombre del cliente en el eje X
                dataPoint.YValues = new double[] { dato.CantidadReportes };  // Cantidad de reportes en el eje Y

                // Agrega el DataPoint a la serie del Chart
                ChartClientes.Series["Series1"].Points.Add(dataPoint);
            }

            lblCantInspecciones.Text = reportesAñoActual.Count.ToString();


        }
        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            // Obtiene el ID de la próxima inspección del atributo del botón
            string idInspeccion = btnDetalles.Attributes["data-idInspeccion"];


            // Obtiene el objeto proximaInspeccion correspondiente al ID obtenido
            ReporteNegocio reporteNegocio = new ReporteNegocio();
            Reporte proximaInspeccion = reporteNegocio.buscarReporte(Convert.ToInt32(idInspeccion));


            // Verifica que el ID sea válido (puedes realizar validaciones adicionales aquí)
            if (!string.IsNullOrEmpty(idInspeccion))
            {
                // Realiza la redirección a otro sitio pasando el ID como parámetro
                Session["TipoReporte"] = proximaInspeccion.TipoInspeccion.IdTipoInspeccion;
                Response.Redirect("Pages/DetalleQMS.aspx?Id=" + idInspeccion);
            }
            else
            {
                // Maneja la situación en la que no se pueda obtener el ID
                // Puedes mostrar un mensaje de error, redirigir a una página de error, etc.
            }
        }
    }  
}