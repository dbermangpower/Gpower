<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteMFLPO.aspx.cs" Inherits="QMS.Pages.ReporteMFL.ReporteMFLPO" %>

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

    <div class="col-md-5 offset-md-0" style="align-content: center; align-items: center">
        <span class="anchor" id="formPayment"></span>
        <hr class="my-5">
        <div class="card card-outline-secondary">
            <div class="card-body">

                <div class="container forget-password">
                    <div class="row">
                        <div>
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <div class="text-center">
                                        <img src="https://i.ibb.co/rshckyB/car-key.png" alt="car-key" border="0">
                                        <h3 class="text-center">Parámetros de operación</h3>
                                        <h4>MFL</h4>
                                        <table style="align-items:center">
                                            <tr style="border-top: 1px solid; border-top-color: darkslategrey">
                                                <td>Linea:</td>
                                                <td>
                                                    <asp:Label ID="lblLinea" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr style="border-bottom: 1px solid; border-bottom-color: darkslategrey">
                                                <td>Herramienta:</td>
                                                <td>
                                                    <asp:Label ID="lblHerramienta" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td style="font-size: small">Lanzamiento</td>
                                                <td style="font-size: small">Un.</td>
                                                <td style="font-size: small">Recepción</td>
                                                <td style="font-size: small">Un.</td>
                                            </tr>
                                            <tr class="form-group">
                                                <td>Presión:</td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="txtPresionLanzador" runat="server" Text="Lanzamiento" CssClass="form-control" /></td>
                                                <td style="width: 80px">
                                                    <asp:DropDownList ID="ddlUPresionL" runat="server" CssClass="form-control"></asp:DropDownList></td>

                                                <td style="width: 100px">
                                                    <asp:TextBox ID="txtPresionRecepcion" runat="server" Text="Recepcion" CssClass="form-control" /></td>
                                                <td style="width: 80px">
                                                    <asp:DropDownList ID="ddlUPresionR" runat="server" CssClass="form-control"></asp:DropDownList></td>

                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td colspan="2">
                                                    <asp:RegularExpressionValidator ID="rvPL" runat="server" ControlToValidate="txtPresionLanzador"
                                                        ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="\d+(\,\d{1,2})?" Font-Size="XX-Small" Height="5px" /></td>

                                                <td colspan="2">
                                                    <asp:RegularExpressionValidator ID="rvPR" runat="server" ControlToValidate="txtPresionRecepcion"
                                                        ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="\d+(\,\d{1,2})?" Font-Size="XX-Small" Height="5px" /></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td style="font-size: small">Mínima</td>
                                                <td style="font-size: small">Un.</td>
                                                <td style="font-size: small">Máxima</td>
                                                <td style="font-size: small">Un.</td>
                                            </tr>
                                            <tr>
                                                <td>Temperatura:</td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="txtTemperaturaMin" runat="server" Text="Mín" CssClass="form-control"></asp:TextBox></td>
                                                <td style="width: 80px">
                                                    <asp:DropDownList ID="ddlUTempMin" runat="server" CssClass="form-control"></asp:DropDownList></td>

                                                <td style="width: 100px">
                                                    <asp:TextBox ID="txtTemperaturaMax" runat="server" Text="Máx" CssClass="form-control"></asp:TextBox></td>
                                                <td style="width: 80px">
                                                    <asp:DropDownList ID="ddlUTempMax" runat="server" CssClass="form-control"></asp:DropDownList></td>

                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td colspan="2">
                                                    <asp:RegularExpressionValidator ID="rvTMin" runat="server" ControlToValidate="txtTemperaturaMin"
                                                        ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="\d+(\,\d{1,2})?" Font-Size="XX-Small" Height="10px" /></td>
                                                <td colspan="2">
                                                    <asp:RegularExpressionValidator ID="rvTMax" runat="server" ControlToValidate="txtTemperaturaMax"
                                                        ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="\d+(\,\d{1,2})?" Font-Size="XX-Small" Height="10px" /></td>
                                            </tr>
                                            <tr>
                                                <td>Tasa de flujo:</td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="txtTasaFlujo" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                <td style="width: 80px">m<sup>3</sup>/s</td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td colspan="2">
                                                    <asp:RegularExpressionValidator ID="rvTF" runat="server" ControlToValidate="txtTasaFlujo"
                                                        ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="\d+(\,\d{1,2})?" Font-Size="XX-Small" Height="10px" /></td>
                                            </tr>
                                            <tr>
                                                <td>Velocidad promedio:</td>
                                                <td>
                                                    <asp:Label ID="lblVelocidadProm" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>m/s</td>
                                            </tr>

                                            <tr>
                                                <td>Comentarios:</td>
                                                <td colspan="6">
                                                    <asp:TextBox runat="server" ID="txtComentarios" TextMode="MultiLine" Columns="20" Rows="3" Width="1200px" Height="100px" CssClass="form-control" /></td>
                                            </tr>

                                        </table>

                                        <div>
                                            <br />
                                            <asp:Button ID="btnAceptar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />

                                            <asp:Button ID="btnCD" runat="server" Text="Cargar condición de los datos" CssClass="btn btn-primary" OnClick="btnCD_Click" />

                                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
