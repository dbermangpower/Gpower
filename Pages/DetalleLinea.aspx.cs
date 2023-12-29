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
    public partial class DetalleLinea : System.Web.UI.Page
    {
        public int IdLineaSeleccionada { get; set; }

        public DatosLinea DatosLinea = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            int IdLineaSeleccionada = Convert.ToInt32(Request.QueryString["id"]);
            DatosLineaNegocio datosLineaNegocio = new DatosLineaNegocio();

            if (Request.QueryString["id"] != null)
            {
                DatosLinea = datosLineaNegocio.BuscarLinea(IdLineaSeleccionada);

                lblLinea.Text = DatosLinea.NombreLinea;
                lblCompania.Text = DatosLinea.cliente.NombreCliente;
                lblDiametro.Text = DatosLinea.Diametro.ToString();
                lblLargo.Text = DatosLinea.LargoTuberia.ToString();
                lblGrado.Text = DatosLinea.grado.gradoTuberia;
                lblTipoSoldadura.Text = DatosLinea.tipo.tipoSoldadura;
                lblProductoTrans.Text = DatosLinea.ProductoTransportado;
                lblPD.Text = DatosLinea.PD.ToString();
                lblFD.Text = DatosLinea.FD.ToString();
                lblMAOP.Text = DatosLinea.MAOP.ToString();
                lblEspesorParedNom.Text = DatosLinea.EspesorNominal.ToString();
                lblEspesorMin.Text = DatosLinea.EspesorMin.ToString();
                lblAnioInst.Text = DatosLinea.AnioInstalacion.ToString();
                if (DatosLinea.InspeccionPrevio == true)
                {
                    lblInspeccionPrevia.Text = "Si";
                    lblAnioInst.Text = DatosLinea.AnioInspeccionPrevia.ToString();
                } else
                {
                    lblInspeccionPrevia.Text = "No";
                    lblAnioInst.Text = "N/A";
                }
                lblSMYS.Text = DatosLinea.SMYS.ToString();                
            }
        }
    }
}