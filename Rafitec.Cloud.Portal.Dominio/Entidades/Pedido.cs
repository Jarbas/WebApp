using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rafitec.Cloud.Utils.Enums;
using Rafitec.Cloud.Utils.ClassExtensions;


namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("PEDIDOS")]
    public class Pedido : BaseEntidade
    {
        [Key, Column("ID_PEDIDO")]
        public int idPedido { get; set; }
        [Column("ID_CLIENTE")]
        public int idCliente { get; set; }
        [ForeignKey("idCliente")]
        public virtual Entidade Cliente { get; set; }
        [Column("ID_CLIENTE_CONTA_ORDEM")]
        public int? idClienteContaOrdem { get; set; }
        [ForeignKey("idClienteContaOrdem")]
        public virtual Entidade ClienteContaOrdem { get; set; }

        [Column("ID_REPRESENTANTE")]
        public int? idRepresentante { get; set; }
        [ForeignKey("idRepresentante")]
        public virtual Usuario Representante { get; set; }

        [Column("ID_EMPRESA")]
        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public Entidade Empresa { get; set; }

        [Column("DATA_EMISSAO")]
        public DateTime DataEmissao { get; set; }
        [Column("RESPONSAVEL")]
        public string Responsavel { get; set; }
        [Column("PRAZO_PAGAMENTO_1")]
        public int? PrazoPagamento1 { get; set; }
        [Column("PRAZO_PAGAMENTO_2")]
        public int? PrazoPagamento2 { get; set; }
        [Column("PRAZO_PAGAMENTO_3")]
        public int? PrazoPagamento3 { get; set; }
        [Column("PRAZO_PAGAMENTO_4")]
        public int? PrazoPagamento4 { get; set; }
        [Column("PRAZO_PAGAMENTO_5")]
        public int? PrazoPagamento5 { get; set; }
        [Column("PRAZO_PAGAMENTO_6")]
        public int? PrazoPagamento6 { get; set; }
        [NotMapped]
        public Frete Frete { get; set; }
        [Column("FRETE")]
        public string FreteStr
        {
            get { return Frete.ToString(); }
            set { Frete = value.ParseToEnum<Frete>(); }
        }
        [NotMapped]
        public bool Paletizado { get; set; }
        [Column("PALETIZADO")]
        public string PaletizadoStr
        {
            get { return Paletizado.ToString(); }
            set { Paletizado = (value == "true" ? true : false); }
        }
        
        [Column("OBS")]
        public string Observacao { get; set; }
        [NotMapped]
        public FormaPagamento FormaPagamento { get; set; }
        [Column("FORMA_PAGAMENTO")]
        public string FormaPagamentoStr
        {
            get { return FormaPagamento.ToString(); }
            set { FormaPagamento = value.ParseToEnum<FormaPagamento>(); }
        }


        [Column("COD_PEDIDO_CLIENTE")]
        public int? CodPedidoCliente { get; set; }
        [Column("COD_PEDIDO_EMPRESA_PRODUCAO")]
        public int? CodPedidoEmpresaProducao { get; set; }
        [Column("COD_PEDIDO_REPRESENTANTE")]
        public int? CodPedidoRepresentante { get; set; }
        [Column("OBS_PERCA")]
        public string ObservacaoPerca { get; set; }

        [NotMapped]
        public StatusPedido Status { get; set; }
        [NotMapped]
        public bool Importado { get; set; }
        [Column("IMPORTADO")]
        public string ImportadoStr
        {
            get { return Importado ? "true" : "false"; }
            set { Importado = (value == "true" ? true : false); }
        }

        [Column("STATUS")]
        public string StatusStr
        {
            get { return Status.ToString(); }
            set { Status = value.ParseToEnum<StatusPedido>(); }
        }

        public virtual ICollection<PedidoItem> PedidoItem { get; set; }
        
    }
}
