using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Entities
{
    [Table("[dbo].[User_Table]")]
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        public int? Project_ID { get; set; }
        public int? Task_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Employee_ID { get; set; }
    }
}
