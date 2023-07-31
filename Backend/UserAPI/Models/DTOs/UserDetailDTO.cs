using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAPI.Models.DTOs
{
    public class UserDetailDTO
    {
        public UserDetailDTO()
        {

        }

        public UserDetailDTO(UserDetail userDetail)
        {
            UserId = userDetail.UserId;
            FirstName = userDetail.FirstName;
            LastName = userDetail.LastName;
            DateOfBirth = userDetail.DateOfBirth;
            PhoneNumber = userDetail.PhoneNumber;
            Address = userDetail.Address;
            Gender = userDetail.Gender;
            DateOfBirth = userDetail.DateOfBirth;
            Nationality = userDetail.Nationality;

        }
        public UserDetailDTO(UserDetail userDetail, string email) : this(userDetail)
        {
            Email = email;
        }
        public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }

        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;
                int age = now.Year - DateOfBirth.Year;
                if (now < DateOfBirth.AddYears(age))
                    age--;
                return age;
            }
        }
        public DateTime DateOfBirth { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? Gender { get; set; }
        public string? Nationality { get; set; }
    }
}
