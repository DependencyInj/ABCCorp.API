using System;
using System.ComponentModel.DataAnnotations;

namespace ABCCorp.Domain.Models
{
	public class Employee_Task
	{
        [Key]
        public int Employee_Task_Id { get; set; }
        public int Employee_Id { get; set; }
        public int Task_Id { get; set; }
        public bool completed { get; set; }

    }
}

