using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PAW.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PAW.DATA.Data;
using Task = System.Threading.Tasks.Task;

namespace PAW.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ProductDbContext _context;

        public InventoryRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
        {
            return await _context.Inventories.ToListAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _context.Inventories.FindAsync(id);
        }

        public async Task CreateInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInventoryAsync(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventories.Remove(inventory);
                await _context.SaveChangesAsync();
            }
        }
    }
}