using Microsoft.AspNetCore.Http;

namespace ABCofRelEstate.ExportTool
{
    public class ExportJpgService
    {
        public async Task ImportManyFile(string dirPath, ICollection<IFormFile> files)
        {
            foreach (var file in files)
            {
                if (file.Length > 0 && (file.FileName.Contains(".jpg") || file.FileName.Contains(".png") || file.FileName.Contains(".bmp")))
                {
                    DirectoryInfo dirPathInfo = new DirectoryInfo(dirPath);
                    if (!dirPathInfo.Exists) dirPathInfo.Create();
                    string fullPath = Path.Combine(dirPathInfo.FullName, file.FileName);
                    using var stream = new FileStream(fullPath, FileMode.Create);
                    await file.CopyToAsync(stream);
                }
            }
        }
        public async Task ImportSingleFile(string dirPath, IFormFile file)
        {
            if (file.Length > 0 && (file.FileName.Contains(".jpg") || file.FileName.Contains(".png") || file.FileName.Contains(".bmp")))
            {
                DirectoryInfo dirPathInfo = new DirectoryInfo(dirPath);
                if (!dirPathInfo.Exists) dirPathInfo.Create();
                string fullPath = Path.Combine(dirPathInfo.FullName, file.FileName);
                using var stream = new FileStream(fullPath, FileMode.Create);
                await file.CopyToAsync(stream);
            }
        }
        public string? ExportFullPathJpg(string dirPath)
        {
            var dirInfo = new DirectoryInfo(dirPath);
            string? fullPath = null;
            if (dirInfo.Exists) fullPath = Directory.GetFiles(dirInfo.FullName).FirstOrDefault();
            return fullPath;
        }
        public string[] ExportFullPathsJpg(string dirPath)
        {
            List<string> fullPaths = new List<string>();
            var dirInfo = new DirectoryInfo(dirPath);
            if (dirInfo.Exists)
                fullPaths.AddRange(
                    Directory
                    .GetFiles(dirInfo.FullName)
                    .Where(f => f.Contains(".jpg") 
                    || f.Contains(".png")
                    || f.Contains(".bmp")));
            return fullPaths.ToArray();
        }
        public bool RemovePathWithFiles(string dirPath)
        {
            var dirInfo = new DirectoryInfo(dirPath);
            if(!dirInfo.Exists)
                return false;
            dirInfo.Delete();
            return true;
        }
    }
}
