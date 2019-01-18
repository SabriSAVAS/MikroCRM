using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikroCrm.UI.ViewModel.UserModel
{
    public class UserViewModel:ModelEntity
    {
        public UserViewModel()
        {
            CreateDate = DateTime.Now;
            DateOfEntry = DateTime.Now;
            IsActive = true;
            RoleList = new List<SelectListItem>();
            SettingData = new SettingDataModel.SettingDataViewModel();
        }
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime DateOfEntry { get; set; }
        public int RoleId { get; set; }
        public List<SelectListItem> RoleList { get; set; }
        //public int SettingDataId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

        public SettingDataModel.SettingDataViewModel SettingData { get; set; }
    }
}