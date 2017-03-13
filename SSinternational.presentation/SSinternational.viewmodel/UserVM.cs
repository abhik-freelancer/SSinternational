using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SSinternational.viewmodel
{
   public class UserVM
    {
        public int userid { get; set; }
       [Required (ErrorMessage="Login name is required")]
       [Display (Name="Login")]
        public string login { get; set; }
       [Required (ErrorMessage="Password is required")]
       [Display (Name="Password")]
        public string password { get; set; }
       [Required (ErrorMessage="First name is required")]
       [Display (Name="First Name")]
        public string firstname { get; set; }
       [Display(Name = "Last Name")]
        public string lastname { get; set; }
        public bool isActive { get; set; }
        public DateTime logintime { get; set; }
    }
}
