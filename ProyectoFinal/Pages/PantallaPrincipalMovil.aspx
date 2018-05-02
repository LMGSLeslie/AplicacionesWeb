<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaPrincipalMovil.aspx.cs" Inherits="ProyectoFinal.Pages.PantallaPrincipalMovil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>

    <link rel="stylesheet" href="../Content/jquery.Jcrop.css" type="text/css" />
    <script src="../Scripts/jquery.Jcrop.js"></script>
    <script>
        function fileUpload() {
            document.getElementById("FU1").click();
        }
    </script>
    <script type="text/javascript">  
        $(document).ready(function() {  
            $('#<%=imgUpload.ClientID%>').Jcrop({
                onChange: SelectCropArea,
                onSelect: SelectCropArea  
            });  
        });  
  
        function SelectCropArea(e) {
            $('#<%=x1.ClientID%>').val(parseInt(e.x));  
            $('#<%=y1.ClientID%>').val(parseInt(e.y));  
            $('#<%=x2.ClientID%>').val(parseInt(e.x));  
            $('#<%=y2.ClientID%>').val(parseInt(e.y));
            $('#<%=w.ClientID%>').val(parseInt(e.w));  
            $('#<%=h.ClientID%>').val(parseInt(e.h));
            $('#equis').val(e.x)
            $('#ye').val(e.y)
            $('#ww').val(e.w)
            $('#ache').val(e.h)
        }  
</script>
    <script type="text/javascript">
        function disableBtn() 
        {
            
        }
    </script>
        <style>
            .navbar .navbar-header {
                float: none;
            }
            .navbar .navbar-toggle {
                display: block;
            }
            .navbar .navbar-collapse.collapse {
                display: none!important;
            }
            .navbar .navbar-nav {
                float: none!important;
            }
            .navbar .navbar-nav > li {
                float: none;
            }
            .navbar .navbar-collapse.collapse.in {
                display: block !important;
            }
            .navbar .navbar-collapse {
                text-align: left;
            }
            .icon {
                max-height: 50px;
            }
            .body{
                padding-top:65px;
            }

        </style>
</head>
<body>
    <form runat="server">
        <nav class="navbar navbar-inverse navbar-static-top " role="navigation">
            <div id="divContainer" class="container">

                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbarContent">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <img src="http://blitzrdigital.com/wp-content/uploads/2017/01/fingerprint.png" class="icon">
                </div>

                <div id="navbarContent" class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li><asp:Button runat="server" Text="ASIGNAR HUELLAS" CssClass="btn btn-dark btn-outline-dark" OnClick="asignarHuellas" Width="95%"/></li>
                        <li><asp:Button runat="server" Text="GUARDAR PLANTILLA" CssClass="btn btn-dark btn-outline-dark" OnClick="guardarPlantilla" Width="95%"/></li>
                        <li><a href="#">CAMBIAR HUELLAS</a></li>
                        <li><a href="../Pages/SeleccionPlantillaMovil.html">CAMBIAR PLANTILLA</a></li>
                    </ul>
                </div>
            </div>
        </nav>

        <nav class="navbar navbar-inverse navbar-static-top " role="navigation">
            <div id="divContainer1" class="container">

                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbarContent1">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                    </button>
                </div>

                <div id="navbarContent1" class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-right">
                       <li><asp:Button ID="MñI" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="MñI" Width="100%" OnClick="meñiqueIzquierdo" /></li> 
                    <li><asp:Button ID="AI" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="AI" Width="100%" OnClick="anularIzquierdo"/></li>
                    <li><asp:Button ID="MI" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="MI" Width="100%" OnClick="medioIzquierdo"/></li>
                    <li><asp:Button ID="II" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="II" Width="100%" OnClick="indiceIzquierdo"/></li>
                    <li><asp:Button ID="PI" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="PI" Width="100%" OnClick="pulgarIzquierdo"/></li>
                    <li><asp:Button ID="PlI" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="PlI" Width="100%" OnClick="palmaIzquierda"/></li>
                    <li><asp:Button ID="MñD" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="MñD" Width="100%" OnClick="meñiqueDerecho"/></li>
                    <li><asp:Button ID="AD" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="AD" Width="100%" OnClick="anularDerecho"/></li>
                    <li><asp:Button ID="MD" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="MD" Width="100%" OnClick="medioDerecho"/></li>
                    <li><asp:Button ID="ID" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="ID" Width="100%" OnClick="indiceDerecho"/></li>
                    <li><asp:Button ID="PD" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="PD" Width="100%" OnClick="pulgarDerecho"/></li>
                    <li><asp:Button ID="PlD" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="PlD" Width="100%" OnClick="palmaDerecha"/></li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="col-8">
                    <asp:Image ID="imgUpload" runat="server" Width="100%" />
                    <div class="row">
                        <asp:HiddenField ID="x1" runat="server" />  
                        <asp:HiddenField ID="y1" runat="server" />
                        <asp:HiddenField ID="x2" runat="server" />  
                        <asp:HiddenField ID="y2" runat="server" />
                        <asp:HiddenField ID="w" runat="server" />  
                        <asp:HiddenField ID="h" runat="server" />                             
                    </div>
                </div>
    </form>
</body>
</html>
