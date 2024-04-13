using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.Areas.Admin.ViewModels
{
    public class LoginAdminVM
    {

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không đúng!")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 ký tự")]
        public string UserAdmin { get; set; }


        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không đúng!")]
        [DataType(DataType.Password)]
        public string PassAdmin { get; set; }

    }
}
