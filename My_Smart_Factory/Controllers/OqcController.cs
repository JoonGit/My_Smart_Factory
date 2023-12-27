using Microsoft.AspNetCore.Mvc;

namespace My_Smart_Factory.Controllers
{
    [Route("oqc")]
    public class OqcController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
