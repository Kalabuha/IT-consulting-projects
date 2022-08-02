using System.Text;

namespace Services.Common
{
    public abstract class DefaultDataService
    {
        protected readonly string _directoryDefaultTextFiles = @"..\Services\Common\DefaultData\txt";
        protected readonly string _directoryDefaultImageFiles = @"..\Services\Common\DefaultData\img";

        protected async Task<string> GetDefaultTextFromFileAsync(string nameTxtFile)
        {
            string defaultString = string.Empty;

            string pathToTextFile = Path.Combine(_directoryDefaultTextFiles, nameTxtFile);
            if (File.Exists(pathToTextFile))
            {
                using (FileStream stream = new FileStream(pathToTextFile, FileMode.OpenOrCreate))
                {
                    byte[] buffer = new byte[stream.Length];
                    await stream.ReadAsync(buffer, 0, buffer.Length);
                    defaultString = Encoding.Default.GetString(buffer);
                }
            }

            if (string.IsNullOrEmpty(defaultString) || string.IsNullOrWhiteSpace(defaultString))
            {
                defaultString = "Текста нет";
            }

            return defaultString;
        }

        protected string GetDefaultImageFromFile(string nameImgFile)
        {
            var pathToImageFile = Path.Combine(_directoryDefaultImageFiles, nameImgFile);

            return pathToImageFile;
        }

    }
}
