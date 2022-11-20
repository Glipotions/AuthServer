using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MiniApp2.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoices()
        {
            var userName = HttpContext.User.Identity.Name;

            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            //veri taban�nda  userId veya userName alanlar� �zerinden gerekli datalar� �ek

            // stockId stockQuantity  Category  UserId/UserName

            return Ok($"Invoice i�lemleri =>  UserName: {userName}- UserId:{userIdClaim.Value}");
        }
    }
}