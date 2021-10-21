using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexCase.Service.DTO.Request
{
    public class CreditApplicationRequest
    {
        public int PaymentMethodType { get; set; }
        public int BankType { get; set; }
        public int BasketId { get; set; }
    }
}
