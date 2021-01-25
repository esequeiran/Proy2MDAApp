using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace CoreAPI
{
    public class GeneradorCodigoQrManager : BaseManager
    {
        public GeneradorCodigoQrManager()
        {

        }
        public string generarCodigoQr(string valorCodigoQr)
        {
            
            try
            {
                BarcodeWriter bw = new BarcodeWriter();
                bw.Format = BarcodeFormat.QR_CODE;
                Bitmap bm = new Bitmap(bw.Write(valorCodigoQr), 300, 300);
                //pictureBoxGenerar.Image = bm;

                MemoryStream stream = new MemoryStream();
                bm.Save(stream, ImageFormat.Jpeg);
                byte[] byteArray = stream.GetBuffer();
                string image = "data:image/jpeg;base64," + Convert.ToBase64String(byteArray);
                return image;
            }
            catch (Exception ex) {
            
            }
            return "";
        }

        public byte[] generarCodigoQr2(string valorCodigoQr)
        {

            try
            {
                BarcodeWriter bw = new BarcodeWriter();
                bw.Format = BarcodeFormat.QR_CODE;
                Bitmap bm = new Bitmap(bw.Write(valorCodigoQr), 300, 300);
                //pictureBoxGenerar.Image = bm;

                MemoryStream stream = new MemoryStream();
                bm.Save(stream, ImageFormat.Jpeg);
                byte[] byteArray = stream.GetBuffer();
                string image = "data:image/jpeg;base64," + Convert.ToBase64String(byteArray);
                return byteArray;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }
}
