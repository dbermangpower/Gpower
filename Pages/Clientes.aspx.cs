﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using DataAccess;
using System.Data;

namespace QMS
{
    public partial class Clientes : System.Web.UI.Page
    {
        List<Cliente> listaClientes = new List<Cliente>();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaCliente.aspx",false);
        }

        private void CargarGrilla()
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            listaClientes = clienteNegocio.listarClientes();

            dgvClientes.DataSource = listaClientes;
            dgvClientes.DataBind();
        }

        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dgvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}