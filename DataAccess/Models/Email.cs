using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Email : ModelBase
    {
        [Required]
        [MaxLength(200)]
        public string? EmailAddress { get; set; }
    }
}
