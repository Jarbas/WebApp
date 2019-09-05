using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{

    [Table("CIDADES")]
    public class Cidade : BaseEntidade
    {
        [Key, Column("ID_CIDADE")]
        public int idCidade { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("ID_UNIDADE_FEDERACAO")]
        public int idEstado { get; set; }
        [ForeignKey("idEstado")]
        public Estado Estado { get; set; }

    }
}
