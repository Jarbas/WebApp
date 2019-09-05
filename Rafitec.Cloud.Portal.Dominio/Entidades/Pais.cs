using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("PAISES")]
    public class Pais : BaseEntidade
    {
        [Key, Column("ID_PAIS")]
        public int idPais { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
    }
}
