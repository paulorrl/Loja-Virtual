$(document).ready(function () {
    $('body').append('<div id="toTop" class="btn btn-sm btn-primary"><span class="glyphicon glyphicon-chevron-up"></span> Subir</div>');
    $(window).scroll(function () {
        if ($(this).scrollTop() != 0) {
            $('#toTop').fadeIn();
        } else {
            $('#toTop').fadeOut();
        }
    });
    $('#toTop').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    });
});