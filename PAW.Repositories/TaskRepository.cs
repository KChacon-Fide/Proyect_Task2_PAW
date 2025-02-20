using System.Collections.Generic;
using System.Threading.Tasks;
using PAW.Models;
using PAW.DATA.Data;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace PAW.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ProductDbContext _context;

        public TaskRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PAW.Models.Task>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<PAW.Models.Task> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task CreateTaskAsync(PAW.Models.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(PAW.Models.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}