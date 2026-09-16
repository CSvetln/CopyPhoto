using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CopyPhoto
{
    public class AdbService : IAdbService
    {
        private readonly string _adbPath;

        public AdbService(string adbPath = @"C:\platform-tools\adb.exe")
        {
            _adbPath = adbPath;
        }

        public HashSet<FileParam> GetAndroidFilesList(string source, string extesion, DateTime? lastDate = null)
        {
            var output = ExecuteAdbCommand("shell ls -l " + source);
            return ParseFileList(output, extesion, lastDate);
        }

        public void CopyAndroidFiles(string source, string file, string destPath)
        {
            //byte[] originalBytes = Encoding.ASCII.GetBytes(file);
            //byte[] asciiBytes = Encoding.Convert(Encoding.ASCII, Encoding.UTF8, originalBytes);
            string fileASCII = Encoding.UTF8.GetString(Encoding.GetEncoding("windows-1251").GetBytes(file));
            ExecuteAdbCommand("pull \"" + source + fileASCII + "\" \"" +  destPath + "\"");
        }

        public string ExecuteAdbCommand(string command)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = _adbPath,
                Arguments = command,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
           
            using (Process process = Process.Start(startInfo))
            {
                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                return process.ExitCode == 0 ? output : $"Error: {error}";
            }
        }

        public static HashSet<FileParam> ParseFileList(string input, string extension, DateTime? lastDate)
        {
            HashSet<FileParam> result = new HashSet<FileParam>();
            string[] lines = input.Split('\n');

            // Регулярное выражение для парсинга строки
            // Формат: -rw-rw---- 1 u0_a163 media_rw   SIZE YYYY-MM-DD HH:MM FILENAME
            Regex regex = new Regex(@"^\s*-\S+\s+\d+\s+\S+\s+\S+\s+(\d+)\s+(\d{4}-\d{2}-\d{2})\s+(\d{2}:\d{2})\s+(.+)$");

            foreach (string line in lines)
            {
                Match match = regex.Match(line);
                if (match.Success)
                {
                    string dateStr = match.Groups[2].Value;  // Дата
                    string timeStr = match.Groups[3].Value;  // Время
                    string fileName = match.Groups[4].Value.Replace("\r", string.Empty); // Имя файла

                    // Фильтрация по расширению (если указана)
                    if (!string.IsNullOrEmpty(extension))
                    {
                        if (!fileName.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
                            continue;
                    }

                    // Создаем DateTime из даты и времени
                    if ((DateTime.TryParse($"{dateStr} {timeStr}", out DateTime creationDate)) && (lastDate == null || creationDate > lastDate))
                    {
                        result.Add(new FileParam
                        {
                            FileName = fileName,
                            CreationDate = creationDate
                        });
                    }
                }
            }

            return result;
        }
    }
}
