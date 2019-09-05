const srError = 0;
      srSuccess = 1;
      srWarnning = 2;


jQuery.fn.validarCampoObrigatorio = function () {
    var result = true;

    var isFormGroupClass = function (aTag) {

        if ($(aTag).hasClass('form-group'))
            return true;
        return false;

    };

    var isCampoObrigatorio = function (aTag) {
        for (var i = 0; i < aTag.children.length; i++) {

            if (aTag.children[i].children.length > 0)
                if (isCampoObrigatorio(aTag.children[i]))
                    return true;

            if (aTag.children[i].tagName === 'SPAN')
                if ($(aTag.children[i]).hasClass('obrigatorio'))
                    return true;
        };
        return false;
    };

    var setarCampoObrigatorio = function (aTag) {
        $(aTag).addClass('has-error');
        result = false;


        var validarValorCampoObrigatorio = function (aTag) {

            for (var i = 0; i < aTag.children.length; i++) {
                if (aTag.children[i].children.length > 0)
                    if (!validarValorCampoObrigatorio(aTag.children[i]))
                        return false;

                if (aTag.children[i].tagName == 'INPUT') {
                    if (aTag.children[i].value == '' || aTag.children[i].value == 'None' || aTag.children[i].value == '0')
                        return false;
                } else if (aTag.children[i].tagName == 'SELECT') {
                    if (aTag.children[i].value == '' || aTag.children[i].value == 'None' || aTag.children[i].value < 0)
                        return false;
                }
            };
            return true;
        };

        this.each(function () {

            for (var i = 0; i < this.children.length; i++) {

                if (isFormGroupClass(this.children[i]))
                    if (isCampoObrigatorio(this.children[i]))
                        if (!validarValorCampoObrigatorio(this.children[i]))
                            setarCampoObrigatorio(this.children[i]);
            };

        });
        return result;

    };
}



var submit = function () {


   

    this.requestGet = function (rota, param = null, callback) {
        $.ajax({
            type: "GET",
            url: rota,
            data: param,
            success: callback,
            error: errorCallBack
        });
    }

    this.requestPost = function (rota, param = null, callback) {

        var ajax = $.ajax({
            type: "POST",
            url: rota,
            data: param,
            //beforeSend: beforeSendCallBack,
            success: callback,
            error: errorCallBack
        });

    };

    this.removeModal = function (idModal) {
                
        $('.modal-backdrop').remove();
        $('#' + idModal).remove();

    };

    this.ExibirModal = function (idModal, modal) {
      
        $('body').append(modal);
        $('#'+idModal).modal();
    };


    var errorCallBack = function (r) {
        console.log(r.responseText);
    };

    var beforeSendCallBack = function () {

        $('body').append(
            '  <div class="modal fade" id="modalAguarde" data-backdrop="static">                ' +
            '     <div class="modal-dialog">                                                    ' +
            '         <div class="modal-content">                                               ' +
            '                                                                                   ' +
            '             <div class="modal-header">                                            ' +
            '                 <center>                                                          ' +
            '                     <img src="/img/tittleTransp.png" class="img-modal-tittle" />  ' +
            '                 </center>                                                         ' +
            '             </div>                                                                ' +
            '                                                                                   ' +
            '             <div class="modal-body">                                              ' +
            '                 <div class="row">                                                 ' +
            '                     <div class="col-md-12">                                       ' +
            '                         <center>                                                  ' +
            '                             <img src="/img/loadBlue.gif" class="img-modal-body">  ' +
            '                                 <h3><strong>Aguarde...</strong></h3>              ' +
            '                         </center>                                                 ' +
            '                     </div>                                                        ' +
            '                     </div>                                                        ' +
            '                 </div>                                                            ' +
            '                                                                                   ' +
            '             </div>                                                                ' +
            '         </div>                                                                    ')          
        
        $('#modalAguarde').modal();

    };

    var unBuildEvenrt = function () {
        $(".formModalResponse").unbind("submit").click(function () { });
        $(".getModal").unbind("click").click(function () { });
    }

    this.buildEvent = function () {
        
        unBuildEvenrt();


        $(".formModalResponse").on('submit', function (e) {

            e.preventDefault();
            var sb = new submit();
            sb.requestPost($(this).attr('action'), $(this).serialize(), function (r) {
                sb.ExibirModal('modal-crud-mensagem', r);               
            });
        });

        $('.getModal').on("click", function (e) {
            e.preventDefault();

            var sb = new submit();           
          
            sb.requestGet($(this).attr('href'), null, function (r) {
                sb.ExibirModal('crudModal', r);
                sb.buildEvent();
            });

        });

        $(".modal").on('hidden.bs.modal', function () {
            var sb = new submit();
            sb.removeModal($(this).attr('id'));
        });

    };

};

$(document).ready(function () {
    new submit().buildEvent();
});