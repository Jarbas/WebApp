

$(document).ready(function () {
    $('#entidadePessoa').ready(function () {
        if ($("input[name='CnpjCpf']").val() != '') {
            if ($('#entidadePessoa').val() == '1')
                montarMascaraCnpj($("input[name='CnpjCpf']"));
            else
                montarMascaraCpf($("input[name='CnpjCpf']"));
        } else {
            if ($('#entidadePessoa').val() == '1')
                inputCnpj($("input[name='CnpjCpf']"));
            else
                inputCpf($("input[name='CnpjCpf']"));
        }
    });
});

$('#entidadePessoa').change(function () {               
    if ($(this).val() == 'Juridica')
        inputCnpj($("input[name='CnpjCpf']"));
    else
        inputCpf($("input[name='CnpjCpf']"));
});


$('#cnpjCpf').focusout(function () {
    if ($('#entidadePessoa').val() == 'Juridica')
        montarMascaraCnpj(this);
    else
        montarMascaraCpf(this);
});

$('#inputLogin').focusout(function () {

    $.ajax({
        url: '/Admin/Usuario/ValidarLogin',
        method: 'get',
        data: { login: $('#inputLogin').val() },
        success: function (r) {
            $('#inputLogin').InputGlyphiconSetValidate(r);
        }
    });
});

$('#inputEmail').focusout(function () {
    $.ajax({
        url: '/Admin/Usuario/ValidarEmail',
        method: 'get',
        data: { email: $('#inputEmail').val() },
        success: function (r) {
            $('#inputEmail').InputGlyphiconSetValidate(r);
        }
    });
});


