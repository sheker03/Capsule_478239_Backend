using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Model
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public string Task_ID { get; set; }
        public string Parent_ID { get; set; }
        public string Task_Name { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? Start_Date { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? End_Date { get; set; }
        public int? Priority { get; set; }

        public int? Status { get; set; }


    }
}
