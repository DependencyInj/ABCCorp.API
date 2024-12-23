using System;
using ABCCorp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ABCCorp.Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ABCCorpDbContext _dbContext;

        public TaskRepository(ABCCorpDbContext dbConext)
        {
            _dbContext = dbConext;
        }

        public async Task<List<Application.DTO.Task>> GetTasks()
        {
            var tasks = new List<Application.DTO.Task>();
            try
            {
                 tasks = await _dbContext.Task
                 .AsNoTracking()
                 .Select(task => new Application.DTO.Task
                 {
                     Name = task.Name,
                     Description = task.Description
                 }).ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return tasks; 
        }
    }
}

