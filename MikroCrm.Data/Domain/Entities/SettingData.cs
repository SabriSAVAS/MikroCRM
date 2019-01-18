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
  public  class SettingData: EntityBase
    {
        [Required]
        public string Server { get; set; }

        [Required]
        public string DataBase { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("UserApp")]
        public int UserId { get; set; }
        public virtual UserApp UserApp { get; set; }
    }
}
