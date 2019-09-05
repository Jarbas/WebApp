using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafitec.Cloud.Portal.Web.Models
{
    public class QuestaoAlternativa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool EstaCorreta { get; set; } = false;
    }
}