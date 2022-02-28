using System;
using System.Collections.Generic;

#nullable disable

namespace demo
{
    public partial class Productlist
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Discription { get; set; }
        public decimal? Price { get; set; }
        public decimal? Quantity { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
