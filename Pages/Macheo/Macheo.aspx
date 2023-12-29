<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Macheo.aspx.cs" Inherits="QMS.Pages.Macheo.Macheo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:GridView ID="dgvMacheo" runat="server" AutoGenerateColumns="true" CssClass="table table-bordered table-condensed table-hover" HeaderStyle-HorizontalAlign="Center">
        </asp:GridView>
    </div>



    <div class="mb-3">
        <label for="formFile" class="form-label">Abrir Tally:</label>
        <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control"/>      
        <label for="formFile" class="form-label">Abrir Tally cliente:</label>
        <asp:FileUpload ID="fileUploadCliente" runat="server" CssClass="form-control"/>
        <div class="row gap-2 col-2 mx-auto text-center">
        <asp:DropDownList ID="ddlFormato" runat="server"></asp:DropDownList>
        </div>
            <asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
        <br />
        <div class="row gap-2 col-2 mx-auto text-center">
            <asp:Button ID="btnAceptar" runat="server" type="submit" OnClick="btnAceptar_Click" class="btn btn-primary" Text="Aceptar" CausesValidation="true" />
        </div>
    </div>


</asp:Content>
