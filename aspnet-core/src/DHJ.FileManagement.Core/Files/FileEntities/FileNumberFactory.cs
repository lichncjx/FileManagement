using System;

namespace DHJ.FileManagement.Files.FileEntities
{
    public static class FileNumberFactory
    {
        public static string Create()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return $"{i - DateTime.Now.Ticks:x}";
        }
    }
}