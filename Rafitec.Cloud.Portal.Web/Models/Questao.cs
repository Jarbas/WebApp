using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafitec.Cloud.Portal.Web.Models
{
    public class Questao
    {
        public int Id { get; set; }
        public string Descricao {get;set;}
        public ICollection<QuestaoAlternativa> Alternativas { get; set; } //= new List<QuestaoAlternativa>();
    }
}