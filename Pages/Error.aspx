<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="QMS.Pages.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <img src="../Img/ErrorIMG.jpg" alt="Se ha encontrado un error." widht="50px"/>
    </div>   
    <h3>Error:</h3>
<asp:label text="text" id="lblError" runat="server" />
</asp:Content>
