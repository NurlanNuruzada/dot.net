using Pronia.Areas.Admin.ProductViewModel;

namespace Pronia.Areas.Admin.Extension;

public static class FileExtension
{
    public static bool CorrectForamt(this IFormFile file, string fileType)
    {
        return file.ContentType.Contains(fileType);
    }

    public static bool CheckSize(this IFormFile file, int kb)
    {
        return file.Length/1024<=kb;
    }

    public async static Task<string> CopyFileAsync(this IFormFile file,string root,params string[] folders)
    {
        string fileName = Guid.NewGuid().ToString() + file.FileName;
        string folderRoot = String.Empty;
        foreach (var folder in folders)
        {
            folderRoot = Path.Combine(folderRoot, folder);
        }
        string filePath = Path.Combine(folderRoot, fileName);
        string path = Path.Combine(root, filePath);
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return filePath;
    }
}
