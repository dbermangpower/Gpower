<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaHerramienta.aspx.cs" Inherits="QMS.Pages.AltaHerramienta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .espaciado-filas td {
            padding-bottom: 20px;
        }
    </style>
    <div class="container mx-auto justify-content-center">
        <div class="col d-flex justify-content-center">
            <div class="card justify-content-center">
                <div class="card-body">
                    <div class="d-grid gap-2 col-15 mx-auto">
                        <div class="row gap-2 col-15 mx-auto">
                            <asp:TextBox ID="txtNombreHerramienta" placeholder="Nombre" runat="server" Class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" ErrorMessage="Ingrese Nombre" ForeColor="Red" ControlToValidate="txtNombreHerramienta" runat="server" />
                        </div>
                        <div class="row gap-2 col-15 mx-auto">
                            <asp:TextBox ID="txtDiametro" placeholder="Diametro" runat="server" Class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDiametro" ErrorMessage="Ingrese Diametro" ForeColor="Red" ControlToValidate="txtDiametro" runat="server" />
                        </div>
                        <div class="row gap-2 col-15 mx-auto">
                            <asp:TextBox ID="txtCantSensores" placeholder="Cantidad de sensores:" runat="server" Class="form-control"></asp:TextBox>
                        </div>
                        <div class="row gap-2 col-15 mx-auto">
                            <asp:DropDownList ID="ddlTipoHerramienta" AutoPostBack="true" runat="server" CssClass="btn btn-light dropdown-toggle" OnSelectedIndexChanged="ddlTipoHerramienta_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="row gap-2 col-15 mx-auto text-center">
                            <asp:Button ID="btnAgregar" runat="server" type="submit" OnClick="btnAgregar_Click" class="btn btn-primary" Text="Agregar" CausesValidation="true" />
                        </div>
                        <div class="row gap-2 col-15 mx-auto text-center">
                            <asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                            <label class="alert alert-danger" id="lblErrores" for="lblErrores" visible="false" runat="server"></label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
