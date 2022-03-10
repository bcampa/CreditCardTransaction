using System;
using System.Collections.Generic;
using System.Linq;

namespace CreditCardTransaction.Domain
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IList<CartaoDeCredito> CartoesDeCredito { get; set; }
        public IList<Transacao> Transacoes { get; set; }

        public void RealizarCompra(List<ItemProduto> itens, CartaoDeCredito cartao)
        {
            if (!CartoesDeCredito.Any(x => x.Id == cartao.Id))
                throw new Exception("Este cartão não está associado a este cliente");

            var transacao = new Transacao
            {
                Id = Guid.NewGuid(),
                CartaoDeCredito = cartao,
                Cliente = this,
                Itens = itens
            };

            cartao.Autorizar(transacao);
        }
    }
}
