<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lineas.aspx.cs" Inherits="QMS.Pages.Lineas" %>

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
            <asp:DropDownList ID="ddlClientes" AutoPostBack="true" runat="server"></asp:DropDownList>
            <%  }
                else if (DropDownListFiltro.SelectedIndex == 2)
                { %>
            <asp:DropDownList ID="ddlUltimaInspeccion" AutoPostBack="true" runat="server"></asp:DropDownList>
            <% }%>
            <asp:Button ID="ButtonFiltrar" runat="server" Text="Filtrar" OnClick="ButtonFiltrar_Click" CssClass="btn btn-light" AutoPostBack="true" />
            <%  } %>
            <div class="container justify-content-center">
            </div>
            <br />
            <h2>Líneas:</h2>
            <asp:GridView ID="dgvLineas" runat="server" AutoGenerateColumns="false" DataKeyNames="IdLinea" OnRowCommand="dgvLineas_RowCommand" CssClass="table table-bordered table-condensed table-hover" HeaderStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField HeaderText="IdLinea" DataField="IdLinea" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="Nombre" DataField="NombreLinea" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="Cliente" DataField="cliente.NombreCliente" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="Diametro" DataField="Diametro" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton Text="Editar" runat="server" ID="btnEditar" CommandName="btnEditar" CommandArgument='<%#Eval("IdLinea") %>' CssClass="btn btn-secondary" Width="100px" />
                            <asp:LinkButton Text="Ver detalle" runat="server" ID="btnDetalle" CommandName="btnDetalle" CommandArgument='<%#Eval("IdLinea") %>' CssClass="btn btn-primary" Width="100px" />
                        </ItemTemplate>
                        <ItemStyle Width="250px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
