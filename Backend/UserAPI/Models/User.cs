using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public byte[]? PasswordHash { get; set; }
        [JsonIgnore]
        public byte[]? PasswordKey { get; set; }
        public string? Role { get; set; }
        public UserDetail? UserDetail { get; set; }
    }
}
