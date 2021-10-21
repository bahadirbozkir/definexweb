using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexCase.Service.DTO.Request
{
    public class OrderRequest
    {
        public decimal Total { get; set; }
        public List<long> CategoryList { get; set; }
    }
}
