using DefinexCase.Service.DTO.Request;
using DefinexCase.Service.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefinexCase.Service.Interface
{
    public interface ICreditApplicationService
    {
        Task<CreditApplicationPaymentResponse> Proceed(PaymentRequest request);
    }
}
