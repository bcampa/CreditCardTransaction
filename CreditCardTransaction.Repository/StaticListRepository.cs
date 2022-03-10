using CreditCardTransaction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CreditCardTransaction.Repository
{
    public class StaticListRepository<T> : IRepository<T> where T : BaseModel
    {
        private static List<T> _contexto = new List<T>();

        public void Adicionar(T objeto)
        {
            _contexto.Add(objeto);
        }

        public void AdicionarVarios(IEnumerable<T> objetos)
        {
            _contexto.AddRange(objetos);
        }

        public void Atualizar(T objeto)
        {
            var objetoAntigo = _contexto.FirstOrDefault(x => x.Id == objeto.Id);
            _contexto.Remove(objetoAntigo);
            _contexto.Add(objeto);
        }

        public void Excluir(T objeto)
        {
            _contexto.Remove(objeto);
        }

        public bool ExisteComCriterio(Expression<Func<T, bool>> expressao)
        {
            return _contexto.Any(expressao.Compile());
        }

        public void ExcluirTudo()
        {
            _contexto.Clear();
        }

        public T Obter(Guid id)
        {
            return _contexto.FirstOrDefault(x => x.Id == id);
        }

        public IList<T> ObterTodos()
        {
            return _contexto;
        }

        public T ObterUmPorCriterio(Expression<Func<T, bool>> expressao)
        {
            return _contexto.FirstOrDefault(expressao.Compile());
        }

        public IList<T> ObterVariosPorCriterio(Expression<Func<T, bool>> expressao)
        {
            return _contexto.Where(expressao.Compile()).ToList();
        }
    }
}
