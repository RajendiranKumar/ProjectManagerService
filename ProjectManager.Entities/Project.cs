using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Entities
{
    [Table("[dbo].[Project_Table]")]
    public class Project
    {
       
        [Key]
        public int Project_ID { get; set; }
        public string Project_Name { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public int Priority { get; set; }
        [NotMapped]
        public int NumberOfTasks { get; set; }
        [NotMapped]
        public int Completed { get; set; }



    }
}

