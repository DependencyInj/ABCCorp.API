using System;
using System.ComponentModel.DataAnnotations;

namespace ABCCorp.Domain.Models
{
	public class Employee
	{
        [Key]
        public int Employee_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

