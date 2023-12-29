<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterQMS.Master" AutoEventWireup="true" CodeBehind="DetalleQMS.aspx.cs" Inherits="QMS.Pages.DetalleQMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table" style="align-content: center; width= 70%">
        <tr>
            <td colspan="4">
                <h3>BIDI</h3>
            </td>
        </tr>
        <%if (reporteBIDI == true)
            { %>
        <tr>
            <td colspan="4">Reporte de campo</td>
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
            <td>Duración de corrida</td>
            <td colspan="3">
                <asp:Label ID="lblDuracion" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Pasadas requeridas</td>
            <td>
                <asp:Label ID="lblPasadasRequeridas" runat="server" Text="Label"></asp:Label></td>
            <td>Residuos recolectados</td>
            <td>
                <asp:Label ID="lblResiduosRecolectados" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Daño en placa</td>
            <td>
                <asp:Label ID="lblDanioPlaca" runat="server" Text="Label"></asp:Label></td>
            <td>
                <asp:Label ID="lblTipo" runat="server" Text="Tipo de deformación"></asp:Label></td>
            <td>
                <asp:Label ID="lblTipoDeformacion" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Máxima reducción</td>
            <td colspan="3">
                <asp:Label ID="lblMaximaReduccion" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <% } else
            {%>
                <tr>
                    <td colspan="4"><asp:Button ID="btnAgregarBIDI" runat="server" Text="Agregar reporte BIDI" OnClick="btnAgregarBIDI_Click" CssClass="btn btn-secondary"/></td>
                </tr>
           <% }%>
    </table>
            
</asp:Content>
