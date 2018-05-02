<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionPlantilla.aspx.cs" Inherits="ProyectoFinal.Pages.SeleccionPlantilla" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Selección de plantilla</title>
    <meta charset="utf-8" />
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
</head>
<body>
    <div style="background-color: black; width: 100%">
        <img src="http://blitzrdigital.com/wp-content/uploads/2017/01/fingerprint.png" width="100" height="70"/>
    </div>
    <br/><br/>
    <center>
    <form runat="server">
        <a href="#" style="width: 80%" class="list-group-item disabled">SELECCIONE UNA PERSONA</a>
            <div style="width: 80%; height: 400px; overflow: scroll; text-align: left" class="list-group">
                <asp:GridView ID="plantillas" runat="server" BorderColor="LightGray" BorderWidth="1px" BorderStyle="Dotted" CellSpacing="10" ClientIDMode="Static" AutoGenerateColumns="true"  Width="100%" OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged" >
                    <RowStyle BorderColor="LightGray" Width="100%" CssClass="btn-outline-dark" HorizontalAlign="Center" Font-Size="Larger" Font-Strikeout="False" Height="50px"/>
                </asp:GridView>
            </div>
            <br/>
            <asp:Label ID="lmao" runat="server">lmaaaaaao</asp:Label>
  
            <div class="row">
            
                <div class="col-lg-6">
                    <asp:Button ID="volver" runat="server" Text="VOLVER" CssClass="btn btn-dark btn-outline-dark" Font-Size="Medium" />
                </div>
                
                <div class="col-lg-6">
                    <asp:Button ID="siguiente" runat="server" Text="SELECCIONAR" CssClass="btn btn-dark btn-outline-dark" Font-Size="Medium" />
                </div>
            </div>
    </form>
        </center>
</body>
</html>
