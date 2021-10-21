using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexCase.Service.DTO.Request
{
    public class BasketItemRequest
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
    }
}
