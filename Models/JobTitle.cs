using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class JobTitle
    {
        public JobTitle(int id, string name, string cBO, string activityDescription)
        {
            Id = id;
            Name = name;
            CBO = cBO;
            ActivityDescription = activityDescription;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CBO { get; set; }
        public string ActivityDescription { get; set; }
    }
}
