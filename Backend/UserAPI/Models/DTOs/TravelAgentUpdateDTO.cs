namespace UserAPI.Models.DTOs
{
    public class TravelAgentUpdateDTO:UserUpdateDTO
    {
        public string? AgencyName { get; set; }
        public string? Status { get; set; }
    }
}
