using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.RoleModel
{
    public class RoleViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}