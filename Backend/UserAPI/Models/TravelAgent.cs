using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserAPI.Models
{
    public class TravelAgent
    {
        [Key]
        public int TravelAgentId { get; set; }
        [ForeignKey("TravelAgentId")]
        [JsonIgnore]
        public UserDetail? UserDetail { get; set; }
        public string? AgencyName { get; set; }
        public string? Status { get; set; }
    }
}
