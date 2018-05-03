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
                        <li><asp:FileUpload ID="FU1" runat="server" />  
                        <asp:Button runat="server" Text="CARGAR HUELLAS" CssClass="btn btn-dark btn-outline-dark" OnClientClick="fileUpload(); return true;" OnClick="cargarImagen" Width="95%"/></li>
                        <li><asp:Button runat="server" Text="CAMBIAR PLANTILLA" CssClass="btn btn-dark btn-outline-dark" OnClick="CambiarPlantilla" Width="95%"/></li>
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


        <div>
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
        <br />
        <div>
            <label>Nombre de la plantilla:</label>
            <asp:TextBox runat="server" ID="plantillaNombre"></asp:TextBox>

        </div>
                        <asp:HiddenField runat="server" ID="PDX"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="PDY"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="PDW"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="PDH"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="PIX"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="PIY"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="PIW"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="PIH"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="IDX"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="IDY"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="IDW"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="IDH"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="IIX"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="IIY"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="IIW"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="IIH"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="MDX"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="MDY"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="MDW"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="MDH"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="MIX"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="MIY"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="MIW"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="MIH"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="ADX"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="ADY"> </asp:HiddenField>
                                                                
                        <asp:hiddenField runat="server" ID="ADW"> </asp:hiddenField>
                        <asp:HiddenField runat="server" ID="ADH"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="AIX"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="AIY"> </asp:HiddenField>
                                                                
                        <asp:HiddenField runat="server" ID="AIW"> </asp:HiddenField>
                        <asp:HiddenField runat="server" ID="AIH"> </asp:HiddenField>
                    
                        <asp:HiddenField runat="server" ID="MñDX"></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="MñDY"></asp:HiddenField>
                    
                        <asp:HiddenField runat="server" ID="MñDW"></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="MñDH"></asp:HiddenField>
                    
                        <asp:HiddenField runat="server" ID="MñIX"></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="MñIY"></asp:HiddenField>
                    
                        <asp:HiddenField runat="server" ID="MñIW"></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="MñIH"></asp:HiddenField>
                    
                        <asp:HiddenField runat="server" ID="PlDX"></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="PlDY"></asp:HiddenField>
                    
                        <asp:HiddenField runat="server" ID="PlDW"></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="PlDH"></asp:HiddenField>
                    
                        <asp:HiddenField runat="server" ID="PlIX"></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="PlIY"></asp:HiddenField>
                    
                        <asp:HiddenField runat="server" ID="PlIW"></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="PlIH"></asp:HiddenField>
                    
    </form>
</body>
</html>
