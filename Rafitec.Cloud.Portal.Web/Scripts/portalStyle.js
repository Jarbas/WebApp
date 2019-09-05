
/**
colocar na classe static quando retirar de todas as chamadas
 */
function getTagWithClass(Atag, Aclass, count = 0) {

    if (count > 50)
        return false;
    else count = count + 1;

    for (var i = 0; i < Atag.children.length; i++) {
        if ($(Atag.children[i]).hasClass(Aclass))
            return Atag.children[i];
    };

    return getTagWithClass(Atag.parentNode, Aclass, count);
}

class styleUtils {

    static contemTagFilho(aTag) {
        if (aTag.children.length > 0)
            return true;
        else false;
    };

    static getTagWithClass(Atag, Aclass, count = 0) {

        if (count > 50)
            return false;
        else count = count + 1;

        for (var i = 0; i < Atag.children.length; i++) {
            if ($(Atag.children[i]).hasClass(Aclass))
                return Atag.children[i];
        };

        return getTagWithClass(Atag.parentNode, Aclass, count);
    };

};

var style = function() {

    var configuraDescricaoBtn = function (Tag) {

        if ($(Tag).hasClass('desc-btn'))
        {
            if (parseInt(window.innerWidth) < 999)
                $(Tag).addClass('minimizar');
            else
                $(Tag).removeClass('minimizar');
        };
    };

    var contemClassInputTamanho = function (aTag) {
        if ($(aTag).hasClass('input-10') || $(aTag).hasClass('input-20') ||
            $(aTag).hasClass('input-30') || $(aTag).hasClass('input-40') ||
            $(aTag).hasClass('input-50') || $(aTag).hasClass('input-60') ||
            $(aTag).hasClass('input-70') || $(aTag).hasClass('input-80') ||
            $(aTag).hasClass('input-90') || $(aTag).hasClass('input-100'))
            return true;
        else return false;
    }

    var configuraTamanhoInput = function (Tag) {
        if (contemClassInputTamanho(Tag))
        {
            if (parseInt(window.innerWidth) < 999) 
                $(Tag).addClass('input-100');
            else
                $(Tag).removeClass('input-100');
        };
    };


    this.configurar = function (Tag) {
        for (var i = 0; i < Tag.children.length; i++) {
            if (styleUtils.contemTagFilho(Tag.children[i])) 
                this.configurar(Tag.children[i]);

            configuraTamanhoInput(Tag.children[i]);
            configuraDescricaoBtn(Tag.children[i]);
        };
    };

    this.MinimizarMaximaPanel = function (Tag) {

        for (var i = 0; i < Tag.children.length; i++)
            if ($(Tag.children[i]).hasClass('panel-body')) {
                if ($(Tag.children[i]).hasClass('minimizar'))
                    $(Tag.children[i]).removeClass('minimizar');
                else
                    $(Tag.children[i]).addClass('minimizar');
                return;
            }
        this.MinimizarMaximaPanel(Tag.parentNode);
    };
    
};

jQuery.fn.InputGlyphiconSetValidate = function (success) {
    var glyphiconGroup;

    var setGlyphiconGroup = function (aTag) {

        if ($(aTag).hasClass('group-glyphicon')) {
            glyphiconGroup = $(aTag);
            return;
        }
        else {
            if (aTag.tagName == 'FORM')
                return;
            else setGlyphiconGroup(aTag.parentNode);
        };
    }

    $.each(this, function () {
        setGlyphiconGroup(this);

        if (success == 't') {

            $(glyphiconGroup).children('.message-error').addClass('minimizar');
            $(glyphiconGroup).children('.inner-addon').removeAttr('i');
            $(glyphiconGroup).children('.inner-addon').append('<i class="glyphicon glyphicon-ok-sign"></i>');
            $(glyphiconGroup).children('.inner-addon').removeClass('has-error');
            $(glyphiconGroup).children('.inner-addon').addClass('has-success');

        } else {

            $(glyphiconGroup).children('.message-error').removeClass('minimizar');
            $(glyphiconGroup).children('.inner-addon').removeAttr('i');
            $(glyphiconGroup).children('.inner-addon').append('<i class="glyphicon glyphicon-remove-sign"></i>');
            $(glyphiconGroup).children('.inner-addon').removeClass('has-success');
            $(glyphiconGroup).children('.inner-addon').addClass('has-error');

        }
    });
}


$(window).load(function () {
    var s = new style();
    s.configurar(document.getElementById('portal-body'));

});


$(window).resize(function () {
    var s = new style();
    s.configurar(document.getElementById('portal-body'));
 });

$(document).ready(function () {

    $('.btn-minimizar').click(function (e) {
        var s = new style();
        s.MinimizarMaximaPanel(this);
        e.preventDefault();
    });
    
});








