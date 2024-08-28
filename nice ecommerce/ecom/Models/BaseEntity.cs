using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
