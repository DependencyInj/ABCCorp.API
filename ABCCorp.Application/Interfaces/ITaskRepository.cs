using System;
namespace ABCCorp.Application.Interfaces
{
	public interface ITaskRepository
	{
		Task<List<DTO.Task>> GetTasks();
	}
}

