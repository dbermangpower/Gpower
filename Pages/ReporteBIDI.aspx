<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteBIDI.aspx.cs" Inherits="QMS.Pages.ReporteBIDI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            background: #83d49d;
        }

        .forget-pwd > a {
            color: #dc3545;
            font-weight: 500;
        }

        .forget-password .panel-default {
            padding: 31%;
            margin-top: -27%;
        }

        .forget-password .panel-body {
            padding: 15%;
            margin-bottom: -50%;
            background: #fff;
            border-radius: 5px;
            -webkit-box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
        }

        img {
            width: 40%;
            margin-bottom: 10%;
        }

        .btnForget {
            background: #c0392b;
            border: none;
        }

        .forget-password .dropdown {
            width: 100%;
            border: 1px solid #ced4da;
            border-radius: .25rem;
        }

            .forget-password .dropdown button {
                width: 100%;
            }

            .forget-password .dropdown ul {
                width: 100%;
            }
    </style>
    <div class="container forget-password">
        <div class="row">
            <div class="col-xl-20 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="text-center">
                            <img src="https://i.ibb.co/rshckyB/car-key.png" alt="car-key" border="0">
                            <h3 class="text-center">Reporte de campo</h3>
                            <h4>BIDI</h4>
                            <table>
                                <tr>
                                    <td>Linea:</td>
                                    <td>
                                        <asp:Label ID="lblLinea" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Herramienta:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlHerramienta" runat="server" CssClass="form-control"></asp:DropDownList>
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
                                    <td>Daño en placa</td>
                                    <td>
                                        <asp:DropDownList ID="ddlDanio" runat="server" CssClass="form-control"></asp:DropDownList></td>
                                    <td>
                                     <asp:DropDownList ID="ddlTipoDeformacion" runat="server" CssClass="form-control"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>Máxima reducción:</td>
                                    <td>
                                        <asp:TextBox ID="txtReduccionMax" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Comentarios:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtComentarios" TextMode="MultiLine" Columns="20" Rows="3" Width="600px" Height="100px" CssClass="form-control" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click"/></td>
                                    <td><asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" /></td>
                                </tr>
                            </table>  
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
