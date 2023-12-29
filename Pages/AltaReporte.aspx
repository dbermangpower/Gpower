<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaReporte.aspx.cs" Inherits="QMS.AltaReporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        @import url(https://fonts.googleapis.com/css?family=Quicksand:400,300,700);

        * {
            box-sizing: border-box;
            font-family: Quicksand, sans-serif;
        }

        body {
            background-color: #797979;
            color: #444;
            display: flex;
            justify-content: center;
            align-items: center;
            font-size: 18px;
            font-weight: 400;
            margin: 0;
            padding: 0;
        }

        .wrap {
            margin: 15px;
            max-width: 600px;
            width: 100%;
        }

            .wrap form {
                box-shadow: 0 1px 3px rgba(0,0,0,.3);
            }

        .form-header {
            background-color: #45CAE6;
            border-radius: 4px 4px 0 0;
            padding: 1em;
        }

            .form-header h2 {
                color: #fff;
                font-weight: 700;
                font-size: 1.75em;
                margin: 0;
            }

        .form-body {
            background-color: #fff;
            padding: 1em;
        }

            .form-body label,
            .form-body input,
            .form-body select,
            .form-body textarea {
                display: block;
                width: 100%;
            }

            .form-body label {
                font-size: .8em;
                font-weight: 700;
                line-height: 1;
                margin: .75em 0 .25em;
            }

            .form-body input,
            .form-body select,
            .form-body textarea {
                background-color: #f4f4f4;
                border: none;
                border-radius: 4px;
                padding: .25em;
            }

            .form-body fieldset {
                border: none;
                margin: 0 0 1em;
                padding: 0;
            }

                .form-body fieldset:last-of-type {
                    margin-bottom: 0;
                }

                .form-body fieldset legend {
                    font-size: 1.25em;
                    font-weight: 700;
                }

            .form-body .radiolist label {
                display: flex;
                align-items: center;
                margin-bottom: 0.5em;
            }

            .form-body .radiolist input[type="radio"] {
                margin-right: 0.5em; /* Espacio entre el botón de radio y el texto */
            }

        .form-footer {
            background-color: #e2e2e2;
            border-radius: 0 0 4px 4px;
            padding: 1em;
        }

            .form-footer input[type="submit"] {
                background-color: #F24865;
                border: none;
                border-radius: 4px;
                color: #fff;
                padding: 1em 1.5em;
            }
    </style>
    <div class="wrap">
        <form>
            <div class="form-header">
                <h2>Nuevo reporte</h2>
            </div>
            <div class="form-body">
                <fieldset>
                    <legend><i class="fa fa-user"></i>User Information</legend>
                    <label for="Cliente">Cliente</label>
                    <asp:DropDownList ID="ddlClente" runat="server" OnSelectedIndexChanged="ddlClente_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <label for="Linea">Linea</label>
                    <asp:DropDownList ID="ddlLinea" runat="server"></asp:DropDownList>
                </fieldset>
                <fieldset>
                    <legend><i class="fa fa-lock"></i>Datos inspección</legend>
                    <label for="TipoInspeccion">Tipo de inspección</label>
                    <div>
                        <asp:RadioButtonList ID="rdbTipoInspeccion" runat="server" AutoPostBack="false" RepeatDirection="Vertical">
                        </asp:RadioButtonList>
                    </div>
                </fieldset>
            </div>
            <div class="form-footer">
                <asp:Button ID="btnAgregar" runat="server" Text="Aceptar" OnClick="btnAgregar_Click" />
            </div>
        </form>
    </div>
</asp:Content>
