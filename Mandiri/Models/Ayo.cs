using System.ComponentModel.DataAnnotations;

namespace Mandiri.Models
{
    public class Ayo
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
