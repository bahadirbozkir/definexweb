using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexCase.Service.DTO.Response
{
    public class BasketResponse
    {
        public long Id { get; set; }
        public List<BasketItemResponse> BasketItems { get; set; }
    }
}
