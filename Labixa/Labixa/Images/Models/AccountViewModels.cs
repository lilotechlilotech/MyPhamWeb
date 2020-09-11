using Outsourcing.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labixa.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
    public class LoginUserViewModel
    {
        [Required(ErrorMessage ="Tên tài khoản là bắt buộc !")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc !")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Họ tên là bắt buộc !")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email là bắt buộc !")]
        [EmailAddress(ErrorMessage ="Địa chỉ email không đúng định dạng !")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Vui lòng lựa chọn khóa học!")]
        public int ProductId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Điện thoại không đúng định dạng ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Tên tài khoản là bắt buộc !")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc !")]
        [StringLength(100, ErrorMessage = "Mật khẩu chưa đủ bảo mật !", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Nhập lại mật khẩu không trùng khớp !")]
        public string ConfirmPassword { get; set; }
    }
    public class UserEditViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Họ tên là bắt buộc !")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email là bắt buộc !")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng !")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng lựa chọn khóa học!")]
        public int ProductId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Điện thoại không đúng định dạng ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Tên tài khoản là bắt buộc !")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

    }
}
