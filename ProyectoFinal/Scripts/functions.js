
$(function () {
    $('.list-group li').click(function (e) {
        e.preventDefault()

        $that = $(this);

        $('.list-group').find('li').removeClass('active');
        $that.addClass('active');
    });
})

$(function alertaSiguiente() {
    $('#Siguiente').on('click', function () {
        console.log('Sientra');
        var items = document.getElementsByClassName('list-group-item active');
        if (items.length == 0) {
            console.log('y tho');
            window.alert('Por favor seleccione una opción');
        } else {
            console.log('wtf');
            window.location.href = "../Pages/PantallaPrincipal.html";
        }
    })
}
)