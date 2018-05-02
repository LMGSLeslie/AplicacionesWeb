<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaPrincipal.aspx.cs" Inherits="ProyectoFinal.Pages.PantallaPrincipal" %>

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
        button {
            background-color: #665e5e;
            color: white;
            width: 250px;
        }

        input[type="file"] {
            display: none;
        }

        btn btn-dark btn-outline-dark {
            width: 250px;
        }

        .col-1 {
            margin-bottom: -999999px;
        }

        .container-fluid {
            min-height: 100%;
            overflow: hidden;
        }

        body, html {
            height: 100%;
        }

        responsive-width {
            font-size: 1.3vw;
        }
    </style>
</head>
<body>
    <div style="background-color: black"><img src="http://blitzrdigital.com/wp-content/uploads/2017/01/fingerprint.png" alt="huellita" width="100" height="70"/></div>
    <div class="container-fluid">
        <form id="form1" runat="server">
            <div class="row">
                <div class="col-1" style="background-color:black;min-height:150%">
                    <br />
                    <asp:Button ID="MñI" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="MñI" Width="100%" OnClientClick="disableBtn()" OnClick="meñiqueIzquierdo"/>
                    <asp:Button ID="AI" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="AI" Width="100%" OnClick="anularIzquierdo"/>
                    <asp:Button ID="MI" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="MI" Width="100%" OnClick="medioIzquierdo"/>
                    <asp:Button ID="II" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="II" Width="100%" OnClick="indiceIzquierdo"/>
                    <asp:Button ID="PI" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="PI" Width="100%" OnClick="pulgarIzquierdo"/>
                    <asp:Button ID="PlI" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="PlI" Width="100%" OnClick="palmaIzquierda"/>
                    <asp:Button ID="MñD" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="MñD" Width="100%" OnClick="meñiqueDerecho"/>
                    <asp:Button ID="AD" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="AD" Width="100%" OnClick="anularDerecho"/>
                    <asp:Button ID="MD" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="MD" Width="100%" OnClick="medioDerecho"/>
                    <asp:Button ID="ID" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="ID" Width="100%" OnClick="indiceDerecho"/>
                    <asp:Button ID="PD" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="PD" Width="100%" OnClick="pulgarDerecho"/>
                    <asp:Button ID="PlD" runat="server" CssClass="btn btn-dark btn-outline-dark responsive-width" Text="PlD" Width="100%" OnClick="palmaDerecha"/>
                </div>
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
                <div class="col-3">

                    <br />
                    <div class="row">
                        <asp:Button runat="server" Text="CAMBIAR PLANTILLA" CssClass="btn btn-dark btn-outline-dark" OnClick="CambiarPlantilla" Width="95%"/>
                    </div>
                    <br />
                    <div class="row">
                        <asp:Button runat="server" Text="GUARDAR PLANTILLA" CssClass="btn btn-dark btn-outline-dark" OnClick="guardarPlantilla" Width="95%"/>
                    </div>
                    <br />
                    <div class="row">
                        <asp:Button runat="server" Text="ASIGNAR HUELLAS" CssClass="btn btn-dark btn-outline-dark" OnClick="asignarHuellas" Width="95%"/>
                    </div>
                    <br />
                    <div class="row">
                        <asp:FileUpload ID="FU1" runat="server" />  
                        <asp:Button runat="server" Text="CARGAR HUELLAS" CssClass="btn btn-dark btn-outline-dark" OnClientClick="fileUpload(); return true;" OnClick="cargarImagen" Width="95%"/>
                    </div>
                    <div class="row">
                        <asp:Label runat="server">X: </asp:Label>
                        <asp:TextBox runat="server" ID="equis" Width="55px" readOnly="true"></asp:TextBox>
                        <asp:Label runat="server">Y: </asp:Label>
                        <asp:TextBox runat="server" Width="55px" ID="ye" readOnly="true"></asp:TextBox>                       
                        <asp:Label runat="server">W: </asp:Label>
                        <asp:TextBox runat="server" Width="55px" ID="ww" readOnly="true"></asp:TextBox>
                        <asp:Label runat="server">H: </asp:Label>
                        <asp:TextBox runat="server" Width="55px" ID="ache" readOnly="true"></asp:TextBox> 
                    </div>
                </div>  
            </div>
        </form>
    </div>
</body>
</html>
