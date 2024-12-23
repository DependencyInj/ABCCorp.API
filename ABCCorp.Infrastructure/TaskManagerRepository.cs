using System;
using ABCCorp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ABCCorp.Infrastructure
{
    public class TaskManagerRepository : ITaskManagerRepository
    {
        private readonly ABCCorpDbContext _dbContext;

        public TaskManagerRepository(
            ABCCorpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Application.DTO.Task>> GetEmployeeTasks(int empId)
        {
            var tasks = new List<Application.DTO.Task>();
            try
            {
                 tasks = await (from et in _dbContext.Employee_Task
                                     join t in _dbContext.Task on et.Task_Id equals t.Task_Id
                                     where et.Employee_Id == empId
                                     select new Application.DTO.Task
                                     {
                                         Task_Id = t.Task_Id,
                                         Name = t.Name,
                                         Description = t.Description
                                     }).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return tasks; 
        }

        public async Task<int> MarkTaskAsCompleted(int empId, int taskId)
        {
            var completed = 0;
            try
            {
                completed = await _dbContext.Employee_Task.Where(et => et.Task_Id == taskId && et.Employee_Id == empId)
                    .ExecuteUpdateAsync(e => e.SetProperty(t => t.completed, true));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return completed;
        }
    }
}

