using DefinexCase.Service.DTO.Request;
using DefinexCase.Service.DTO.Response;
using DefinexCase.Service.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DefinexCase.Service.Client
{
    public class CreditApplicationClient : ICreditApplicationClient
    {
        private readonly IHttpClientFactory _httpClient;
        public CreditApplicationClient(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CreditApplicationPaymentResponse> Proceed(PaymentRequest request)
        {
            var httpClient = _httpClient.CreateClient();
            var httpRequest = new Uri("http://localhost:54819/api/creditapplication/apply-credit");


            var response = await httpClient.PostAsJsonAsync(httpRequest, request);
            var responseRequest = new CreditApplicationPaymentResponse
            {
                IsSuccess = false
            };
            
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                responseRequest.IsSuccess = true;
            }            

            return responseRequest;
        }
    }
}
