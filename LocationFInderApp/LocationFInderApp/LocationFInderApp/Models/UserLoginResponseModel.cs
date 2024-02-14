using System;
using System.Collections.Generic;
using System.Text;

namespace LocationFInderApp.Models
{
    public partial class UserLoginResponseModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        //public bool CanDoctorCreatePrescription { get; set; }
        public string DefaultRoleId { get; set; }
        public string JwtToken { get; set; }
    }

    public partial class LoginModel
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }

    public partial class ChatUserModel
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string avatar { get; set; }
        public string status { get; set; }
        public int? type { get; set; }
        public DateTime? dateSent { get; set; }
    }

    public partial class UserBaseModel : LoginModel
    {
        public string Id { get; set; }
        //public string MobileNo { get; set; }
        public string FullName { get; set; }
        // public string FatherName { get; set; }
        //  public string MotherName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        //public int? AreaId { get; set; }
        public int? CountryId { get; set; }
        //public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public string Phone { get; set; }
        //public bool? IsDependent { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? DefaultRoleId { get; set; }
        public string Photo { get; set; }
        public DateTime? PwdTimeStamp { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        //public string AreaName { get; set; }
        public string ZipCode { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string DefaultRoleName { get; set; }
        public double? RatePerHour { get; set; }
        public string PromotionalCode { get; set; }


        //public bool? IsTeamLeader { get; set; }
        //public string BmdcId { get; set; }
        //public string ProfessionalSummary { get; set; }
        //public string SpecializationInfo { get; set; }
        // public string SoftPhoneId { get; set; }
    }


    public partial class ChangePasswordModel : LoginModel
    {
        public string NewPassword { get; set; }

    }

    public partial class ForgetPasswordModel
    {
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }
}
