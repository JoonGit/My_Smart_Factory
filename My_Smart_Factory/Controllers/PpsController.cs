using Microsoft.AspNetCore.Mvc;

namespace My_Smart_Factory.Controllers
{
    //공정 진행 상황(Process progress status)
    public class PpsController : Controller
    {
        // Pps 저장(Pi와함께), 수정,
        // 불러오기(Pi정보를 include 해서 ppsVo에 담아서 Json으로)
        public IActionResult Index()
        {
            return View();
        }
    }
}
