using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("ORDEM_PRODUCAO_ACOMPANHAMENTO")]
    public class OrdemProducaoAcompanhamento : BaseEntidade
    {
        [Key, Column("ID_OP_ACOMPANHAMENTO")]
        public int IdOpAcompanhamento { get; set; }
        [Column("NUMERO")]
        public string Numero { get; set; }
        [Column("ID_UNIDADE_MEDIDA")]
        public int IdUnidadeMedida { get; set; }
        [ForeignKey("IdUnidadeMedida")]
        public virtual UnidadeMedida UnidadeMedida { get;set;}
        [Column("ID_IMPORTACAO")]
        public int IdImportacao { get; set; }
        [Column("QUANTIDADE_A_PRODUZIR")]
        public double QuantidadeProduzir { get; set; }
        [Column("QUANTIDADE_PRODUZIDA")]
        public double QuantidadeProduzida { get; set; }
        [Column("ID_EMPRESA")]
        public int IdEmpresa {get;set;}
        [ForeignKey("IdEmpresa")]
        public Entidade Empresa { get; set; }
    }
}
