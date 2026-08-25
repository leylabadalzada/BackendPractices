using EduHome.Enums;

namespace EduHome.Extensions
{
    public static class FileExtension
    {
        public static string UploadFile(this IFormFile file, string root, string path)
        {
            var fileName = $"{Guid.NewGuid()}{file.FileName}"; //unikal filename duzeltdik
            var fullPath = Path.Combine(root, path, fileName); //full path-i teyin eledik
            using var stream = new FileStream(fullPath, FileMode.Create); //fayl yuklenmesini teyin eledik
            file.CopyTo(stream); //fayl yuklendi
            return fileName;
        }

        public static bool IsSizeValid(this IFormFile file, int size, FileSize fileSize)
        {
            switch (fileSize)
            {
                case FileSize.Byte:
                    if (file.Length > (int)size)
                        return false; break;
                case FileSize.KB:
                    if (file.Length > (int)size * 1024) //1kb = 1024 bytes
                        return false; break;
                case FileSize.MB:
                    if (file.Length > (int)size * 1024 * 1024)
                        return false; break;
                case FileSize.GB:
                    if (file.Length > (int)size * 1024 * 1024 * 1024)
                        return false; break;
                default: return false;
            }
            return true;

        }
        //1Gb = 1024 Mb = 1024 * 1024 Kb = 1024 * 1024 * 1024 bytes
        //1Mb = 10124 Kb = 1024 * 1024 bytes
        //1Kb = 1024 bytes

        public static bool IsFormatValid(this IFormFile file)
        {
            return (file.ContentType.Contains("image/")) ? true : false;
        }
    }
}
