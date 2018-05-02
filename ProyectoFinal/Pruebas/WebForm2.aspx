<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ProyectoFinal.Pruebas.WebForm2" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdn.rawgit.com/tapmodo/Jcrop/master/js/jquery.Jcrop.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#FileUpload1').change(function () {
            $('#Image1').hide();
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#Image1').show();
                $('#Image1').attr("src", e.target.result)
                //.width(370)
                //.height(609)
                ;
                $('#Image1').Jcrop({
                onChange: SetCoordinates,
                onSelect: SetCoordinates
                });
            }           
            reader.readAsDataURL($(this)[0].files[0]);
            var type = $(this)[0].files['0'].type;
            document.getElementById('hdnFileType').value = type;
            });

            $('#btnCrop').click(function () {
                var x1 = $('#imgX1').val();
                var y1 = $('#imgY1').val();
                var width = $('#imgWidth').val();
                var height = $('#imgHeight').val();
                var canvas = $("#canvas")[0];
                var context = canvas.getContext('2d');
                var img = new Image();
                img.onload = function () {
                    canvas.height = height;
                    canvas.width = width;
                    context.drawImage(img, x1, y1, width, height, 0, 0, width, height);
                    $('#imgCropped').val(canvas.toDataURL());
                    
                    console.log($('#imgCropped').val());
                    $('[id*=btnUpload]').show();
                };
                img.src = $('#Image1').attr("src");
            });
        });
        function SetCoordinates(c) {
            $('#imgX1').val(c.x);
            $('#imgY1').val(c.y);
            $('#imgWidth').val(c.w);
            $('#imgHeight').val(c.h);
            $('#btnCrop').show();
        };
        $(function () {

         $("#Upload").click(function () {

              var image = document.getElementById("myCanvas").toDataURL("image/png");

              image = image.replace('data:image/png;base64,', '');

              $.ajax({

type: 'POST',

url: 'CanvasSave.aspx/UploadImage',

data: '{ "imageData" : "' + image + '" }',

contentType: 'application/json; charset=utf-8',

dataType: 'json',

                 success: function (msg) {

                      alert('Image saved successfully !');

                 }

            });

         });

     });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="file" id="FileUpload1" accept=".jpg,.png,.gif" />
        <br />
        <br />
        <table border="0" cellpadding="0" cellspacing="5">
            <tr>
                <td>
                    <img id="Image1" src="" alt="" style="display: none" />
                </td>
                <td>
                    <canvas id="canvas" height="4" width="4"></canvas>
                </td>
            </tr>
        </table>
        <br />
        <input type="button" id="btnCrop" value="Crop" style="display: none" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" Style="display: none" />
        <input type="hidden" name="imgX1" id="imgX1" />
        <input type="hidden" name="imgY1" id="imgY1" />
        <input type="hidden" name="imgWidth" id="imgWidth" />
        <input type="hidden" name="imgHeight" id="imgHeight" />
        <input type="hidden" name="imgCropped" id="imgCropped" />
        <asp:HiddenField ID="hdnFileType" runat="server" />
    </form>
</body>
</html>
