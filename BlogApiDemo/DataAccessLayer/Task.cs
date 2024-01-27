using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApiDemo.DataAccessLayer
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Taskk {  get; set; }
        public DateTime TaskkCreateDate { get; set; }
    }
}
