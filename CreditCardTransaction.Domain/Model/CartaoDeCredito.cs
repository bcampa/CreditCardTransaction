using System;
using System.Collections.Generic;

namespace CreditCardTransaction.Domain
{
    public class CartaoDeCredito : BaseModel
    {
        public string Numero { get; set; }
        public decimal Limite { get; set; }
        public decimal LimiteConsumido { get; set; }
        public bool Ativo { get; set; }
        public Cliente Cliente { get; set; }
        public IList<Transacao> Transacoes { get; set; }

        public void Autorizar(Transacao transacao)
        {
            if (!Ativo)
                throw new Exception("Cartão não está ativo");

            if (transacao.ValorTotal > Limite)
                throw new Exception("Valor da compra maior que o limite");

            if (this.Id != transacao.CartaoDeCredito.Id)
                throw new Exception("Cartão é diferente do cartão utilizado na compra");

            LimiteConsumido += transacao.ValorTotal;
        }
    }
}
