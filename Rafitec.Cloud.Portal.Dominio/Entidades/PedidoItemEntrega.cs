using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("PEDIDOS_ITENS_ENTREGA")]
    public class PedidoItemEntrega : BaseEntidade
    {
        [Key, Column("ID_ENTREGA")]
        public int idEntrega { get; set; }
        [Column("ID_PEDIDO_ITEM")]
        public int idPedidoItem { get; set; }
        [ForeignKey("idPedidoItem")]
        public PedidoItem PedidoItem { get; set; }
        [Column("ID_PEDIDO")]
        public int idPedido { get; set; }
        [ForeignKey("idPedido")]
        public Pedido Pedido { get; set; }
        [Column("ID_EMPRESA")]
        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public Entidade Empresa { get; set; }
        [Column("SEQUENCIA")]
        public int Sequencia { get; set; }
        [Column("QUANTIDADE")]
        public int Quantidade { get; set; }
        [DataType(DataType.DateTime), Column("DATA_ENTREGA")]
        public DateTime DataEnterga { get; set; }
        [NotMapped]
        public bool Importado { get; set; }
        [Column("IMPORTADO")]
        public string ImportadoStr
        {
            get { return Importado ? "true" : "false"; }
            set { Importado = (value == "true" ? true : false); }
        }

    }
}
