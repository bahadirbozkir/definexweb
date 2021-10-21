using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexCase.Service.DTO.Response
{
    public class BasketItemResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public long BasketId { get; set; }
    }
}
