using Rafitec.Cloud.Utils.ClassExtensions;
using Rafitec.Cloud.Utils.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("PRODUTOS")]
    public class Produto : BaseEntidade
    {
        [Key, Column("ID_PRODUTO")]
        public int idProduto { get; set; }
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
        [NotMapped]
        public Status Status { get; set; }
        [Column("STATUS")]
        public string StatusStr
        {
            get { return Status.ToString(); }
            set { Status = value.ParseToEnum<Status>(); }
        }
        [NotMapped]
        public bool Importado { get; set; }

        [Column("IMPORTADO")]
        public string ImportadoStr
        {
            get { return Importado ? "true" : "false"; }
            set { Importado = (value == "true" ? true : false); }
        }


        [Column("ID_IMPORTACAO")]
        public int idImportacao { get; set; }

        [Column("ID_TIPO_PRODUTO")]
        public int idTipoProduto { get; set; }
        [ForeignKey("idTipoProduto")]
        public virtual ProdutoTipo ProdutoTipo { get; set; }
        [Column("ID_UNIDADE_NEGOCIO")]
        public int idUnidadeNegocio { get; set; }
        [ForeignKey("idUnidadeNegocio")]
        public virtual UnidadeNegocio UnidadeNegocio { get; set; }

        [Column("ID_UNIDADE_VENDA")]
        public int idUnidadeVenda { get; set; }
        [ForeignKey("idUnidadeVenda")]
        public virtual UnidadeVenda UnidadeVenda { get; set; }

        [Column("ID_EMPRESA")]
        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public virtual Entidade Entidade { get; set; }


    }
}
