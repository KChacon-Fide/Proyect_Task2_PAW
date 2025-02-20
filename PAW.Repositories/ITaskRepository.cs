using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAW.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace PAW.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<PAW.Models.Task>> GetAllTasksAsync();
        Task<PAW.Models.Task> GetTaskByIdAsync(int id);        
        Task CreateTaskAsync(PAW.Models.Task task);            
        Task UpdateTaskAsync(PAW.Models.Task task);            
        Task DeleteTaskAsync(int id);
    }
}