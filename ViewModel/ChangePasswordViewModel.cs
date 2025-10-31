using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class ChangePasswordViewModel
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu và mật khẩu xác nhận không khớp.")]
        public string ConfirmPassword { get; set; }
    }
}
