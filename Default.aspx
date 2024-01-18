<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QMS._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Dashboard:</h1>
            <p class="lead">
                <asp:Chart ID="ChartClientes" runat="server">
                    <Series>
                        <asp:Series Name="Series1" ChartArea="ChartArea">
                            <Points>
                            </Points>
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea">
                            <AxisX Title="Clientes">
                                <MajorGrid Enabled="False" />
                            </AxisX>
                            <AxisY Title="Cantidad de Reportes">
                                <MajorGrid Enabled="False" />
                            </AxisY>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </p>
        </section>

        <div class="row">
            <section class="col-md-4 card" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle" style="text-align: center">Próxima inspección:</h2>
                <h4 style="text-align: center">
                    <asp:Label ID="lblClienteProx" runat="server" Text="Label"></asp:Label></h4>
                <p>
                    Línea: 
                    <asp:Label ID="lblLineaProx" runat="server" Text="Label"></asp:Label>
                </p>
                <p>
                    Fecha de inspección: 
                    <asp:Label ID="lblFechaProx" runat="server" Text="Label"></asp:Label>
                </p>
                <p>
                    <asp:LinkButton ID="btnDetalles" runat="server" OnClick="btnDetalles_Click" CssClass="btn btn-default">Detalles &raquo;</asp:LinkButton>
                </p>
            </section>
            <section class="col-md-4 card" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Cantidad de inspecciones <%= DateTime.Now.Year %>:</h2>
                <p>
                    <asp:Label ID="lblCantInspecciones" runat="server" Text="Label"></asp:Label>
                </p>

            </section>
            <section class="col-md-4 card" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Últimas herramientas utilizadas:</h2>
                <p>
                    BIDI:
                    <asp:Label ID="lblUltimoBIDI" runat="server" Text="Label"></asp:Label>
                </p>
                <p>
                    CLP:
                    <asp:Label ID="lblUltimoCLP" runat="server" Text="Label"></asp:Label>
                </p>
                <p>
                    MFL:
                    <asp:Label ID="lblUltimoMFL" runat="server" Text="Label"></asp:Label>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
