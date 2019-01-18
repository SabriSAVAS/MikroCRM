using MikroCrm.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.Data.Domain.Entities
{
   public class GeneralSetting:EntityBase
    {
        public string DocSeri { get; set; }
        [ForeignKey("UserApp")]
        public int UserId { get; set; }
        public virtual UserApp UserApp { get; set; }

    }
}
