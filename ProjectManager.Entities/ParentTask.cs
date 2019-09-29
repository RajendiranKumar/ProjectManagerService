using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Entities
{
    [Table("[dbo].[ParentTask_Table]")]
    public class ParentTask
    {
        [Key]
        public int Parent_ID { get; set; }
        public string Parent_Task { get; set; }
    }
}
