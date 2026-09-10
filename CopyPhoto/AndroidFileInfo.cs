using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPhoto
{
    public class FileParam
    {
        public string FileName { get; set; }
        public DateTime CreationDate { get; set; }

        // Для корректной работы HashSet
        public override bool Equals(object obj)
        {
            return obj is FileParam info && FileName == info.FileName;
        }

        public override int GetHashCode()
        {
            return FileName?.GetHashCode() ?? 0;
        }
    }
}
