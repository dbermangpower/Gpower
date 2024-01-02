<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteCLP.aspx.cs" Inherits="QMS.Pages.ReporteCLP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Content/ReportesStyle.css">
    <div class="container forget-password">
        <div class="row">
            <div class="col-xxl-12 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="text-center">
                            <img src="https://i.ibb.co/rshckyB/car-key.png" alt="car-key" border="0">
                            <h3 class="text-center">Reporte de campo</h3>
                            <h4>CLP</h4>
                            <table>
                                <tr>
                                    <td>Linea:</td>
                                    <td>
                                        <asp:Label ID="lblLinea" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Herramienta:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlHerramienta" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlHerramienta_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr class="form-group">
                                    <td>Fecha Operación:</td>
                                    <td>
                                        <asp:TextBox ID="txtFechaOperacion" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
                                    <td>Hora:</td>
                                    <td>
                                        <asp:TextBox ID="txtHoraOperacion" runat="server" TextMode="Time" CssClass="form-control" /></td>
                                </tr>
                                <tr>
                                    <td>Fecha Recepción:</td>
                                    <td>
                                        <asp:TextBox ID="txtFechaRecepcion" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox></td>
                                    <td>Hora:</td>
                                    <td>
                                        <asp:TextBox ID="txtHoraRecepcion" runat="server" TextMode="Time" CssClass="form-control" /></td>
                                </tr>
                                <tr>
                                    <td>Residuos recolectados:</td>
                                    <td>
                                        <asp:TextBox ID="txtResiduos" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    <asp:RegularExpressionValidator ID="regexValidator" runat="server" ControlToValidate="txtResiduos"
                                        ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="^\d+(\.\d+)?$" />
                                </tr>
                                <tr>
                                    <td>Daño en Herramienta</td>
                                    <td>
                                        <asp:DropDownList ID="ddlDanio" runat="server" CssClass="form-control"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>Sensores dañados:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlSensores" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSensores_SelectedIndexChanged"></asp:DropDownList>
                                    <td>
                                        <asp:Label ID="lblFlaps" runat="server" Text="Enumere Flaps dañados"></asp:Label></td>
                                    <td>
                                        <asp:ListBox ID="listBoxFlaps" runat="server"></asp:ListBox></td>
                                    0
                                </tr>

                                <tr>
                                    <td>Comentarios:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtComentarios" TextMode="MultiLine" Columns="20" Rows="3" Width="600px" Height="100px" CssClass="form-control" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" /></td>
                                    <td>
                                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
