using DefinexCase.Service.DTO.Request;
using DefinexCase.Service.DTO.Response;
using DefinexCase.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefinexCase.Service.Services
{
    public class CreditApplicationService : ICreditApplicationService
    {
        private readonly ICreditApplicationClient _creditApplicationClient;

        public CreditApplicationService(ICreditApplicationClient creditApplicationClient)
        {
            _creditApplicationClient = creditApplicationClient;
        }
        public async Task<CreditApplicationPaymentResponse> Proceed(PaymentRequest request)
        {
            var result = await _creditApplicationClient.Proceed(request);

            return result;
        }
    }
}
