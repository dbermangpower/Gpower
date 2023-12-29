<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleLinea.aspx.cs" Inherits="QMS.Pages.DetalleLinea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card align-content-center" style="width: 30rem;">
        <div class="card-body">
            <h3 class="card-title">
                <asp:Label ID="lblLinea" runat="server" Text=""></asp:Label></h3>
            <h5 class="card-text">Compañia: <asp:Label ID="lblCompania" runat="server" Text=""></asp:Label></h5>
        </div>
        <ul class="list-group list-group-flush">
            <li class="list-group-item">Diámetro de tubería: <asp:Label ID="lblDiametro" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">Largo de tubería: <asp:Label ID="lblLargo" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">Grado de tubería API 5L: <asp:Label ID="lblGrado" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">Tipo de soldadura longitudinal: <asp:Label ID="lblTipoSoldadura" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">Producto transportado: <asp:Label ID="lblProductoTrans" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">Presión de diseño PD: <asp:Label ID="lblPD" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">Factor de diseño FD: <asp:Label ID="lblFD" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">MAOP: <asp:Label ID="lblMAOP" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">Espesor de pared Nominal: <asp:Label ID="lblEspesorParedNom" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">Espesor Mínimo: <asp:Label ID="lblEspesorMin" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">Espesor Máximo: <asp:Label ID="lblEspesorMax" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">Año de instalación: <asp:Label ID="lblAnioInst" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">Inspección Previa: <asp:Label ID="lblInspeccionPrevia" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">Año: <asp:Label ID="lblAnioInsp" runat="server" Text=""></asp:Label></li>
            <li class="list-group-item">SMYS: <asp:Label ID="lblSMYS" runat="server" Text=""></asp:Label></li>
        </ul>
        <div class="card-body">
            <a href="#" class="card-link">Card link</a>
            <a href="#" class="card-link">Another link</a>
        </div>
    </div>
</asp:Content>
