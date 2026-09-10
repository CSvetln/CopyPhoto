using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPhoto
{
    public interface IFileService
    {
        HashSet<FileParam> GetExistingFiles(string destinationPath);       
        void EnsureDirectoryExists(string path);
        Task SyncLastFilesAsync(string source, string destination, IProgress<int> progresste, DateTime? lastDate, string extension, bool isAndroidFiles = false);
        Task SyncAllFilesAsync(string source, string destination, IProgress<int> progress, string extension, bool isAndroidFiles = false);
    }
}
