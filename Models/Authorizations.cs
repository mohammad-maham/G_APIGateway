namespace GoldAPIGateway.Models
{
    public class MobileAuth
    {
        public Information? Information { get; set; }
        public UserMobileAuthVM? Result { get; set; }
    }

    public class RealUserAuth
    {
        public Information? Information { get; set; }
        public RealUserAuthResult? Result { get; set; }
    }

    public class LegalUserAuth
    {
        public Information? Information { get; set; }
        public LegalUserAuthResult? Result { get; set; }
    }

    public class Information
    {
        public string? Type { get; set; }
        public string? Applicant { get; set; }
        public string? Token { get; set; }
        public string? Credit { get; set; }
        public string? Access { get; set; }
    }

    public class RealUserAuthResult
    {
        public string? ID { get; set; }
        public string? IdCode { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? FatherName { get; set; }
        public string? NationalId { get; set; }
        public string? Mobile { get; set; }
    }

    public class LegalUserAuthResult
    {
        public string? NationalId { get; set; }
        public bool Validation { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string? RegisterNumber { get; set; }
        public string? Unit { get; set; }
        public string? Status { get; set; }
        public string? PostalCode { get; set; }
        public string? Address { get; set; }
    }

    public class UserMobileAuthVM
    {
        public bool? Validation { get; set; }
        public string? Detail { get; set; }
    }

    public class MobileAuthVM
    {
        public string? Mobile { get; set; }
        public string? NationalCode { get; set; }
    }

    public class RealUserInfoAuthVM
    {
        public string? NationalCode { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? NationalId { get; set; }
        public string? Mobile { get; set; }
        public string? BirthDate { get; set; }
    }

    public class LegalUserInfoAuthVM
    {
        public string? NationalCode { get; set; }
    }
}
