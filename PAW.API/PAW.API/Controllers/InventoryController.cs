using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAW.Models;
using PAW.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PAW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetAllInventoriesAsync()
        {
            var inventories = await _inventoryRepository.GetAllInventoriesAsync();
            return Ok(inventories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventoryByIdAsync(int id)
        {
            var inventory = await _inventoryRepository.GetInventoryByIdAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }

        [HttpPost]
        public async Task<ActionResult<Inventory>> CreateInventoryAsync(Inventory inventory)
        {
            await _inventoryRepository.CreateInventoryAsync(inventory);
            return CreatedAtAction(nameof(GetInventoryByIdAsync), new { id = inventory.InventoryId }, inventory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventoryAsync(int id, Inventory inventory)
        {
            if (id != inventory.InventoryId)
            {
                return BadRequest();
            }

            await _inventoryRepository.UpdateInventoryAsync(inventory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryAsync(int id)
        {
            await _inventoryRepository.DeleteInventoryAsync(id);
            return NoContent();
        }
    }
}
