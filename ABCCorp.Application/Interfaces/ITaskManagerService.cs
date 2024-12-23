﻿using System;
namespace ABCCorp.Application.Interfaces
{
	public interface ITaskManagerService
	{
		Task<List<DTO.Task>> GetEmployeeTasks(int empId);
		Task<int> MarkTaskAsCompleted(int empId, int taskId);

    }
}

