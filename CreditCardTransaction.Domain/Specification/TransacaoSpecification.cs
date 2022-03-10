using System;
using System.Linq;
using System.Linq.Expressions;

namespace CreditCardTransaction.Domain.Specification
{
    public static class TransacaoSpecification
    {
        public static Expression<Func<Transacao, bool>> ObterPorIdDoCartaoDeCredito(Guid id)
        {
            return t => t.CartaoDeCredito.Id == id;
        }

        public static Expression<Func<Transacao, bool>> ObterPorIdDoCliente(Guid id)
        {
            return t => t.Cliente.Id == id;
        }

        public static Expression<Func<Transacao, bool>> ObterPorIdDoProduto(Guid id)
        {
            return t => t.Itens.Any(ip => ip.Produto.Id == id);
        }
    }
}
