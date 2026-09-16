using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPhoto
{
    public interface IAdbService
    {
        HashSet<FileParam> GetAndroidFilesList(string source, string extension, DateTime? lastDate = null);
        void CopyAndroidFiles(string source, string file, string destPath);
        string ExecuteAdbCommand(string command);
    }
}
