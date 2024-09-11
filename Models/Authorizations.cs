namespace GoldAPIGateway.Models
{
    public class AuthorizationVM
    {
        public Information? Information { get; set; }
        public AuthResult? Result { get; set; }
    }

    public class Information
    {
        public string? Type { get; set; }
        public string? Applicant { get; set; }
        public string? Token { get; set; }
        public string? Credit { get; set; }
        public string? Access { get; set; }
    }

    public class AuthResult
    {
        public string? ID { get; set; }
        public bool IdCode { get; set; }
        public bool Name { get; set; }
        public bool Family { get; set; }
        public bool FatherName { get; set; }
        public bool NationalId { get; set; }
        public bool Mobile { get; set; }
    }

    public class MobileAuthVM
    {
        public string? NationalCode { get; set; }
        public string? Mobile { get; set; }
    }

    public class UserInfoAuthVM
    {
        public string? NationalCode { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? NationalId { get; set; }
        public string? Mobile { get; set; }
        public string? BirthDate { get; set; }
    }
}
