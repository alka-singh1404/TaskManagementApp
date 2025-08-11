using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    [Index(nameof(Title))]
    [Index(nameof(status))]
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string Title { get; set; }
        public string Description { get; set; }
        [Display(Name ="Due Date")]
        public DateTime DueDate { get; set; }
        public  string status  { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedByName { get; set; }
        public string   CreatedById { get; set; }
        public string UpdatedByName { get; set; }
        public string UpdatedById { get; set; }
    }
}
