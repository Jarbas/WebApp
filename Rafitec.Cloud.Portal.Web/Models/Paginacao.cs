using System;
using System.Linq;
using System.Collections.Generic;
using Rafitec.Cloud.Portal.Dominio.Entidades;

namespace Rafitec.Cloud.Portal.Web.Models
{
   
    public class Paginacao
    {
        public int ItensTotal { get; set; }
        public static readonly int ItensPorPagina = 10;
        public int PaginaAtual { get; set; }

        public virtual int TotalPagina
        {
            get { return (int)Math.Ceiling((decimal)ItensTotal / ItensPorPagina); }
        }

        public static int IgnoraXItens(int pagina)
        {
            return ((pagina - 1) * ItensPorPagina);
        }

        //retirar virtual
        public virtual IEnumerable<T> Paginar<T>(IEnumerable<T> list) where T : class
        {
            return Paginar<T>(list, false);
        }
        

        public virtual IEnumerable<T> Paginar<T>(IEnumerable<T> list, bool Filtro) where T : class
        {
            ItensTotal = list.Count();
            if (Filtro)
            {
                PaginaAtual = 1;
            }
            return list.Skip(Paginacao.IgnoraXItens(PaginaAtual)).Take(Paginacao.ItensPorPagina);
        }

    }

}