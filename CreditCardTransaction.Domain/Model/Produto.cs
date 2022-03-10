using System;

namespace CreditCardTransaction.Domain
{
    public class Produto : BaseModel
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
