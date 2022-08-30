using Microsoft.AspNetCore.Http;

namespace WebDataConverters
{
    public static class ImageWebDataConverter
    {
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
