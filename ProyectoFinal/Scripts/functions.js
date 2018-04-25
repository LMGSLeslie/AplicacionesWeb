/*$('.list-group-item').click(function (e) {
    e.preventDefault();

    $that = $(this);

    $that.parent().find('.list-group-item').removeClass('active');
    $that.addClass('active');
})*/

$(function () {
    console.log('ready');

    $('.list-group li').click(function (e) {
        e.preventDefault()

        $that = $(this);

        $('.list-group').find('li').removeClass('active');
        $that.addClass('active');
    });
})