using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Tên đăng nhập không đúng!")]
        [MaxLength(20, ErrorMessage="Tối đa 20 ký tự")]
        public string Username {  get; set; }


        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không đúng!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
