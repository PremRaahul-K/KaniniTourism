namespace UserAPI.Models.DTOs
{
    public class TravellerDTO:UserDetailDTO
    {
        public TravellerDTO() 
        {
        }
        public TravellerDTO(UserDetail userDetail):base(userDetail)
        {
            Traveller = userDetail.Traveller;
        }
        public TravellerDTO(UserDetail userDetail,string email) : base(userDetail,email)
        {
            Traveller = userDetail.Traveller;
        }
        public Traveller? Traveller { get; set; }
    }
}
