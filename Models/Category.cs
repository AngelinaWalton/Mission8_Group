using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int categoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
