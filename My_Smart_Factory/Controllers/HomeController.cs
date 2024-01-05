using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Service;
using My_Smart_Factory.Models;
using QRCoder;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace My_Smart_Factory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QrCodeService _qrCodeService;

        public HomeController(ILogger<HomeController> logger,
            QrCodeService qrCodeService)
        {
            _logger = logger;
            _qrCodeService = qrCodeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult CreateQRCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateQRCode(QRCodeModel qRCode)
        {

            string FileName = "test.png";
            string FilePath = "qrimg";

            //_qrCodeService.SaveQrCode(FilePath, FilePath, FileName);
            //string uri = 
            //ViewBag.QrCodeUri = QrUri;
            return View();
        }

        //public Bitmap GenerateQrCode(string data)
        //{
        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
        //    QRCode qrCode = new QRCode(qrCodeData);
        //    Bitmap qrCodeImage = qrCode.GetGraphic(20);

        //    return qrCodeImage;
        //}
        //public ActionResult GetQrCode(string data)
        //{
        //    Bitmap qrCodeImage = GenerateQrCode(data);

        //    MemoryStream ms = new MemoryStream();
        //    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //    byte[] byteImage = ms.ToArray();
        //    var base64String = Convert.ToBase64String(byteImage); // Get Base64

        //    return Content("data:image/png;base64," + base64String, "text/html");
        //}
    }
    //Extension method to convert Bitmap to Byte Array
    //public static class BitmapExtension
    //{
    //    public static byte[] BitmapToByteArray(this Bitmap bitmap)
    //    {
    //        using (MemoryStream ms = new MemoryStream())
    //        {
    //            bitmap.Save(ms, ImageFormat.Png);
    //            return ms.ToArray();
    //        }
    //    }
    //}
}