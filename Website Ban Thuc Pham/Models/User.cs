using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Website_Ban_Thuc_Pham.Models
{
    public class User
    {
        [Key]
        public string? Username { get; set; }

        public string? Password { get; set; }

        public int UserID { get; set; }

        public string? Email { get; set; }

        public bool? IsActive { get; set; }
    }
}
