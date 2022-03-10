using System;
using System.Collections.Generic;
using System.Linq;

namespace CreditCardTransaction.Domain
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public Cliente Cliente { get; set; }
        public IList<ItemProduto> Itens { get; set; }
        public CartaoDeCredito CartaoDeCredito { get; set; }

        public decimal ValorTotal => Itens.Sum(x => x.Produto.Valor * x.Quantidade);
    }
}