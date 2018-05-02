<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginMovil.aspx.cs" Inherits="ProyectoFinal.Pages.LoginMovil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <style>
        #backgroundimage {
            height: 100%;
            left: 0;
            margin: 0;
            max-height: 100%;
            max-width: 100%;
            padding: 0;
            position:center;
            top: 0;
            width: 100%;
            z-index: -1;
        }
    </style>
</head>
<body>
    <div class="row">
        <img id="backgroundimage" src="../Images/HuellasLoginMovil.jpg" border="0" alt="">
    </div>
    <div>
        <form runat="server">

            <div class="form-group">
                <label for="email">Email address:</label>
                    <asp:TextBox runat="server" ID="email" CssClass="form-control" Width="100%"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="pwd">Password:</label>
                    <asp:TextBox runat="server" ID="password" CssClass="form-control" TextMode="Password" Width="100%"></asp:TextBox>
            </div>
            <asp:Button runat="server" CssClass="btn btn-info" Text="Log In" OnClick="login"/>
        </form>
    </div>
</body>
</html>
