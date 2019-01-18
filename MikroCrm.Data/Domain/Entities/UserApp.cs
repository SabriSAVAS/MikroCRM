using MikroCrm.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.Data.Domain.Entities
{
    public class UserApp:EntityBase
    {
        public UserApp()
        {
            CreateDate = DateTime.Now;
            DateOfEntry = DateTime.Now;
        }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime DateOfEntry { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }   
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual RoleApp Role { get; set; }
      //  public virtual SettingData SettingData { get; set; }
    }
}
