using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafitec.Cloud.Portal.Dominio.Entidades
{
    [Table("OS_STATUS")]
    public class OsStatus : BaseEntidade
    {
        [Key, Column("COD_STATUS")]
        public int IdStatus { get; set; }
        [Column("NOME")]
        public string Nome { get; set; }
    }
}
