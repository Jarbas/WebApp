using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rafitec.Cloud.Utils.ClassExtensions;
using Rafitec.Cloud.Utils.Enums;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("OS_TI")]
    public class OsTi : BaseEntidade
    {
        [Column("COD_OS"), Key]
        public int IdOsTi { get; set; }
        [Column("COD_USUARIO")]
        public int? IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario {get;set;}
        [Column("COD_SETOR")]
        public int? IdSetor { get; set; }
        [ForeignKey("IdSetor")]
        public virtual Setor Setor { get; set; }
        [Column("COD_STATUS")]
        public int IdStatus { get; set; }
        [ForeignKey("IdStatus")]
        public virtual OsStatus Status { get; set; }
        [Column("TITULO")]
        public string Titulo { get; set; }
        [Column("DATA_ABERTURA")]
        public DateTime? DataAbertura { get; set; }
        [Column("DATA_INICIO")]
        public DateTime? DataInicio { get; set; }
        [Column("DATA_FIM")]
        public DateTime? DataFim { get; set; }
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
        [Column("OBSERVACAO")]
        public string Observacao { get; set; }
        [Column("RETORNO")]
        public string Retorno { get; set; }
        [NotMapped]
        public bool MaquinaParada { get; set; }
        [Column("DISPONIVEL")]
        public string MaquinaParadaStr
        {
            get
            {
                if (MaquinaParada)
                    return "S";
                else
                    return "N";
            }
            set
            {
                MaquinaParada = (value == "S");
            }
        }

        [NotMapped]
        public GrupoOsTi Grupo { get; set; }


        [Column("GRUPO")]
        public string GrupoStr
        {
            get
            {
                return Grupo.ToString();
            }
            set
            {
                Grupo = value.ParseToEnum<GrupoOsTi>();
            }
        }
        [Column("COD_TECNICO")]
        public int? IdUsuarioTecnico { get; set; }
        [ForeignKey("IdUsuarioTecnico")]
        public virtual Usuario UsuarioTecnico { get; set; }
        [Column("DATA_PREVISAO")]
        public DateTime? DataPrevisao { get; set; }
        [Column("DATA_CANCELAMENTO")]
        public DateTime? DataCancelamento { get; set; }
        [NotMapped]
        public bool Projeto { get; set; }
        [Column("PROJETO")]
        public string ProjetoStr
        {
            get
            {
                if (Projeto)
                    return "s";
                else return "N";

            }
            set
            {
                Projeto = (value == "S");
            }
        }
        [Column("LOCAL")]
        public string Local { get; set; }

        [NotMapped]
        public bool ChamadoWeb { get; set; }
        [Column("CHAMADO_WEB")]
        public string ChamadoWebStr
        {
            get
            {
                if (ChamadoWeb)
                    return "S";
                else return "N";
            }
            set
            {
                ChamadoWeb = (value == "S");
            }
        }


        [NotMapped]
        public AvaliacaoOsTi Avaliacao { get; set; }
        [Column("AVALIACAO")]
        public string AvaliacaoStr
        {
            get
            {
                if (Avaliacao == AvaliacaoOsTi.NAO_EXISTE)
                    return "";
                else return Avaliacao.ToString();
            }
            set
            {
                Avaliacao = value.ParseToEnum<AvaliacaoOsTi>();
            }
        }
    }
}
