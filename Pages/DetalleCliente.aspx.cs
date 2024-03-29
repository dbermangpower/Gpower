﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using Domain;

namespace QMS.Pages
{
    public partial class DetalleCliente : System.Web.UI.Page
    {
        List<ContactoCliente> listaContactos = new List<ContactoCliente>();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            if (Request.QueryString["Id"] != null)
            {
                int IdCliente = Convert.ToInt32(Request.QueryString["Id"]);
                Cliente cliente = new Cliente();
                ClienteNegocio clienteNegocio = new ClienteNegocio();

                List<Reporte> reportes = new List<Reporte>();
                ReporteNegocio reporteNegocio = new ReporteNegocio();

                reportes = reporteNegocio.listarReportesCliente(IdCliente);
                int cantInspeccionesAño = 0;
                DateTime fecha = DateTime.Now;
                DateTime fechaUltimaInsp = DateTime.Now;
                //string ultimaInspeccion = "Sin información";
                //string proximaInspeccion = "No hay inpsección confirmada para el cliente.";

                // Obtengo la última inspección
                Reporte ultimaInspeccion = reportes
                    .Where(r => r.FechaInspeccion <= DateTime.Now)
                    .OrderByDescending(r => r.FechaInspeccion)
                    .FirstOrDefault();

                // Obtengo la próxima inspección
                Reporte proximaInspeccion = reportes
                    .Where(r => r.FechaInspeccion > DateTime.Now)
                    .OrderBy(r => r.FechaInspeccion)
                    .FirstOrDefault();

                foreach (Reporte reporte in reportes)
                {
                    if(reporte.FechaInspeccion.Year == DateTime.Now.Year)
                    {
                        cantInspeccionesAño++;
                    }
                }

                cliente = clienteNegocio.obtenerCliente(IdCliente);

                lblNombreCliente.Text = cliente.NombreCliente;
                if (ultimaInspeccion != null)
                {
                    lblUltimaInsp.Text = ultimaInspeccion.DatosLinea.NombreLinea;
                }
                if (proximaInspeccion != null)
                {
                    lblProxInsp.Text = proximaInspeccion.DatosLinea.NombreLinea;
                }
                
                // Convertir la imagen a Base64
                string base64String = Convert.ToBase64String(cliente.Logo);
                string fileExtension = cliente.ExtensionLogo;

                imgLogo.ImageUrl = "data:image/" + fileExtension + ";base64," + base64String;
                imgLogo.Visible = true;

                ContactoCliente contacto = new ContactoCliente();
                ContactoClienteNegocio contactoClienteNegocio = new ContactoClienteNegocio();

                listaContactos = contactoClienteNegocio.listarPorCliente(IdCliente);
                lblCantInspecciones.Text = cantInspeccionesAño.ToString();
                dgvContactos.DataSource = listaContactos;
                dgvContactos.DataBind();
                if(listaContactos.Count == 0)
                {
                    lblContactos.Visible = true;
                }
            } else
            {
                Response.Redirect("Clientes.aspx", false);
            }

        }

        protected void dgvContactos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void dgvContactos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnEditar")
            {
                int IdCliente = Convert.ToInt32(e.CommandArgument.ToString());

                Response.Redirect("AltaContacto.aspx?id=" + IdCliente);
            }
            if (e.CommandName == "btnEliminar")
            {
                int IdCliente = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("DetalleCliente.aspx?Id=" + IdCliente);
            }
        }

        protected void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            int IdCliente = Convert.ToInt32(Request.QueryString["Id"]);
            Response.Redirect("AltaContacto.aspx?IdCliente=" + IdCliente);
        }

        protected void btnEditarCliente_Click(object sender, EventArgs e)
        {
            int IdCliente = Convert.ToInt32(Request.QueryString["Id"]);
            Response.Redirect("AltaCliente.aspx?Id=" + IdCliente);
        }
    }
}