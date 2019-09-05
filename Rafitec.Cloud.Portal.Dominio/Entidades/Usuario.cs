using Rafitec.Cloud.Utils.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rafitec.Cloud.Utils.ClassExtensions;
using System.Collections.Generic;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("USUARIOS")]
    public class Usuario : BaseEntidade
    {
        [Key, Column("COD_USUARIO")]
        public int idUsuario { get; set; }

     //   [Column("COD_MATRICULA_SENIOR")]
     //   public int idMatriculaSenior { get; set; }

        [Column("COD_EMPRESA")]
        public int idEmpresa { get; set; }

        [Column("COD_SETOR")]
        public int? IdSetor { get; set; }
        [Column("LOGIN")]
        public string Login { get; set; }
        [Column("SENHA")]
        public string Senha { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [NotMapped]
        public Status Status { get; set; }
        [NotMapped, Column("SITUACAO")]
        public string StatusStr
        { 
            get
            {
                if (Status == Status.Ativo)
                    return "A";
                else
                    return "I";
            }
            set
            {
                if (StatusStr == "A")
                    Status = Status.Ativo;
                else Status = Status.Inativo;
            }
        }
        [NotMapped]
        public bool Admin { get; set; }
        [Column("ADM_SISTEMA")]
        public string AdminStr
        {
            get
            {
                if (Admin)
                    return "S";
                else return "N";
            }
            set
            {
                Admin = (value == "S");
            }
        }

        [NotMapped, Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }


    }


}
