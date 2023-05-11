using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mandiri.Models
{
   
    [Table("Instructor", Schema = "public")]
    public class Instructor
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public string Email { get; set; }
        public string PositionName { get; set; }
        public string About { get; set; }
        public string Photo { get; set; }
        public string Experience { get; set; }
        public string Expertise { get; set; }
        public string InstructorPublication { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public int IsActive { get; set; }
    }

    
}
