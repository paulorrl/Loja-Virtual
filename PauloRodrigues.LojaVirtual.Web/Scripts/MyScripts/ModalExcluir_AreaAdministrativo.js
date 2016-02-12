$(function () {
    // Botões de remoção abrem este modal
    $(".btnRemover").click(function (e) {
        e.preventDefault();
        $("#deleteModal .modal-body input[type=hidden]").val(this.id);
        $("#deleteModal .modal-body span").text(this.name);
        $("#deleteModal").modal('show');
    });

    $("#deleteModal .modal-footer button").click(function (e) {
        e.preventDefault();

        var url = "/Administrativo/Produto/Remover/";
        var id = $(".modal-body input[type=hidden]").val();
        var rowNumber = "#row-" + id;

        $.ajax({
            url: url,
            type: 'post',
            dataType: 'json',
            data: { produtoId: id },
            beforeSend: function() {
                var loading = "<span class='remove'><em>Removendo</em>&nbsp;<i class='glyphicon glyphicon-refresh icon-refresh-animate'></i></span>";
                $("#deleteModal .modal-header h4").after(loading);
            },
            success: function () {
                $(".modal-header span").remove(".remove");
                $("#deleteModal").modal('hide');

                $(rowNumber).animate({ opacity: 0.0 }, 400, function() {
                    $(rowNumber).remove();
                });
            },
            complete: function () {
                var $div = $("#mensagem");
                $div.show();
                $div.html(data.responseText);
            }
        });
    });
});