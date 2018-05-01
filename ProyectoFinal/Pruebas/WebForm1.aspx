<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProyectoFinal.Pruebas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Content/jquery.Jcrop.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/jquery.Jcrop.js"></script>
    <script type="text/javascript">  
    $(document).ready(function() {  
        $('#<%=imgUpload.ClientID%>').Jcrop({  
            onSelect: SelectCropArea  
        });  
    });  
  
    function SelectCropArea(c) {  
        $('#<%=X.ClientID%>').val(parseInt(c.x));  
        $('#<%=Y.ClientID%>').val(parseInt(c.y));  
        $('#<%=W.ClientID%>').val(parseInt(c.w));  
        $('#<%=H.ClientID%>').val(parseInt(c.h));  
    }  
</script>
</head>
<body>
    <form id="form1" runat="server">  
    <h3>Image Upload, Crop & Save using ASP.NET & Jquery</h3>  
    <table>  
        <tr>  
            <td> Select Image File : </td>  
            <td>  
                <asp:FileUpload ID="FU1" runat="server"/>
            </td>  
            <td>  
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" /> </td>  
        </tr>  
        <tr>  
            <td colspan="3">  
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" /> </td>  
        </tr>  
    </table>  
    <asp:Panel ID="panCrop" runat="server" Visible="false">  
        <table width="50%">  
            <tr>  
                <td>  
                    <asp:Image ID="imgUpload" runat="server" Width="100%" /> </td>  
            </tr>  
            <tr>  
                <td>  
                    <asp:Button ID="btnCrop" runat="server" Text="Crop & Save" OnClick="btnCrop_Click" /> </td>  
            </tr>  
            <tr>  
                <td>  
                    <asp:HiddenField ID="X" runat="server" />  
                    <asp:HiddenField ID="Y" runat="server" />  
                    <asp:HiddenField ID="W" runat="server" />  
                    <asp:HiddenField ID="H" runat="server" /> </td>  
            </tr>  
        </table>  
        <asp:Label ID="ay" runat="server">ayyyyyyyyyy</asp:Label>
    </asp:Panel>  
</form>   
</body>
</html>
