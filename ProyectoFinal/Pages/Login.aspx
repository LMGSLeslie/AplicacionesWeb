<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoFinal.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="row align-items-center">
        <div class=" =col-lg-8">
            <img class="img-responsive" src="../Images/HuellasLogin.jpg" alt="Huella digital" height="598" width="800" />
        </div>
        <div class="col-lg-4 center">
            <form id="form1" runat="server">
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
    </div>
</body>
</html>
