using System.ComponentModel.DataAnnotations;

namespace _278Project.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public int ProjectId { get; set; } =0;
        [Required]
        public string Expertise { get; set; } = "";
        [Required]
        public string Status { get; set; } = "";

        public int Salary { get; set; } = 2000;
        public int StartYear { get; set; } = DateTime.Now.Year;
    }
    
}
