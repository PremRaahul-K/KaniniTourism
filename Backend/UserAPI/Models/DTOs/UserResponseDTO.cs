﻿namespace UserAPI.Models.DTOs
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
    }
}
