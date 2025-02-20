using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PAW.Models;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace PAW.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
