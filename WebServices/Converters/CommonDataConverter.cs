using Microsoft.AspNetCore.Http;

namespace WebServices.Converters
{
    public static class CommonDataConverter
    {
        public static byte[] PathToImageToArray64(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return new byte[0];
            }

            byte[] array;
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                array = new byte[stream.Length];

                stream.Read(array, 0, (int)stream.Length);
            }

            return array;
        }

        public static string ReadBytesFromFormFile(IFormFile formFile)
        {
            if (formFile == null)
            {
                return string.Empty;
            }

            using var readStream = formFile.OpenReadStream();
            using var binaryReader = new BinaryReader(readStream);
            var imageData = binaryReader.ReadBytes((int)formFile.Length);
            return Convert.ToBase64String(imageData);
        }
    }
}
