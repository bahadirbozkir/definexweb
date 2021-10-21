using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexCase.Service.DTO.Response
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public CategoryResponse Category { get; set; }
    }
}
