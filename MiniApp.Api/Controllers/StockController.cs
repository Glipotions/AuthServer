using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MiniApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStock()
        {
            var username=HttpContext.User.Identity.Name;

            var userId=User.Claims.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier);

            //veri tabanında userId veya username alanları üzerinden gerekli dataları çek

            // stokid stockQuantity category userId/userName

            return Ok($"Stok Işlemleri Username: {username}- userId:{userId}");
        }
    }
}
