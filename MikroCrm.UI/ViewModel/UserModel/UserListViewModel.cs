using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikroCrm.UI.ViewModel.UserModel
{
    public class UserListViewModel: ModelEntity
    {
       
        public string UserName { get; set; }     
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public int SettingDataId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

    }
}