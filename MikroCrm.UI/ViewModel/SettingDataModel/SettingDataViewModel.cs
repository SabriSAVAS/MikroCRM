using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.SettingDataModel
{
    public class SettingDataViewModel:ModelEntity
    {
        [Required]
        public string Server { get; set; }

        [Required]
        public string DataBase { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}