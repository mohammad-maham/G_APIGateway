using System.ComponentModel.DataAnnotations;

namespace GoldAPIGateway.Models
{
    public class SMS
    {
        [Display(Name = "شماره همراه های مقصد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string[]? Mobiles { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? Message { get; set; }
    }

    public class OTPsms
    {
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? Mobile { get; set; }

        [Display(Name = "کد تائیدیه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? OTP { get; set; }
    }
}
