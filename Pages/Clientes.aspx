<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="QMS.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container justify-content-center">
        <div class="row">
            <div class="col">
            </div>
            <div class="col d-flex justify-content-center">
                <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar cliente" OnClick="ButtonAgregar_Click" CssClass="btn btn-secondary" />
            </div>
            <div class="col">
            </div>
        </div>
        <div class="container justify-content-center">
            <h2>Clientes:</h2>
            <asp:GridView ID="dgvClientes" runat="server" AutoGenerateColumns="false" DataKeyNames="IdCliente" OnRowCommand="dgvClientes_RowCommand" CssClass="table table-bordered table-condensed table-hover" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="dgvClientes_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="IdCliente" DataField="IdCliente" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="Nombre" DataField="NombreCliente" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Logo">
                        <ItemTemplate >
                            <asp:Image ID="Image" runat="server" Height="50"
                                ImageUrl='<%# "data:image/" + Eval("ExtensionLogo") + ";base64," + Convert.ToBase64String((byte[])Eval("Logo")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton Text="Editar" runat="server" ID="btnEditar" CommandName="btnEditar" CommandArgument='<%#Eval("IdCliente") %>' CssClass="btn btn-secondary" Width="100px" />
                            <asp:LinkButton Text="Eliminar" runat="server" ID="btnEliminar" CommandName="btnEliminar" CommandArgument='<%#Eval("IdCliente") %>' CssClass="btn btn-danger" Width="100px" />
                        </ItemTemplate>
                        <ItemStyle Width="250px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
