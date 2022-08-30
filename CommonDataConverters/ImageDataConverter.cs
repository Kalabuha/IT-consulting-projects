namespace CommonDataConverters
{
    public static class ImageDataConverter
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
    }
}
