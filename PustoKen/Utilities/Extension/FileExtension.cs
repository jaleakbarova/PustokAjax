using System;
namespace PustoKen.Utilities.Extension
{
    public static class FileExtension
    {      
        public static bool CheckFileType(this IFormFile file, string fileType)
            {
                return file.ContentType.Contains("image/");
            }

            public static bool CheckFileSize(this IFormFile file, int size)
            {
                return file.Length / 1024 > size;
            }

        public static async Task<string> SaveFileAsync(this IFormFile file, string root, string folder)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string path = Path.Combine(root, folder, uniqueFileName);

            FileStream stream = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(stream);
            return uniqueFileName;
        }
    }
    }

