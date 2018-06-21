using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ListifyWebApp.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ExternalLoginConfirmationViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ExternalLoginListViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string ReturnUrl { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SendCodeViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string SelectedProvider { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VerifyCodeViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Provider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ForgotViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    /// <summary>
    /// It gives access the user to enter the email and password 
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// This is used to enter an email by the user
        /// </summary>

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// This is used to enter an password by the user
        /// </summary> 

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// This is used to remember their users account by saving their username or password
        /// </summary>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }


    }

    /// <summary>
    /// It gives access the user to enter the email and password for registration purpose by the user
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// This is used to enter the name by user for Registration purpose and it is mandatory field
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// This is used to enter the email by user for Registration purpose and it is mandatory field
        /// </summary>
        [Required(ErrorMessage="Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// This is used to enter the password by user for Registration purpose and it is mandatory field
        /// </summary>
        [Required(ErrorMessage ="Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// This is used to enter the ConfirmPassword by comparing it with password field by 
        /// user for Registration purpose and it is mandatory field
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ResetPasswordViewModel
    {
        /// <summary>
        /// This is used for users to reset their password, email field is required
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// This is used for users to reset their password, password field is required
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// This is used to enter the ConfirmPassword by comparing it with password field by 
        /// user to reset their password and it is mandatory field
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// code is used to send the code via url to their specific gmail account to reset their password
        /// </summary>
        public string Code { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ForgotPasswordViewModel
    {
        /// <summary>
        /// email is required to request for password for the recovery of account
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SendEmailViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}
