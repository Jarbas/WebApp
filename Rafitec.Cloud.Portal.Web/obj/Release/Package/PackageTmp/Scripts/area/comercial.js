var pedido = function () {


    this.build = function () {

        $('.pedido-item-row').on('click', function () {
            debugger;

            $(getTagWithClass(this, 'selected')).removeClass('selected');
            $(this).addClass('selected');

            var sb = new submit();
            sb.requestGet('/Comercial/PedidoItemEntrega/Dashboard', { id: $(this).attr('id') }, function (r) {

                $('#pedido-item-entrega').replaceWith(r);


            });

        });

        
    };


}


$(document).ready(function () {
    new pedido().build();
});


