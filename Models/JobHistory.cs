using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class JobHistory
    {
        public JobHistory()
        {
        }

        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public JobTitle JobTitle { get; set; }
        public string EmployeeRegisterNumber { get; set; }
        public Employee Employee { get; set; }
    }
}
