using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using adminApi.Models;

namespace adminApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase {
        private readonly DataContext _context;

        public DevicesController(DataContext context) {
            _context = context;
        }
        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceDTO>>> GetDevices() {
          if (_context.Devices == null) {
              return NotFound();
          }
          var devices = await _context.Devices
            .Select(x => ItemToDTO(x))
            .ToListAsync();
            return devices;
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceDTO>> GetDevice(int id) {
            var device = await _context.Devices.FindAsync(id);
            if (device == null) {
                return NotFound();
            }
            return ItemToDTO(device);
        }

        // PUT: api/Devices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDevice(int id, DeviceDTO devDTO) {
            
            if(id != devDTO.Id){
                Console.WriteLine(" id => '" + devDTO.Id + "' URL id: "+ id);
                return BadRequest("El id del dispositivo no coincide con el id del URL ");
            }
            var todoItem = await _context.Devices.FindAsync(id);
            if (todoItem == null ) {
               return NotFound();
            }
            Console.WriteLine("put 2 device => '" + todoItem.Imei + "' ");
            todoItem.Model = devDTO.Model == null ?  todoItem.Model : devDTO.Model;
            todoItem.Imei = devDTO.Imei == 0 ? todoItem.Imei : devDTO.Imei;
            todoItem.Active = devDTO.Active == true ? todoItem.Active : devDTO.Active;
        
            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!DeviceExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            return NoContent();
        }
        // POST: api/Devices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeviceDTO>> PostDevice(DeviceDTO device) {
            Console.WriteLine("POST Date => '" + DateTime.Now + "' " );

            var todoItem = new Device {
              Model = device.Model,
              Imei = device.Imei
            };
            Console.WriteLine("POST device => '" + device.Imei + "' " );
            _context.Devices.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
            nameof(GetDevice),
            new { id = todoItem.Id },
            ItemToDTO(todoItem));
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id) {
            if (_context.Devices == null) {
                return NotFound();
            }
            var device = await _context.Devices.FindAsync(id);
            if (device == null) {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeviceExists(int id) {
            return (_context.Devices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private static DeviceDTO ItemToDTO(Device item) =>
       new DeviceDTO {
           Id = item.Id,
           Imei = item.Imei,
            Model = item.Model,
            UpdateAt = item.UpdateAt,
            Active = item.Active
       };
    }
}
