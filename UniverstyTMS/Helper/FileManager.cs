﻿namespace UniverstyTMS.Helper
{
    public class FileManager
    {
        public static string Save(IFormFile file, string rootPath, string folders)
        {
            string newFileName = Guid.NewGuid().ToString() + (file.FileName.Length > 64 ? file.FileName.Substring(file.FileName.Length - 64) : file.FileName);
            string path = Path.Combine(rootPath, folders, newFileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return newFileName;
        }

        public static void Delete(string rootPath, string folders, string fileName)
        {
            string path = Path.Combine(rootPath, folders, fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
