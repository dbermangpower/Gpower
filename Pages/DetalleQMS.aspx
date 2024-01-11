<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterQMS.Master" AutoEventWireup="true" CodeBehind="DetalleQMS.aspx.cs" Inherits="QMS.Pages.DetalleQMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-responsive-md">
        <table class="table" style="align-content: center; text-align: center; width= 70%">
            <tr class="table-secondary">
                <td colspan="4" class="table-secondary">
                    <h3>BIDI</h3>
                </td>
            </tr>
            <%if (reporteBIDI == true)
                { %>
            <tr>
                <td colspan="4" class="table-secondary" style="font-" >REPORTE DE CAMPO</td>
            </tr>
            <tr>
                <td>Herramienta:</td>
                <td colspan="3">
                    <asp:Label ID="lblHerramienta" runat="server" Text="Herramienta"></asp:Label></td>
            </tr>
            <tr>
                <td>Fecha de operación:</td>
                <td>
                    <asp:Label ID="lblFechaOperacion" runat="server" Text="FechaOperacion"></asp:Label></td>
                <td>Hora:</td>
                <td>
                    <asp:Label ID="lblHoraOperacion" runat="server" Text="Hora"></asp:Label></td>
            </tr>
            <tr>
                <td>Fecha de recepción:</td>
                <td>
                    <asp:Label ID="lblFechaRecepcion" runat="server" Text="FechaRecepcion"></asp:Label></td>
                <td>Hora:</td>
                <td>
                    <asp:Label ID="lblHoraRecepcion" runat="server" Text="Hora"></asp:Label></td>
            </tr>
            <tr>
                <td>Duración de corrida:</td>
                <td colspan="3">
                    <asp:Label ID="lblDuracion" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td>Pasadas requeridas:</td>
                <td>
                    <asp:Label ID="lblPasadasRequeridas" runat="server" Text="Sin información"></asp:Label></td>
                <td>Residuos recolectados:</td>
                <td>
                    <asp:Label ID="lblResiduosRecolectados" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td>Daño en placa:</td>
                <td>
                    <asp:Label ID="lblDanioPlaca" runat="server" Text="Sin información"></asp:Label></td>
                <td>
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo de deformación"></asp:Label></td>
                <td>
                    <asp:Label ID="lblTipoDeformacion" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td>Máxima reducción:</td>
                <td colspan="3">
                    <asp:Label ID="lblMaximaReduccion" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Button ID="btnEditarBIDI" runat="server" Text="Editar reporte BIDI" CssClass="btn btn-primary" /></td>
            </tr>
            <% }
                else
                {%>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnAgregarBIDI" runat="server" Text="Agregar reporte BIDI" OnClick="btnAgregarBIDI_Click" CssClass="btn btn-secondary" /></td>
            </tr>
            <% }%>
            <%if (Session.Count > 0 && reporte.TipoInspeccion.IdTipoInspeccion != 1)
                { %>
        </table>
        <table class="table" style="align-content: center; text-align: center; width= 70%">
            <tr class="table-info">
                <td colspan="5" class="table-info">
                    <h3>CLP</h3>
                </td>
            </tr>
            <%if (reporteCLP == true)
                { %>
            <tr class="table-info">
                <td colspan="5" class="table-info">REPORTE DE CAMPO</td>
            </tr>
            <tr>
                <td>Herramienta:</td>
                <td colspan="2">
                    <asp:Label ID="lblHerramientaCLP" runat="server" Text="Sin información"></asp:Label></td>
                <td>Inspección número:</td>
                <td>
                    <asp:Label ID="lblNumInspCLP" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td>Fecha de operación:</td>
                <td>
                    <asp:Label ID="lblFOCLP" runat="server" Text="Sin información"></asp:Label></td>
                <td>Hora:</td>
                <td colspan="2">
                    <asp:Label ID="lblHOCLP" runat="server" Text="Hora"></asp:Label></td>
            </tr>
            <tr>
                <td>Fecha de recepción:</td>
                <td>
                    <asp:Label ID="lblFRCLP" runat="server" Text="Sin información"></asp:Label></td>
                <td>Hora:</td>
                <td colspan="2">
                    <asp:Label ID="lblHRCLP" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td>Duración de corrida:</td>
                <td colspan="4">
                    <asp:Label ID="lblDuracionCLP" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td>Residuos recolectados</td>
                <td>
                    <asp:Label ID="lblResiduosCLP" runat="server" Text="Sin información"></asp:Label></td>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td>Daño en herramienta:</td>
                <td>
                    <asp:Label ID="lblDanioCLP" runat="server" Text="Sin información"></asp:Label></td>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td>Sensores dañados:</td>
                <td colspan="2">
                    <asp:Label ID="lblSensoresCLPDaniados" runat="server" Text="Sin información"></asp:Label></td>
                <td colspan="3">
                    <asp:Label ID="lblSensoresCLP" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr class="table-info">
                <td colspan="5" class="table-info">PARAMETROS DE OPERACIÓN</td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td>Presión Lanzador</td>
                <td>
                    <asp:Label ID="lblPLCLP" runat="server" Text="Sin información"></asp:Label></td>
                <td>Presión Recibidor</td>
                <td colspan="2">
                    <asp:Label ID="lblPRCLP" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td>Temperatura mínima</td>
                <td>
                    <asp:Label ID="lblTminCLP" runat="server" Text="Sin información"></asp:Label></td>
                <td>Temperatura máxima</td>
                <td colspan="2">
                    <asp:Label ID="lblTmaxCLP" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td>Tasa de flujo</td>
                <td>
                    <asp:Label ID="lblFlujoCLP" runat="server" Text="Sin información"></asp:Label></td>
                <td>Velocidad promedio</td>
                <td colspan="2">
                    <asp:Label ID="lblVelProm" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr class="table-info">
                <td colspan="5" class="table-info">CONDICION DE LOS DATOS</td>
            </tr>
            <tr>
                <td>Comienza grabación:</td>
                <td>
                    <asp:Label ID="lblGrabacionInicioCLP" runat="server" Text="Sin información"></asp:Label></td>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td>Finaliza grabación:</td>
                <td>
                    <asp:Label ID="lblGrabacionFinCLP" runat="server" Text="Sin información"></asp:Label></td>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td>Tamaño de la data:</td>
                <td>
                    <asp:Label ID="lblTamanioDataCLP" runat="server" Text="Sin información"></asp:Label></td>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td>Longitud grabada:</td>
                <td>Odo 1:</td>
                <td>
                    <asp:Label ID="lblOdo1CLP" runat="server" Text="Sin información"></asp:Label></td>
                <td>Odo 2:</td>
                <td>
                    <asp:Label ID="lblOdo2CLP" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td>lblComentarios</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Button ID="btnAgregarNuevoCLP" runat="server" Text="Agregar reporte nueva corrida CLP" OnClick="btnAgregarCLP_Click" CssClass="btn btn-secondary" /></td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Button ID="btnEditarCLP" runat="server" Text="Editar reporte CLP" CssClass="btn btn-primary" /></td>
                <% }
                    else
                    {%>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnAgregarCLP" runat="server" Text="Agregar reporte CLP" OnClick="btnAgregarCLP_Click" CssClass="btn btn-secondary" /></td>
            </tr>
            <% }%>
            <% }%>
            <%if (Session.Count > 0 && reporte.TipoInspeccion.IdTipoInspeccion != 2)
                { %>
        </table>
        <table class="table" style="align-content: center; text-align: center; width= 70%">
            <tr class="table-success">
                <td colspan="4" class="table-success">
                    <h3>MFL</h3>
                </td>
            </tr>
            <%if (reporteMFL == true)
                { %>
            <tr class="table-success">
                <td colspan="4" class="table-success">Reporte de campo</td>
            </tr>
            <tr>
                <td>Herramienta:</td>
                <td colspan="3">
                    <asp:Label ID="lblHerramientaMFL" runat="server" Text="Herramienta"></asp:Label></td>
            </tr>
            <tr>
                <td>Fecha de operación:</td>
                <td>
                    <asp:Label ID="lblFOMFL" runat="server" Text="FechaOperacion"></asp:Label></td>
                <td>Hora:</td>
                <td>
                    <asp:Label ID="lblHOMFL" runat="server" Text="Hora"></asp:Label></td>
            </tr>
            <tr>
                <td>Fecha de recepción:</td>
                <td>
                    <asp:Label ID="lblFRMFL" runat="server" Text="FechaRecepcion"></asp:Label></td>
                <td>Hora:</td>
                <td>
                    <asp:Label ID="lblHRMFL" runat="server" Text="Hora"></asp:Label></td>
            </tr>
            <tr>
                <td>Duración de corrida:</td>
                <td colspan="3">
                    <asp:Label ID="lblDuracionMFL" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td>Inspección número:</td>
                <td>
                    <asp:Label ID="lblNumInspMFL" runat="server" Text="Sin información"></asp:Label></td>
                <td>Residuos recolectados</td>
                <td>
                    <asp:Label ID="lblResiduosMFL" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td>Daño en herramienta:</td>
                <td>
                    <asp:Label ID="lblDanioMFL" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <tr>
                <td>Sensores dañados:</td>
                <td colspan="3">
                    <asp:Label ID="lblSensoresMFL" runat="server" Text="Sin información"></asp:Label></td>
            </tr>
            <% }
                else
                {%>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnAgregarMFL" runat="server" Text="Agregar reporte MFL" OnClick="btnAgregarMFL_Click" CssClass="btn btn-secondary" /></td>
            </tr>
            <% }%>
            <% }%>
        </table>
    </div>
</asp:Content>
