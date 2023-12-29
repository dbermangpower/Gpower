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
    public partial class Herramientas : System.Web.UI.Page
    {
        List<Herramienta> listaHerramientas = new List<Herramienta>();
        List<Herramienta> listaFiltrada = new List<Herramienta>();
        List<TipoHerramienta> listaTipoHerramientas = new List<TipoHerramienta>();
        public string FiltroSeleccionado { get; set; }
        public int TipoHerramientaSeleccionado { get; set; }
        public int DiametroSeleccionado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void dgvHerramientas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaHerramienta.aspx");
        }
        private void CargarGrilla()
        {
            try
            {
                if (!IsPostBack)
                {
                    //Lista herramientas dadas de alta
                    HerramientaNegocio herramientaNegocio = new HerramientaNegocio();
                    listaHerramientas = herramientaNegocio.listarHerramientas();

                    //Lista de diametros
                    List<int> listaDiametros = new List<int>();
                    foreach (var item in listaHerramientas)
                    {
                        int diametro = item.Diametro;
                        listaDiametros.Add(diametro);
                    }
                    // Obtener diámetros únicos
                    List<int> diametrosUnicos = listaDiametros.Distinct().OrderBy(d => d).ToList();

                    //Lista los tipos de herramienta
                    foreach (EnumTipoHerramienta tipoEnum in Enum.GetValues(typeof(EnumTipoHerramienta)))
                    {
                        TipoHerramienta herramienta = new TipoHerramienta
                        {
                            IdTipoHerramienta = (int)tipoEnum,
                            tipoHerramienta = tipoEnum.ToString()
                        };

                        listaTipoHerramientas.Add(herramienta);
                    }

                    //Captura el filtro seleccionado
                    FiltroSeleccionado = Request.QueryString["Filtro"];

                    //Captura la opción seleccionada en el filtro
                    if (Request.QueryString["Herramienta"] != null)
                    {
                        TipoHerramientaSeleccionado = Convert.ToInt32(Request.QueryString["Herramienta"]);
                    }
                    if (Request.QueryString["Diametro"] != null)
                    {
                        DiametroSeleccionado = Convert.ToInt32(Request.QueryString["Diametro"]);
                    }

                    //Lista las opciones para filtrar
                    ListItem item0 = new ListItem("--------", "0");
                    ListItem item1 = new ListItem("Tipo de herramienta", "1");
                    ListItem item2 = new ListItem("Diametro", "2");

                    DropDownListFiltro.Items.Add(item0);
                    DropDownListFiltro.Items.Add(item1);
                    DropDownListFiltro.Items.Add(item2);

                    //Carga los diametros listados
                    ddlDiametro.DataSource = diametrosUnicos;
                    ddlDiametro.DataBind();

                    //Carga los tipos de herramienta
                    ddlTipoHerramienta.DataSource = listaTipoHerramientas;
                    ddlTipoHerramienta.DataTextField = "tipoHerramienta";
                    ddlTipoHerramienta.DataValueField = "IdTipoHerramienta";
                    ddlTipoHerramienta.DataBind();

                    if (Request.QueryString["Filtro"] != null)
                    {
                        if (FiltroSeleccionado == "1")
                        {
                            for (int i = 0; i < listaHerramientas.Count; i++)
                            {
                                if (listaHerramientas[i].tipoHerramienta.IdTipoHerramienta == TipoHerramientaSeleccionado)
                                {
                                    listaFiltrada.Add(listaHerramientas[i]);
                                }
                            }
                        }
                        else if (FiltroSeleccionado == "2")
                        {
                            for (int i = 0; i < listaHerramientas.Count; i++)
                            {
                                if (listaHerramientas[i].Diametro == DiametroSeleccionado)
                                {
                                    listaFiltrada.Add(listaHerramientas[i]);
                                }
                            }
                        }

                        dgvHerramientas.DataSource = listaFiltrada;
                        dgvHerramientas.DataBind();
                    } else
                    {
                        dgvHerramientas.DataSource = listaHerramientas;
                        dgvHerramientas.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void ButtonFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = DropDownListFiltro.SelectedIndex.ToString();
            string opcion;

            if (DropDownListFiltro.SelectedIndex == 1)
            {
                opcion = ddlTipoHerramienta.SelectedItem.Value.ToString();

                Response.Redirect("Herramientas.aspx?Filtro=" + filtro + "&Herramienta=" + opcion, false);
            }
            else if (DropDownListFiltro.SelectedIndex == 2)
            {
                opcion = ddlDiametro.SelectedItem.Value.ToString();

                Response.Redirect("Herramientas.aspx?Filtro=" + filtro + "&Diametro=" + opcion, false);
            }
        }
    }
}