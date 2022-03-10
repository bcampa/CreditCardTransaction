using System;
using System.Linq;
using System.Linq.Expressions;

namespace CreditCardTransaction.Domain.Specification
{
    public static class ClienteSpecification
    {
        public static Expression<Func<Cliente, bool>> ObterPorNome(string nome)
        {
            return c => c.Nome == nome;
        }

        public static Expression<Func<Cliente, bool>> ObterPorIdDoCartaoDeCredito(Guid id)
        {
            return c => c.CartoesDeCredito.Any(cdc => cdc.Id == id);
        }

        public static Expression<Func<Cliente, bool>> ObterPorIdDaTransacao(Guid id)
        {
            return c => c.Transacoes.Any(t => t.Id == id);
        }
    }
}
