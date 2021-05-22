﻿using System.ComponentModel.DataAnnotations;

namespace UserAPI
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [MaxLength(40)] public string Username { get; set; }

        [MaxLength(200)] public string Email { get; set; }

        [MaxLength(25)] public string Password { get; set; }
    }
}