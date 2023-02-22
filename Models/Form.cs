using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group.Models
{
    public class Form
    {
        [Key]
        [Required]
        public int taskId { get; set; }
        [Required(ErrorMessage = "Don't Forget to add a task!")]
        public string task { get; set; }
        public DateTime dueDate { get; set; }
        [Required(ErrorMessage = "Don't Forget to add the quadrant!")]
        public int quadrant { get; set; }
        public bool completed { get; set; }
        
        // build foreign key relationships
        public int categoryId { get; set; }
        public Category category { get; set; }
    }
}
