using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rafitec.Cloud.Utils.Enums;
using Rafitec.Cloud.Utils.ClassExtensions;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("ENTIDADES")]
    public class Entidade : BaseEntidade
    {
        [Key, Column("ID_ENTIDADE")]
        public int idEntidade { get; set; }

        [NotMapped]
        public EntidadePessoa Pessoa { get; set; }

        [Column("PESSOA")]
        public string PessoaDb
        {
            get { return Pessoa.ToString(); }
            set { Pessoa = value.ParseToEnum<EntidadePessoa>(); }
        }

        [Column("CNPJ_CPF")]
        public string CnpjCpf { get; set; }
        [Column("INSCRICAO_ESTADUAL")]
        public string InscricaoEstadual { get; set; }
        [Column("INSCRICAO_MUNICIPAL")]
        public string InscricaoMunicipal { get; set; }
        [Column("INSCRICAO_PRODUTOR_RURAL")]
        public string InscricaoProdutorRural { get; set; }
        [Column("RAZAO_SOCIAL")]
        public string RazaoSocial { get; set; }
        [Column("FANTASIA")]
        public string Fantasia { get; set; }
        [Column("FUNDACAO")]
        public DateTime Fundacao { get; set; }
        [Column("CEP")]
        public string Cep { get; set; }
        [Column("ENDERECO_TIPO")]
        public string EnderecoTipo { get; set; }
        [Column("ENDERECO")]
        public string Endereco { get; set; }
        [Column("ENDERECO_NUMERO")]
        public string EnderecoNumero { get; set; }
        [Column("ENDERECO_COMPLEMENTO")]
        public string EnderecoComplemento { get; set; }
        [Column("BAIRRO")]
        public string Bairro { get; set; }
        [Column("CAIXA_POSTAL")]
        public string CaixaPostal { get; set; }
        [Column("TELEFONE")]
        public string Telefone { get; set; }
        [Column("TELEFONE_RAMAL")]
        public string TelefoneRamal { get; set; }
        [Column("FAX")]
        public string Fax { get; set; }
        [Column("FAX_RAMAL")]
        public string FaxRamal { get; set; }
        [Column("TELEFONE_CELULAR")]
        public string TelefoneCelular { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("HOME_PAGE")]
        public string HomePage { get; set; }
        [Column("EMAIL_NFE")]
        public string EmailNfe { get; set; }
        [Column("OBSERVACOES")]
        public string Observacoes { get; set; }
        [Column("DATA_CADASTRAMENTO")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataCadastramento { get; set; }
        [Column("INSCRICAO_SUFRAMA")]
        public string Suframa { get; set; }
        [NotMapped]
        public bool Importado { get; set; }
        [Column("IMPORTADO")]
        public string ImportadoStr
        {
            get { return Importado ? "true" : "false";  }
            set { Importado = (value == "true" ? true : false); }
        }


        [NotMapped]
        public SimNao Contribuinte { get; set; }
        [Column("CONTRIBUINTE")]
        public string ContribuinteDb
        {
            get { return Contribuinte.ToString(); }
            set { Contribuinte = value.ParseToEnum<SimNao>(); }
        }

        [Column("CONCEITO")]
        public string Conceito { get; set; }
        [Column("CONTATO")]
        public string Contato { get; set; }
        [Column("LIMITE_CREDITO")]
        public double? LimiteCredito { get; set; }

        [NotMapped]
        public EntidadeSituacao Situacao { get; set; }

        [Column("SITUACAO")]
        public string SituacaoDb
        {
            get { return Situacao.ToString(); }
            set { Situacao = value.ParseToEnum<EntidadeSituacao>(); }
        }
        [Column("SUSPENSAO_IPI")]
        public string SuspensaoIpi { get; set; }

        [NotMapped]
        public FormaPagamento Venda { get; set; }

        [Column("VENDA")]
        public string VendaDb
        {
            get { return Venda.ToString(); }
            set { Venda = value.ParseToEnum<FormaPagamento>(); }
        }
        [NotMapped]
        public TipoCliente TipoCliente { get; set; }
        [Column("TIPO_CLIENTE")]
        public string TipoClienteDb
        {
            get { return TipoCliente.ToString(); }
            set { TipoCliente = value.ParseToEnum<TipoCliente>(); }
        }
        [NotMapped]
        public EntidadeTipo TipoEntidade { get; set; }
        [Column("TIPO_ENTIDADE")]
        public string TipoEntidadeDb
        {
            get { return TipoEntidade.ToString(); }
            set { TipoEntidade = value.ParseToEnum<EntidadeTipo>(); }
        }

        [Column("ID_IMPORTACAO")]
        public int? idImportacao { get; set; }

        [Column("ID_REPRESENTANTE")]
        public int? idRepresentante { get; set; }
        [ForeignKey("idRepresentante")]
        public virtual Entidade Representante { get; set; }

        [Column("ID_PAIS")]
        public int idPais { get; set; }
        [ForeignKey("idPais")]
        public virtual Pais Pais { get; set; }

        [Column("ID_CIDADE")]
        public int idCidade { get; set; }
        [ForeignKey("idCidade")]
        public virtual Cidade Cidade { get; set; }

        [Column("ID_UNIDADE_FEDERACAO")]
        public int idEstado { get; set; }
        [ForeignKey("idEstado")]
        public virtual Estado UnidadeFederacao { get; set; }
    }
}
