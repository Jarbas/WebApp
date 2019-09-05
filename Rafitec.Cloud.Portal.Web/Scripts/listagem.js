
$('#idPais').focusin(function () {


    $.getJSON('/Cadastro/Pais/GetPais', function (r) {
        var valueExistente = $('#idPais').val();
        $('#idPais option').remove();
        $('#idPais').append('<option value=""></option>');
        for (var i = 0; i < r.length; i++)
            if (r[i].idPais != valueExistente)
                $('#idPais').append('<option value="' + r[i].idPais + '">' + r[i].Nome + '</option>');
            else
                $('#idPais').append('<option value="' + r[i].idPais + '" selected = "selected">' + r[i].Nome + '</option>');
    });

});


$(document).ready(function () {
    

    $('#idPais').change(function () {

        var id = $(this).val();
        $.getJSON('/Cadastro/Estado/GetEstado', {idPais : id}, function (r) {
            $('#idEstado option').remove();
            $('#idEstado').append('<option value=""></option>');
            for (var i = 0; i < r.length; i++)
                $('#idEstado').append('<option value="' + r[i].idEstado + '">' + r[i].Sigla + '</option>');
        });

    });


    $('#idEstado').change(function () {

        var id = $(this).val();
        $.getJSON('/Cadastro/Cidade/GetCidade', { idEstado: id }, function (r) {
        
            $('#idCidade option').remove();
            $('#idCidade').append('<option value=""></option>');
            for (var i = 0; i < r.length; i++)
                $('#idCidade').append('<option value="' + r[i].idCidade + '">' + r[i].Nome + '</option>');
        });
    });


    $('#inputUnNegocio').change(function () {

        var _id = $(this).val();
        $.getJSON('/Cadastro/UnidadeVenda/Get/', { id: _id }, function (r) {         
            $('#inputUnVenda option').remove();
            $('#inputUnVenda').append('<option value=""></option>');
            for (var i = 0; i < r.length; i++)
                $('#inputUnVenda').append('<option value="' + r[i].idUnidadeVenda + '">' + r[i].Descricao + '</option>');
        });
    });


});
