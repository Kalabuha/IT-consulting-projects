using System.Text;

namespace DefaultDataServices
{
    public abstract class DefaultDataService
    {
        protected readonly string _directoryDefaultImageFiles = @"..\DefaultDataServices\DefaultData\img";

        protected async Task<string> GetDefaultTextFromFileAsync(string startFilePath, string nameTxtFile)
        {
            string defaultString = string.Empty;

            string pathToTextFile = Path.Combine(startFilePath, nameTxtFile);
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
    }
}
