using System;
namespace ABCCorp.Application.Interfaces
{
	public interface ITaskService
	{
		Task<List<DTO.Task>> GetTasks();
	}
}

