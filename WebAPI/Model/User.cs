﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebAPI.Model
{
    public class User
    {
        [Required]
        [NotNull]
        [Key]
        public string Username { get; set; }
        [Required]
        [NotNull]
        public string Password { get; set; }
        [Required]
        [NotNull]
        public string FirstName { get; set; }
        [Required]
        [NotNull]
        public string LastName { get; set; }
    }
    
}