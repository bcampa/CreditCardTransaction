using System;
using System.Linq.Expressions;

namespace CreditCardTransaction.Domain.Specification
{
    public static class ProdutoSpecification
    {
        public static Expression<Func<Produto, bool>> ObterPorNome(string nome)
        {
            return p => p.Nome == nome;
        }

        public static Expression<Func<Produto, bool>> ObterPorValorMinimo(decimal valorMinimo)
        {
            return p => p.Valor >= valorMinimo;
        }

        public static Expression<Func<Produto, bool>> ObterPorValorMaximo(decimal valorMaximo)
        {
            return p => p.Valor <= valorMaximo;
        }
    }
}
