using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("UNIDADES_FEDERACAO")]
    public class Estado : BaseEntidade
    {
        [Key, Column("ID_UNIDADE_FEDERACAO")]
        public int idEstado {get;set;}
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("SIGLA")]
        public string Sigla { get; set; }
        [Column("ID_PAIS")]
        public int? idPais { get; set; }
        [ForeignKey("idPais")]
        public Pais Pais { get; set; }
        [Column("COD_IBGE")]
        public int? CodIBGE { get; set; }
        [Column("ICMS_PESSOA_JURIDICA")]
        public double? IcmsPessoaJuridica { get; set; }
        [Column("ICMS_PESSOA_FISICA")]
        public double? IcmsPessoaFisica { get; set; }
        [Column("ICMS_PRODUTOR_RURAL")]
        public double? IcmsPessoaRural { get; set; }
        [Column("ICMS_ENTRADA")]
        public double? IcmsEntrada { get; set; }
        [Column("ICMS_PROD_IMPORT")]
        public double? IcmsProdutoImportado { get; set; }
        [Column("ICMS_INTER_UF_DEST")]
        public double? IcmsEntreEstado { get; set; }
        [Column("ALIQUOTA_COMBATE_POBREZA")]
        public double? AliquotaCombatePobreza { get; set; }

    }


}
