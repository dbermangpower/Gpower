<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Herramientas.aspx.cs" Inherits="QMS.Pages.Herramientas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container justify-content-center">
    <div class="row">
        <div class="col">
        </div>
        <div class="col d-flex justify-content-center">
            <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar" OnClick="ButtonAgregar_Click" CssClass="btn btn-secondary" />
        </div>
        <div class="col">
        </div>
    </div>
    <div>
        <div>
            <p>Filtrar por:</p>
            <asp:DropDownList ID="DropDownListFiltro" runat="server" AutoPostBack="true"></asp:DropDownList>
        </div>
        <%if (DropDownListFiltro.SelectedIndex > 0)
            {
        %> <%if (DropDownListFiltro.SelectedIndex == 1)
               {
        %>
        <asp:DropDownList ID="ddlTipoHerramienta" AutoPostBack="true" runat="server"></asp:DropDownList>
        <%  }
            else if (DropDownListFiltro.SelectedIndex == 2)
            { %>
        <asp:DropDownList ID="ddlDiametro" AutoPostBack="true" runat="server"></asp:DropDownList>
        <% }%>
        <asp:Button ID="ButtonFiltrar" runat="server" Text="Filtrar" OnClick="ButtonFiltrar_Click" CssClass="btn btn-light" AutoPostBack="true" />
        <%  } %>
        <div class="container justify-content-center">
        </div>
        <br />
        <h2>Herramientas:</h2>
        <asp:GridView ID="dgvHerramientas" runat="server" AutoGenerateColumns="false" DataKeyNames="IdHerramienta" OnRowCommand="dgvHerramientas_RowCommand" CssClass="table table-bordered table-condensed table-hover" HeaderStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField HeaderText="IdHerramienta" DataField="IdHerramienta" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="Descripción" DataField="Nombre" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="Diametro" DataField="Diametro" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="Tipo de herramienta" DataField="tipoHerramienta.tipoHerramienta" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="Cantidad de sensores" DataField="CantSensores" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton Text="Editar" runat="server" ID="btnEditar" CommandName="btnEditar" CommandArgument='<%#Eval("IdHerramienta") %>' CssClass="btn btn-secondary" Width="100px" />
                        <asp:LinkButton Text="Ver detalle" runat="server" ID="btnDetalle" CommandName="btnDetalle" CommandArgument='<%#Eval("IdHerramienta") %>' CssClass="btn btn-primary" Width="120px" />
                    </ItemTemplate>
                    <ItemStyle Width="250px" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>
</asp:Content>
