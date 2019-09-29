using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Entities
{
    [Table("[dbo].[Task_Table]")]
    public class Task
    {
        [Key]
        public int Task_ID { get; set; }
        public int? Parent_ID { get; set; }
        public int Project_ID { get; set; }
        public string Task_Name { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public int Priority { get; set; }
        public bool? Status { get; set; }
    }

}
