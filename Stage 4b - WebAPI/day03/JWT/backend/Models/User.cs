﻿using System;
namespace backend.Models
{
    public class User
    {
        public User()
        {
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
