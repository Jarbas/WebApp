using Rafitec.Cloud.Portal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Rafitec.Cloud.Portal.Dominio.Repositorio
{
    public class Repositorio<T> where T : BaseEntidade
    {
        private EfDbContext _db = new EfDbContext();

        public IEnumerable<T> Get
        {
           get { return _db.Set<T>().ToList(); } 
        }


        public IEnumerable<T> GetMetodo(Expression<Func<T, bool>> condicao)
        {
            return _db.Set<T>().Where(condicao).ToList();
        }

        public bool Editar(T entidade)
        {
            try
            {
                _db.Entry<T>(entidade).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
           }
        }

        public bool Adicionar(T entidade)
        {
          try
           {
                _db.Set<T>().Add(entidade);
                _db.SaveChanges();
                return true;
           }
           catch (Exception e)
           {
               throw e;
           }
        }

        public bool Excluir(T entidade)
        {
            try
            {
                _db.Set<T>().Remove(entidade);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetSequencia(string aFieldPk)
        {
            var max = Get.Max(a => a.GetType().GetProperty(aFieldPk).GetValue(a) );
            return (int)max + 1;
        }

  
    }
}
