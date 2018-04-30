<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionPersona.aspx.cs" Inherits="ProyectoFinal.Pages.SeleccionPersona" EnableEventValidation="false"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Seleccion de persona</title>
    <meta charset="utf-8" />
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/functions.js"></script>
    <style>
        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content/Box */
        .modal-content {
            background-color: #fefefe;
            margin: 15% auto; /* 15% from the top and centered */
            padding: 20px;
            border: 1px solid #888;
            width: 80%; /* Could be more or less, depending on screen size */
        }

        /* The Close Button */
        .close {
            color: #aaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: black;
                text-decoration: none;
                cursor: pointer;
            }
            
            .active{
                background-color: lightgray !important;
                border-color: lightgray !important;
            }
    </style>
    <script>
        $(document).ready(function () {
            $('#siguiente').on('click',function () {
                history.back(.1);
            });
        });
    </script>

</head>
<body>
    <div style="background-color: black; width: 100%">
        <img src="http://blitzrdigital.com/wp-content/uploads/2017/01/fingerprint.png" width="100" height="70">
    </div>
    <br/><br/>
    <center>
        <form runat="server">
            <a href="#" style="width: 80%" class="list-group-item disabled">SELECCIONE UNA PERSONA</a>
            <div style="width: 80%; height: 400px; overflow: scroll; text-align: left" class="list-group">
                <asp:GridView ID="personas" runat="server" BorderColor="LightGray" BorderWidth="1px" BorderStyle="Dotted" CellSpacing="10" ClientIDMode="Static" AutoGenerateColumns="true"  Width="100%" OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged" >
                    <RowStyle BorderColor="LightGray" Width="100%" CssClass="btn-outline-dark" HorizontalAlign="Center" Font-Size="Larger" Font-Strikeout="False" Height="50px"/>
                </asp:GridView>
            </div>
            <br/>
            <asp:Label ID="lmao" runat="server">lmaaaaaao</asp:Label>
  
  
        <div class="row">
            
            <div class="col-lg-4">
                <asp:Button ID="volver" runat="server" Text="VOLVER" CssClass="btn btn-dark btn-outline-dark" Font-Size="Medium" OnClientClick="Volver"/>
            </div>

            <div class="col-lg-4" id="myBtn">
                <asp:Button ID="Agregar" runat="server" Text="AGREGAR PERSONA" CssClass="btn btn-dark btn-outline-dark" Font-Size="Medium" OnClientClick="AgregarPersona"/>
            </div>

            <div class="col-lg-4">
                <asp:Button ID="siguiente" runat="server" Text="SELECCIONAR" CssClass="btn btn-dark btn-outline-dark" Font-Size="Medium" />
            </div>
        </div>
            </form>
  
  
        <!-- The Modal -->
        <div id="myModal" class="modal">
        <!-- Modal content -->
            
        </div>
    </center>
    <br/>
</body>
</html>
