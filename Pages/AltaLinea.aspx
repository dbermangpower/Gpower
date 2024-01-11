<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaLinea.aspx.cs" Inherits="QMS.Pages.AltaLinea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .espaciado-filas td {
            padding-bottom: 20px;
        }
    </style>
    <table class="espaciado-filas">
        <tr>
            <td colspan="1">
                <label>Cliente:</label></td>
            <td colspan="3">
                <asp:DropDownList ID="ddlCliente" runat="server" CssClass="btn btn-outline-secondary dropdown-toggle" BackColor="white" ForeColor="Gray" Width="200px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Nombre de Línea:</td>
            <td>
                <asp:TextBox runat="server" ID="txtNombreLinea" CssClass="form-control" Width="200px" /></td>
        </tr>
        <tr>
            <td>Diámetro de tubería:</td>
            <td>
                <asp:TextBox runat="server" ID="txtDiametro" CssClass="form-control" Width="200px" /></td>
            <td>
                <asp:RegularExpressionValidator ID="rvDiametro" runat="server" ControlToValidate="txtDiametro"
                    ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="^\d+(\,\d+)?$" /></td>
        </tr>
        <tr>
            <td>Largo de tubería:</td>
            <td>
                <asp:TextBox runat="server" ID="txtLargo" CssClass="form-control" Width="200px" /></td>
        </tr>
        <tr>
            <td>Grado de tubería API 5L:</td>
            <td>
                <asp:DropDownList ID="ddlGrado" runat="server" CssClass="btn btn-outline-secondary dropdown-toggle" BackColor="white" ForeColor="Gray" Width="200px"></asp:DropDownList>
        </tr>
        <tr>
            <td>Tipo de soldadura longitudinal:</td>
            <td>
                <asp:DropDownList ID="ddlSoldadura" runat="server" CssClass="btn btn-outline-secondary dropdown-toggle" BackColor="white" ForeColor="Gray" Width="200px"></asp:DropDownList>
        </tr>
        <tr>
            <td>Producto transportado:</td>
            <td>
                <asp:TextBox runat="server" ID="txtProducto" CssClass="form-control" Width="200px" /></td>
        </tr>
        <tr>
            <td>Presión de diseño PD:</td>
            <td>
                <asp:TextBox runat="server" ID="txtPresion" CssClass="form-control" Width="200px" /></td>
            <td>
                <asp:DropDownList ID="ddlUnidadPresion" runat="server" CssClass="btn btn-outline-secondary"></asp:DropDownList></td>
            <td>
                <asp:RegularExpressionValidator ID="rvPD" runat="server" ControlToValidate="txtPresion"
                    ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="^\d+(\,\d+)?$" ForeColor="Red" /></td>
            <td>
        </tr>
        <tr>
            <td>Factor de diseño:</td>
            <td>
                <asp:TextBox runat="server" ID="txtFactor" CssClass="form-control" Width="200px" /></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvFactor" runat="server" ControlToValidate="txtFactor"
                    ErrorMessage="Este campo es obligatorio." ForeColor="Red" /></td>
            <td>
                <asp:RegularExpressionValidator ID="revFactor" runat="server" ControlToValidate="txtFactor"
                    ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="^\d+(\.\d+)?$" ForeColor="Red" /></td>
        </tr>
        <tr>
            <td>MAOP:</td>
            <td>
                <asp:TextBox runat="server" ID="txtMAOP" CssClass="form-control" Width="200px" /></td>
        </tr>
        <tr>
            <td>Espesor Nominal:</td>
            <td>
                <asp:TextBox runat="server" ID="txtEspesorNominal" CssClass="form-control" TextMode="Number" Width="200px" /></td>
            <td>
                <asp:RegularExpressionValidator ID="revEspNom" runat="server" ControlToValidate="txtEspesorNominal"
                    ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="^\d+(\.\d+)?$" ForeColor="Red" /></td>
        </tr>
        <tr>
            <td>Espesor Mínimo:</td>
            <td>
                <asp:TextBox runat="server" ID="txtEspesorMin" CssClass="form-control" Width="200px" /></td>
            <td>
                <asp:RegularExpressionValidator ID="revEspMin" runat="server" ControlToValidate="txtEspesorMin"
                    ErrorMessage="Por favor, introduce un valor válido." ValidationExpression="^\d+(\.\d+)?$" ForeColor="Red" /></td>
            <td>Espesor Máximo:</td>
            <td>
                <asp:TextBox runat="server" ID="txtEspesorMax" CssClass="form-control" Width="200px" /></td>
        </tr>
        <tr>
            <td>Año instalación:</td>
            <td>
                <asp:TextBox runat="server" ID="txtAnioInstalacion" CssClass="form-control" TextMode="Number" Width="200px" /></td>
        </tr>
        <tr>
            <td>Inspección previa:</td>
            <td>
                <asp:DropDownList ID="ddlInspeccionPrevia" runat="server" CssClass="btn btn-outline-secondary dropdown-toggle" BackColor="white" ForeColor="Gray" Width="200px" OnSelectedIndexChanged="ddlInspeccionPrevia_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Sí" Value="1"></asp:ListItem>
                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                </asp:DropDownList></td>
            <td>
                <asp:Label ID="lblAnioInspPrevia" runat="server" Text="Año inspección previa:"></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="txtAnioInspeccionPrevia" CssClass="form-control" TextMode="Number" Width="200px" /></td>
        </tr>
        <tr>
            <td>SMYS:</td>
            <td>
                <asp:TextBox runat="server" ID="txtSMYS" CssClass="form-control" Width="200px" /></td>
        </tr>
    </table>

    <asp:Button Text="Agregar" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-outline-secondary" />
    <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-outline-danger" />
</asp:Content>
