using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public decimal Price { get; set; }

        public bool IsPriceConfirmed { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
