using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("UNIDADES_NEGOCIO")]
    public class UnidadeNegocio : BaseEntidade
    {
        [Key, Column("ID_UNIDADE_NEGOCIO")]
        public int idUnidadeNegocio { get; set; }
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
        [Column("ID_IMPORTACAO")]
        public int idImportacao { get; set; }
        [Column("ID_EMPRESA")]
        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public virtual Entidade Empresa { get; set; }
    }
}
