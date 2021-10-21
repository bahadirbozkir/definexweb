using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexCase.Service.DTO.Request
{
    public class BasketRequest
    {
        public long Id { get; set; }
        public BasketItemRequest BasketItem { get; set; }
    }
}
