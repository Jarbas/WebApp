using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("PEDIDOS_ITENS")]
    public class PedidoItem : BaseEntidade
    {
        [Key, Column("ID_PEDIDO_ITEM")]
        public int idPedidoItem { get; set; }
        [Column("ID_PEDIDO")]
        public int idPedido { get; set; }
        [ForeignKey("idPedido")]
        public Pedido Pedido { get; set; }
        [Column("ID_PRODUTO")]
        public int idProduto { get; set; }
        [ForeignKey("idProduto")]
        public virtual Produto Produto { get; set; }
        [Column("ID_EMPRESA")]
        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public Entidade Empresa { get; set; }
        [Column("IPI")]
        public double Ipi{ get; set; }
        [Column("PERCENTUAL_COMISSAO")]
        public double PercentualComissao { get; set; }
        [Column("QUANTIDADE")]
        public int Quantidade { get; set; }
        [Column("VALOR_UNITARIO")]
        public double ValorUnitario { get; set; }
        [Column("TOTAL")]
        public double Total { get; set; }

        [NotMapped]
        public bool Importado { get; set; }
        [Column("IMPORTADO")]
        public string ImportadoStr
        {
            get { return Importado ? "true" : "false"; }
            set { Importado = (value == "true" ? true : false); }
        }

        public virtual ICollection<PedidoItemEntrega> PedidoItemEntrega { get; set; }

    }
}
