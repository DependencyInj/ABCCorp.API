using System;
using ABCCorp.Application.Interfaces;

namespace ABCCorp.Application.Services
{
	public class TaskManagerService : ITaskManagerService
	{
        private readonly ITaskManagerRepository _taskRepository;

		public TaskManagerService(ITaskManagerRepository taskRepository)
		{
            _taskRepository = taskRepository;
		}

        public async Task<List<DTO.Task>> GetEmployeeTasks(int empId)
        {
            return await _taskRepository.GetEmployeeTasks(empId);
        }

        public async Task<int> MarkTaskAsCompleted(int empId, int taskId)
        {
            return await _taskRepository.MarkTaskAsCompleted(empId, taskId);
        }
    }
}

