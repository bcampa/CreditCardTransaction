using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CreditCardTransaction.Repository
{
    public interface IRepository<T>
    {
        void Adicionar(T objeto);
        void AdicionarVarios(IEnumerable<T> objetos);
        void Atualizar(T objeto);
        void Excluir(T objeto);
        bool ExisteComCriterio(Expression<Func<T, bool>> expressao);
        void ExcluirTudo();
        T Obter(Guid id);
        IList<T> ObterVariosPorCriterio(Expression<Func<T, bool>> expressao);
        T ObterUmPorCriterio(Expression<Func<T, bool>> expressao);
        IList<T> ObterTodos();
    }
}
