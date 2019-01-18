using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.LoginModel
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string Ip { get; set; }
    }
}