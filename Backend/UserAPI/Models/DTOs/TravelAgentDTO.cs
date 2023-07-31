namespace UserAPI.Models.DTOs
{
    public class TravelAgentDTO:UserDetailDTO
    {
        public TravelAgentDTO()
        {

        }
        public TravelAgentDTO(UserDetail userDetail):base(userDetail)
        {
            TravelAgent = userDetail.TravelAgent;
        }
        public TravelAgentDTO(UserDetail userDetail,string email):base(userDetail,email)
        {
            TravelAgent = userDetail.TravelAgent;
        }
        public TravelAgent? TravelAgent { get; set; }
    }
}
