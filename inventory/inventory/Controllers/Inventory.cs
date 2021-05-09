using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using inventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inventory.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Inventory : Controller
    {
        [HttpGet]
        public ActionResult<IQueryable<Models.Inventory.Device>> GetDevices()
        {
            InventoryContext dbContext = HttpContext.RequestServices.GetService(typeof(InventoryContext)) as InventoryContext;
            return new ActionResult<IQueryable<Models.Inventory.Device>>(dbContext.GetDeviceList().AsQueryable());
        }
        [HttpPost]
        public async Task<IActionResult> SetDevice(Models.Inventory.Device device)
        {
            InventoryContext dbContext = HttpContext.RequestServices.GetService(typeof(InventoryContext)) as InventoryContext;
            Models.Response.InventoryDeviceResponse response = new Response.InventoryDeviceResponse();
            try
            {
                // try saveing
                dbContext.SetDevice(device);
                // fill response 
                response.Exception = "";
                response.ExceptionText = "";
                response.Device = device;
                response.Success = true;
                return Json(response);
            }
            catch (Exception ex)
            {
                response.Exception = ex.Message ;
                response.ExceptionText = ex.StackTrace;
                response.Device = device;
                response.Success = false;
                return Json(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDevice(Models.Inventory.Device device)
        {
            InventoryContext dbContext = HttpContext.RequestServices.GetService(typeof(InventoryContext)) as InventoryContext;
            Models.Response.InventoryDeviceResponse response = new Response.InventoryDeviceResponse();
            try
            {
                // try saveing
                dbContext.DeleteDevice(device);
                // fill response 
                response.Exception = "";
                response.ExceptionText = "";
                response.Device = device;
                response.Success = true;
                return Json(response);
            }
            catch (Exception ex)
            {
                response.Exception = ex.Message ;
                response.ExceptionText = ex.StackTrace;
                response.Device = device;
                response.Success = false;
                return Json(response);
            }
        }
    }
}