<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCliente.aspx.cs" Inherits="QMS.Pages.DetalleCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row gutters-sm">
        <div class="col-md-4 mb-3">
            <div class="card">
                <div class="card-body">
                    <div class="d-flex flex-column align-items-center text-center">
                        <asp:Image ID="imgLogo" runat="server" Height="80" />
                        <div class="mt-3">
                            <h4>
                                <asp:Label ID="lblNombreCliente" runat="server" Text="Label"></asp:Label></h4>
                            <p class="text-muted font-size-sm">Argentina</p>
                            <div class="d-flex justify-content-center mb-2">
                                <asp:Button ID="btnEditarCliente" runat="server" Text="Editar" CssClass="btn btn-primary" OnClick="btnEditarCliente_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-8">
            <div class="card mb-3">
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-3">
                            <h6 class="mb-0">Próxima inspección:</h6>
                        </div>
                        <div class="col-sm-9 text-secondary">
                            <asp:Label ID="lblProxInsp" runat="server" Text="Sin información"></asp:Label>
                        </div>
                    </div>
                    <hr>
                    <div class="row">
                        <div class="col-sm-3">
                            <h6 class="mb-0">Última inspección:</h6>
                        </div>
                        <div class="col-sm-9 text-secondary">
                            <asp:Label ID="lblUltimaInsp" runat="server" Text="Sin información"></asp:Label>
                        </div>
                    </div>
                    <hr>
                    <div class="row">
                        <div class="col-sm-3">
                            <h6 class="mb-0">Cantidad de inspeccíones en año en curso:</h6>
                        </div>
                        <div class="col-sm-9 text-secondary">
                            <asp:Label ID="lblCantInspecciones" runat="server" Text="Sin información"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <h2>Contactos</h2>
    <asp:GridView ID="dgvContactos" runat="server" AutoGenerateColumns="false" DataKeyNames="IdContactoCliente" CssClass="table table-bordered table-condensed table-hover" HeaderStyle-HorizontalAlign="Center" OnRowCommand="dgvContactos_RowCommand" OnRowDataBound="dgvContactos_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" />
            <asp:BoundField HeaderText="E-Mail" DataField="Mail" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton Text="Editar" runat="server" ID="btnEditar" CommandName="btnEditar" CommandArgument='<%#Eval("IdContactoCliente") %>' CssClass="btn btn-secondary" Width="100px" />
                    <asp:LinkButton Text="Eliminar" runat="server" ID="btnEliminar" CommandName="btnEliminar" CommandArgument='<%#Eval("IdContactoCliente") %>' CssClass="btn btn-danger" Width="100px" />
                </ItemTemplate>
                <ItemStyle Width="250px" HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <asp:Label ID="lblContactos" runat="server" Text="No hay contactos registrados para el cliente." Visible="false"></asp:Label>
    </div>
    <br />
    <br />
    <div>
        <asp:Button ID="btnAgregarContacto" OnClick="btnAgregarContacto_Click" runat="server" Text="Agregar nuevo contacto" CssClass="btn btn-outline-secondary" />
    </div>
</asp:Content>
