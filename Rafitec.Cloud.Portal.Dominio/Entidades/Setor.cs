using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("SETORES")]
    public class Setor : BaseEntidade
    {
        [Key, Column("COD_SETOR")]
        public int IdSetor { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("CENTRO_CUSTO")]
        public int? IdCentroCusto { get; set; }
    }
}