using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PPIS_Tajma.Models
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
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

       
        //string Manager = "Event manager";
        //public string Admin { get; set; }
        //public string User { get; set; }
        //public string IncidentManager { get; set; }
        //public string EventManager{ get; set; }
        //public string ChangeManager { get; set; }
       

        //[Display(Name = "Role of new user")]
        //[Compare("Admin", ErrorMessage = "The role can be Admin, User, Event Manager, Incident Manager or Change Manager.")]
        //public string Role { get; set; }

        //public RegisterViewModel()
        //{
        //    this.Admin = "Admin";
        //    this.User = "User";
        //    this.IncidentManager = "Incident Manager";
        //    this.EventManager = "Event Manager";
        //    this.ChangeManager = "Change Manager";


        //}
            }


}
