using System.IO;
using System.Windows.Media.Imaging;

namespace WpfAppForEmployees.WpfDataConverters
{
    public static class ImageWpfDataConverter
    {
        public static BitmapImage ConvertImageFromBytesToBitmap(byte[] byteImage)
        {
            using (var ms = new MemoryStream(byteImage))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
    }
}
