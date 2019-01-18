using MikroCrm.Data.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.Data.Domain.Entities
{
   public class Cleander: EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string BackgroundColor { get; set; }
    }
}
