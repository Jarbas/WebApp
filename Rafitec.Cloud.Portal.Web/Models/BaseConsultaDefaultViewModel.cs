using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafitec.Cloud.Portal.Web.Models
{
    public class BaseConsultaDefaultViewModel<TEntidade> where TEntidade : Dominio.Entidades.BaseEntidade
    {
        public IEnumerable<TEntidade> Lista { get; set; }
        public Paginacao Paginacao { get; set; }
        public FiltroDefaultViewModel FiltroViewModel { get; set; }

        public BaseConsultaDefaultViewModel()
        {
            Paginacao = new Paginacao();
            FiltroViewModel = new FiltroDefaultViewModel();
            FiltroViewModel.Filtro = new Objeto.Filtro.FiltroDefault();
        }
        

        public void Paginar() 
        {
            this.Paginar(false);
        }

        public void Paginar(bool Filtro)
        {
            Paginacao.ItensTotal = Lista.Count();
            if (Filtro)
            {
                Paginacao.PaginaAtual = 1;
            }
            Lista = Lista.Skip(Paginacao.IgnoraXItens(Paginacao.PaginaAtual)).Take(Paginacao.ItensPorPagina);
        }
    }
}