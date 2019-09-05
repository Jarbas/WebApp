using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("PRODUTOS_TIPO")]
    public class ProdutoTipo : BaseEntidade
    {
        [Key, Column("ID_TIPO_PRODUTO")]
        public int idTipoProduto { get; set; }
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
        [Column("ID_IMPORTACAO")]
        public int idImportacao { get; set; }
        [Column("ID_EMPRESA")]
        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public virtual Entidade Empresa { get; set; }
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
