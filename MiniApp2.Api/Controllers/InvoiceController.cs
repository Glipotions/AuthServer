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

            //veri tabanýnda  userId veya userName alanlarý üzerinden gerekli datalarý çek

            // stockId stockQuantity  Category  UserId/UserName

            return Ok($"Invoice iþlemleri =>  UserName: {userName}- UserId:{userIdClaim.Value}");
        }
    }
}