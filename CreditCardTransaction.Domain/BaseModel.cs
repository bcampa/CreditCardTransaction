using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardTransaction.Domain
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
    }
}
