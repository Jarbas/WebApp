using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("UNIDADES_VENDA")]
    public class UnidadeVenda : BaseEntidade
    {
        [Key, Column("ID_UNIDADE_VENDA")]
        public int idUnidadeVenda { get; set; }
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
        [Column("ID_IMPORTACAO")]
        public int idImportacao { get; set; }
        [Column("ID_EMPRESA")]
        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public virtual Entidade Entidade { get; set; }
        [Column("ID_UNIDADE_NEGOCIO")]
        public int idUnidadeNegocio { get; set; }
        [ForeignKey("idUnidadeNegocio")]
        public virtual UnidadeNegocio UnidadeNegocio { get; set; }

    }
}
