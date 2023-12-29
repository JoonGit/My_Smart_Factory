using Microsoft.AspNetCore.Mvc;

namespace My_Smart_Factory.Controllers
{
    // 제품정보(Product Informaction)
    public class PiController : Controller
    {
        // PI 저장, 수정, 불러오기
        public IActionResult Index()
        {
            return View();
        }
    }
}
