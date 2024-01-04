using My_Smart_Factory.Controllers;
using My_Smart_Factory.Models;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace My_Smart_Factory.Data.Service
{
    public class QrCodeService
    {
        private readonly IWebHostEnvironment _env;

        public QrCodeService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string SaveQrCode(QRCodeModel qRCode, string filePath, string fileName)
        {
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(qRCode.QRCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode QrCode = new QRCode(QrCodeInfo);
            Bitmap QrBitmap = QrCode.GetGraphic(30);
            string path = Path.Combine(_env.WebRootPath, filePath, fileName);
            QrBitmap.Save(path, ImageFormat.Png);
            return "/"+filePath+"/"+fileName;
        }

    }
}
