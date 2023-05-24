using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class JobTitle
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CBO { get; set; }
        public string ActivityDescription { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        [DataType(DataType.Date)]
        public DateTime? TerminationDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }


        public bool IsValid()
        {
            return TerminationDate == null || TerminationDate > StartDate;
        }
    }
}
