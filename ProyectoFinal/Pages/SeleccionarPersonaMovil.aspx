<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarPersonaMovil.aspx.cs" Inherits="ProyectoFinal.Pages.SeleccionarPersonaMovil" EnableEventValidation="false"  MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <style>
        .bar {
            background-color: black;
            height: 5%;
        }

        .icon {
            max-height: 50px;
        }

        .body {
            overflow-y: hidden;
            max-height: 100%;
        }

        .table td {
            text-align: center;
        }

        .table {
            height: 90%;
        }

        .div1 {
            height: 5%;
        }
        .active{
            background-color: lightgray !important;
            border-color: lightgray !important;
        }
    </style>
</head>
<body>
    <div class="row bar align-items-center">
        <div class="col-2">
            <img class="icon" src="../Images/IconoBarra.png" />
        </div>
        <div class="col-10 align-self-center ">
            <h4>Seleccione una persona.</h4>
        </div>
    </div>
    <center>
        <div style="width: 100%; height: 95vh; overflow-y: scroll;padding-right:17px; box-sizing:content-box; text-align: left" class="list-group">
            <form id="form1" runat="server">
                <asp:GridView ID="personas" runat="server" BorderColor="LightGray" BorderWidth="1px" BorderStyle="Dotted" CellSpacing="10" ClientIDMode="Static" AutoGenerateColumns="true"  Width="100%" OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged" >
                    <RowStyle BorderColor="LightGray" Width="100%" CssClass="btn-outline-dark" HorizontalAlign="Center" Font-Size="Medium" Font-Strikeout="False" Height="35px"/>
                </asp:GridView>
                <div class="row">
                    <asp:Button ID="AgregarPersona" runat="server" Text="AGREGAR PERSONA" CssClass="btn btn btn-outline-dark" Width="100%" />
                </div>
                <div class="row">
                    <div class="col-6" style="background-color:lightgray; border-radius:5%">
                        <asp:Button ID="volver" runat="server" Text="CANCELAR" CssClass="btn " Font-Size="Medium" BackColor="LightGray" Width="100%" />
                    </div>

                    <div class="col-6" style="background-color:lightgray; border-radius:5%;">
                        <asp:Button ID="siguiente" runat="server" Text="ACEPTAR" CssClass="btn" Font-Size="Medium" OnClientClick="AgregarPersona" BackColor="LightGray" Width="100%"/>
                    </div>
                </div>
            </form>
        </div>
    </center>


</body>
</html>
