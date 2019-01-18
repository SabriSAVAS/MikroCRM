using MikroCrm.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.Data.Domain.Entities
{
  public  class RoleApp:EntityBase
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
      
    }
}
