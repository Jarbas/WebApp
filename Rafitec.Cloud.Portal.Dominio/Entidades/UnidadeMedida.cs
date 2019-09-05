using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{

    [Table("UNIDADES_MEDIDA")]
    public class UnidadeMedida : BaseEntidade
    {
        [Key, Column("ID_UNIDADE_MEDIDA")]
        public int IdUnidadeMedida { get; set; }
        [Column("ABREVIACAO")]
        public string Abreviacao { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
    }
}
