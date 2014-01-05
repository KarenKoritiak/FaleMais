$(function () {
    $("select[name='Tarifa.OrigemNumero']").on('change', function (event) {
        var url = "tarifa/retornadestinos?origemNumero=" + $(this).val();
        $.get(url, function (destinos) {
            var options = "";
            $.each(destinos, function (index, value) {
                options += "<option value='" + value.Numero + "'>" + value.Numero + "</option>";
            });
            $("select[name='Tarifa.DestinoNumero']").html(options);
        });
    });

    $("#OpcoesDeBusca a").on('click', function (event) {
        event.preventDefault();

        $('.OpcaoDeBusca:visible').addClass('hide');
        var panel = $(this).attr('href');
        $(panel).removeClass('hide');
    });

    $("#CidadeOrigemNome, #CidadeDestinoNome").autocomplete({
        source: '/cidade/retornaautocomplete',
        minLength: 3
    });

    $("#CalculaTarifaForm").on('submit', function () {
        var origemNumero = "";
        var destinoNumero = "";

        if ($("#OpcoesDDDOrigem").is(":visible")) {
            origemNumero = $("#OpcoesDDDOrigem").val();
            destinoNumero = $("#OpcoesDDDDestino").val();
        }
        else {
            origemNumero = $("#CidadeOrigemNome").val();
            destinoNumero = $("#CidadeDestinoNome").val();
        }

        $("input[name='Tarifa.OrigemNumero']").val(origemNumero);
        $("input[name='Tarifa.DestinoNumero']").val(destinoNumero);
    });
});