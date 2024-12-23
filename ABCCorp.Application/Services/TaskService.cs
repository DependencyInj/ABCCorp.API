using System;
using ABCCorp.Application.Interfaces;

namespace ABCCorp.Application.Services
{
	public class TaskService: ITaskService
	{
        private readonly ITaskRepository _taskRepository;

		public TaskService(ITaskRepository taskRepository)
		{
            _taskRepository = taskRepository;
		}

        public async Task<List<DTO.Task>> GetTasks()
        {
            return await _taskRepository.GetTasks();
        }
    }
}

