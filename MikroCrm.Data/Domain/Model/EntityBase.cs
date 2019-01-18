using System.ComponentModel.DataAnnotations;

namespace MikroCrm.Data.Domain.Model
{
    public  class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
