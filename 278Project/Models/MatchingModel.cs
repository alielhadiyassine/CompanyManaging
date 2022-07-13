using System.ComponentModel.DataAnnotations;

namespace _278Project.Models
{
    public class MatchingModel
    {
        public int Id { get; set; }
        [Required]
        public int empId { get; set; }
        [Required]
        public int projId { get; set; }
    }
}
