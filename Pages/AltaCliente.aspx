<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="QMS.Pages.AltaCliente" %>

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
                            <asp:TextBox ID="txtNombreCliente" placeholder="Nombre" runat="server" Class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" ErrorMessage="Ingrese Nombre" ForeColor="Red" ControlToValidate="txtNombreCliente" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label for="formFile" class="form-label">Agregar logo del cliente:</label>
                            <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control" accept="image/*"  />
                            <asp:Image ID="imgPreview" runat="server" Visible="false" />
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
