using DefinexCase.Service.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexCase.Service.DTO.Request
{
    public class PaymentRequest
    {
        public PaymentMethodType PaymentMethodType { get; set; }
        public BankType BankType { get; set; }
        public OrderRequest Order { get; set; }
    }
}
