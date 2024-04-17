using Microsoft.AspNetCore.Http;

namespace ABCofRelEstate.ExportTool;

public interface IExportImageService
{
    Task ImportManyFiles(string dirPath, ICollection<IFormFile> files);
    Task ImportSingleFile(string dirPath, IFormFile file);
    string? ExportFullPathImage(string dirPath);
    string[] ExportFullPathsImage(string dirPath);
    void RemovePathWithFiles(string dirPath);
}