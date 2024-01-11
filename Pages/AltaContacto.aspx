<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaContacto.aspx.cs" Inherits="QMS.Pages.AltaContacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="mb-3">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtTelefono" class="form-label">Telefono</label>
            <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="ddlCliente" class="form-label">Cliente</label>
            <asp:DropDownList ID="ddlCliente" runat="server" CssClass="btn btn-outline-secondary dropdown-toggle"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
        </div>

</asp:Content>
