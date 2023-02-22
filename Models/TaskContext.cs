using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            // leave balnk for now
        }

        public DbSet<Form> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { categoryId = 1, CategoryName = "Home" },
                new Category { categoryId = 2, CategoryName = "School" },
                new Category { categoryId = 3, CategoryName = "Work" },
                new Category { categoryId = 4, CategoryName = "Church" }

            );
            //mb.Entity<Form>().HasData(
            //    new Form
            //    {
            //        task = "Dust",
            //        dueDate = "Tuesday",
            //        quadrant = 4,
            //        completed = true,
            //        categoryId = 1
            //    },
            //    new Form
            //    {
            //        task = "Call friend",
            //        dueDate = "Thursday",
            //        quadrant = 3,
            //        completed = false,
            //        categoryId = 3
            //    });
        }
    }
}
