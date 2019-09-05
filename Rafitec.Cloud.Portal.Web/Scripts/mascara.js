function inputCnpj(input) {

    $(input).removeAttr('maxlength');
    $(input).removeAttr('placeholder');
    $(input).val('');
    $(input).attr('maxlength', '14');
    $(input).attr('placeholder', '__.___.___/____-__');

};

function inputCpf(input) {

    $(input).removeAttr('maxlength');
    $(input).removeAttr('placeholder');
    $(input).val('');
    $(input).attr('maxlength', '11');
    $(input).attr('placeholder', '___.___.___-__');

};

function montarMascaraCnpj(input) {

    var cnpj = $(input).val();

    cnpj = cnpj.replace(/^(\d{2})(\d)/, "$1.$2");
    cnpj = cnpj.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3");
    cnpj = cnpj.replace(/\.(\d{3})(\d)/, ".$1/$2");
    cnpj = cnpj.replace(/(\d{4})(\d)/, "$1-$2");

    $(input).val(cnpj);

};

function montarMascaraCpf(input) {
    
    var cpf = $(input).val();
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2");
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2");
    cpf = cpf.replace(/(\d{3})(\d{1,2})$/, "$1-$2");

    $(input).val(cpf);
};


/*telefone*/

function inputTelefone(input) {

    $(input).removeAttr('maxlength');
    $(input).removeAttr('placeholder');
    $(input).val('');
    $(input).attr('maxlength', '9');
    $(input).attr('placeholder', '(__)_____-____');

};

$(document).ready(function () {

    $('.telefone').each(function () {

        $(this).removeAttr('maxlength');
        $(this).removeAttr('placeholder');
      //  $(this).val('');
        $(this).attr('maxlength', '11');
        $(this).attr('placeholder', '(__)_____-____');

    });
});


$('.telefone').focusout(function () {

    if ($(this).val().length >= 10) {
        var tel = $(this).val();

        tel = tel.replace(/D/g, "");   
        tel = tel.replace(/(\d{2})(\d)/, "($1) $2");
        if (tel.length == 10)
            tel = tel.replace(/(\d{4})(\d)/, "$1-$2");
        else tel = tel.replace(/(\d{5})(\d)/, "$1-$2");
        
        $(this).val(tel);
    };

});


$(document).ready(function () {

    $('.cep').each(function () {

        $(this).removeAttr('maxlength');
        $(this).removeAttr('placeholder');
       // $(this).val('');
        $(this).attr('maxlength', '8');
        $(this).attr('placeholder', '_____-___');
    });

});

$('.cep').focusout(function () {
    if ($(this).val().length >= 8) {

        var cep = $(this).val();
        cep = cep.replace(/D/g, "");
        cep = cep.replace(/(\d{5})(\d)/, "$1-$2");
        
        $(this).val(cep);

    };

});
