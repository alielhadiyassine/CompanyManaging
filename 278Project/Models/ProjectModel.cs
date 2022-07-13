using System.ComponentModel.DataAnnotations;

namespace _278Project.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Desription { get; set; }
        [Required]
        public string Status { get; set; }
    }

}
