<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="QMS.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <p>Filtrar por:</p>
    <div>
        <asp:DropDownList ID="DropDownListFiltro" runat="server" AutoPostBack="true"></asp:DropDownList>
        <%if (DropDownListFiltro.SelectedIndex > 0)
            {
        %> <%if (DropDownListFiltro.SelectedIndex == 1)
               {
        %>
        <asp:DropDownList ID="ddlClientes" AutoPostBack="true" runat="server"></asp:DropDownList>
        <%  }
            else if (DropDownListFiltro.SelectedIndex == 2)
            { %>
        <asp:DropDownList ID="ddlAnio" AutoPostBack="true" runat="server"></asp:DropDownList>
        <%  }%>
        <asp:Button ID="ButtonFiltrar" runat="server" Text="Filtrar" OnClick="ButtonFiltrar_Click" CssClass="btn btn-light" AutoPostBack="true" />
        <%  } %>
    </div>
    <br />
    <asp:GridView runat="server" Class="table table-bordered table-condensed table-hover" ID="dgvReportes" AutoGenerateColumns="false" DataKeyNames="IdReporte" OnRowCommand="dgvReportes_RowCommand" OnRowDataBound="dgvReportes_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="IdReporte" DataField="IdReporte" />
            <asp:BoundField HeaderText="Fecha de alta" DataField="FechaCreacion" DataFormatString="{0:d}" />
            <asp:BoundField HeaderText="Tipo de inspección" DataField="TipoInspeccion.TipoInspeccion" />
            <asp:BoundField HeaderText="Nombre Linea" DataField="DatosLinea.NombreLinea" />
            <asp:BoundField HeaderText="Cliente" DataField="DatosLinea.cliente.NombreCliente" />

            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton Text="Ver detalle" runat="server" ID="btnDetalle" CommandName="btnDetalle" CommandArgument='<%#Eval("IdReporte") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

</asp:Content>
