using System;
using System.Collections.Generic;

#nullable disable

namespace demo
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal? Mobilenumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
