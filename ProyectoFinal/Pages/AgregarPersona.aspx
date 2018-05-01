<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPersona.aspx.cs" Inherits="ProyectoFinal.Pages.AgregarPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        function windowClose() 
        {
            self.close();
        }
    </script>
</head>
<body>
    <div style="background-color: black; width: 100%">
        <img src="http://blitzrdigital.com/wp-content/uploads/2017/01/fingerprint.png" width="100" height="70"/>
    </div>
    <div class="row align-items-center">
        <div class="col-12">
            <h1 style="width:100%; align-self:center" >AGREGAR PERSONA</h1>
        </div>
    </div>
    <br />
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-2">
                <asp:Label runat="server">Nombre:</asp:Label>    
            </div>
            <div class="col-10">
                <asp:TextBox runat="server" ID="nombre" CssClass="border-light" Width="99%"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <asp:Label runat="server">Apellido:</asp:Label>    
            </div>
            <div class="col-10">
                <asp:TextBox runat="server" ID="apellido" CssClass="border-light" Width="99%"></asp:TextBox>
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-12">
                <asp:Button runat="server" Text="AGREGAR" CssClass="btn btn-light btn-outline-dark" Width="100%" OnClick="agregarPersona"/>
            </div>
        </div>
    </form>
</body>
</html>
