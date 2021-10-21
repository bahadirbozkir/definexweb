using DefinexCase.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexCase.Service.DTO.Response
{
    public class CreditApplicationPaymentResponse : IPaymentBankResponse
    {
        public bool IsSuccess { get; set; }
    }
}
