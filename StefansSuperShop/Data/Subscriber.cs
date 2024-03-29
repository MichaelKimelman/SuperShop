﻿using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefansSuperShop.Data
{
    public class Subscriber
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
        public virtual ICollection<Newsletter> Newsletters { get; set; }
    }
}
