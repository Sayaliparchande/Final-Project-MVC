using System;
using System.Collections.Generic;

#nullable disable

namespace demo
{
    public partial class SignupUser
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public decimal? Mobilenumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
