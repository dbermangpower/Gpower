using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using DataAccess;
using Microsoft.Identity.Client;

namespace QMS.Pages
{
    public partial class AltaLinea : System.Web.UI.Page
    {
        List<Cliente> listaClientes = new List<Cliente>();
        List<GradoTuberia> listaGrados = new List<GradoTuberia>();
        List<TipoSoldadura> listaTipoSoldadura = new List<TipoSoldadura>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarListas();
            }
        }

        private void CargarListas()
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            GradoTuberiaNegocio gradoTuberiaNegocio = new GradoTuberiaNegocio();
            TipoSoldaduraNegocio tipoSoldaduraNegocio = new TipoSoldaduraNegocio();

            listaClientes = clienteNegocio.listarClientes();
            listaGrados = gradoTuberiaNegocio.listarGrados();
            listaTipoSoldadura = tipoSoldaduraNegocio.listarSoldaduras();

            ddlCliente.DataSource = listaClientes;
            ddlCliente.DataTextField = "NombreCliente";
            ddlCliente.DataValueField = "IdCliente";
            ddlCliente.DataBind();

            ddlGrado.DataSource = listaGrados;
            ddlGrado.DataTextField = "GradoTuberia";
            ddlGrado.DataValueField = "IdGradoTuberia";
            ddlGrado.DataBind();

            ddlSoldadura.DataSource = listaTipoSoldadura;
            ddlSoldadura.DataTextField = "tipoSoldadura";
            ddlSoldadura.DataValueField = "IdTipoSoldadura";
            ddlSoldadura.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            DatosLineaNegocio datosLineaNegocio = new DatosLineaNegocio();
            DatosLinea datosLinea = new DatosLinea();

            try
            {
                datosLinea.cliente = new Cliente();
                datosLinea.cliente.IdCliente = int.Parse(ddlCliente.SelectedItem.Value);
                datosLinea.NombreLinea = txtNombreLinea.Text;

                if (short.TryParse(txtDiametro.Text, out short valorDiametro))
                {
                    datosLinea.Diametro = valorDiametro;
                }
                if (decimal.TryParse(txtLargo.Text, out decimal valorLargoTuberia))
                {
                    datosLinea.LargoTuberia = valorLargoTuberia;
                }
                datosLinea.grado = new GradoTuberia();
                datosLinea.grado.IdGradoTuberia = int.Parse(ddlGrado.SelectedItem.Value);
                datosLinea.tipo = new TipoSoldadura();
                datosLinea.tipo.IdTipoSoldadura = int.Parse(ddlSoldadura.SelectedItem.Value);
                datosLinea.ProductoTransportado = txtProducto.Text;
                if (decimal.TryParse(txtPresion.Text, out decimal valorPD))
                {
                    datosLinea.PD = valorPD;
                }
                if (decimal.TryParse(txtFactor.Text, out decimal valorFD))
                {
                    datosLinea.FD = valorFD;
                }
                if (decimal.TryParse(txtMAOP.Text, out decimal valorMAOP))
                {
                    datosLinea.MAOP = valorMAOP;
                }
                if (decimal.TryParse(txtEspesorNominal.Text, out decimal valorEspNom))
                {
                    datosLinea.EspesorNominal = valorEspNom;
                }
                if (decimal.TryParse(txtEspesorMin.Text, out decimal valorEspMin))
                {
                    datosLinea.EspesorMin = valorEspMin;
                }
                if (decimal.TryParse(txtEspesorMax.Text, out decimal valorEspMax))
                {
                    datosLinea.EspesorMax = valorEspMax;
                }

                int anioInstalacion;
                if (int.TryParse(txtAnioInstalacion.Text, out anioInstalacion))
                {
                    datosLinea.AnioInstalacion = anioInstalacion;
                }
                else
                {
                    // Manejo de error si el valor no es convertible a int
                }
                if(ddlInspeccionPrevia.SelectedItem.Value == "1")
                {
                    datosLinea.InspeccionPrevio = true;
                } else
                {
                    datosLinea.InspeccionPrevio = false;
                }
                
                int anioInspeccionPrevia;
                if (int.TryParse(txtAnioInspeccionPrevia.Text, out anioInspeccionPrevia))
                {
                    datosLinea.AnioInspeccionPrevia = anioInspeccionPrevia;
                }
                else
                {
                    // Manejo de error si el valor no es convertible a int
                }

                if (decimal.TryParse(txtSMYS.Text, out decimal valorSMYS))
                {
                    datosLinea.SMYS = valorSMYS;
                }

                datosLineaNegocio.agregarLinea(datosLinea);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void ddlInspeccionPrevia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlInspeccionPrevia.SelectedValue == "1")
            {
                txtAnioInspeccionPrevia.Visible = true;
                lblAnioInspPrevia.Visible = true;
            }
            else
            {
                txtAnioInspeccionPrevia.Visible = false;
                lblAnioInspPrevia.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lineas.aspx");
        }
    }
}