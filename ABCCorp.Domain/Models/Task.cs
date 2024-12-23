using System;
using System.ComponentModel.DataAnnotations;

namespace ABCCorp.Domain.Models
{
	public class Task
	{
        [Key]
        public int Task_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

