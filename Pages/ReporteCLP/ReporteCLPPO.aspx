<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteCLPPO.aspx.cs" Inherits="QMS.Pages.ReporteCLP.ReporteCLPPO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Content/ReportesStyle.css">
    <style>
        .multiColumnCheckBoxList {
            column-count: 1; /* Configura el número inicial de columnas */
            column-gap: 10px; /* Espaciado entre columnas */
        }

            .multiColumnCheckBoxList.multiColumn {
                column-count: 2; /* Cambia a dos columnas si tiene más de 5 elementos */
            }
    </style>
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
                                    <asp:Label ID="lblHerramienta" runat="server" Text="Label"></asp:Label>
                                    <td></td>
                                </tr>
                                <tr class="form-group">
                                    <td>Presión:</td>
                                    <td>
                                        <asp:TextBox ID="txtPresionLanzador" runat="server" Text="Lanzamiento" CssClass="form-control" /></td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="rvPL" runat="server" ControlToValidate="txtPresionLanzador"
                                            ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="\d+(\,\d{1,2})?" /></td>
                                    <td>
                                        <asp:TextBox ID="txtPresionRecepcion" runat="server" Text="Recepcion" CssClass="form-control" /></td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="rvPR" runat="server" ControlToValidate="txtPresionRecepcion"
                                            ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="\d+(\,\d{1,2})?" /></td>
                                    <tr>
                                        <td>Temperatura:</td>
                                        <td>
                                            <asp:TextBox ID="txtTemperaturaMin" runat="server" Text="Mín" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="rvTMin" runat="server" ControlToValidate="txtTemperaturaMin"
                                                ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="\d+(\,\d{1,2})?" /></td>
                                        <td>
                                            <asp:TextBox ID="txtTemperaturaMax" runat="server" Text="Máx" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="rvTMax" runat="server" ControlToValidate="txtTemperaturaMax"
                                                ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="\d+(\,\d{1,2})?" /></td>
                                    </tr>
                                <tr>
                                    <td>Tasa de flujo:</td>
                                    <td>
                                        <asp:TextBox ID="txtTasaFlujo" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="rvTF" runat="server" ControlToValidate="txtTasaFlujo"
                                            ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="\d+(\,\d{1,2})?" /></td>
                                </tr>
                                <tr>
                                    <td>Velocidad promedio:</td>
                                    <td>
                                        <asp:Label ID="lblVelocidadProm" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td>Comentarios:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtComentarios" TextMode="MultiLine" Columns="20" Rows="3" Width="600px" Height="100px" CssClass="form-control" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAceptar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" /></td>
                                    <td>
                                        <asp:Button ID="btnCD" runat="server" Text="Cargar condición de los datos" CssClass="btn btn-primary" OnClick="btnCD_Click" /></td>
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
