using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CopyPhoto
{
    public class FileService : IFileService
    {
        const string folder = "E:\\тест";
        private readonly IAdbService _adbService;
        private readonly ILoggerService _logger;

        public FileService(IAdbService adbService, ILoggerService logger)
        {
            _adbService = adbService;
            _logger = logger;
        }

        public HashSet<FileParam> GetSourceFiles(string sourcePath, string extension, DateTime? lastDate = null)
        {
            var sourceFiles = new HashSet<FileParam>();

            if (!Directory.Exists(sourcePath))
                return sourceFiles;


            var files = Directory.GetFiles(sourcePath)
                       .Select(f => new FileInfo(f))
                       // .Where(f =>  f.Extension == extension)
                         //  .Where(f => string.IsNullOrEmpty(extension) || f.Extension == extension);
                           .ToList();
          //  var sql = files.ToQueryString();
            if (lastDate != null)
                files = files.Where(f => f.CreationTime > lastDate).ToList();

            foreach (var file in files)
            {
                sourceFiles.Add(new FileParam
                {
                    FileName = file.Name,
                    CreationDate = file.CreationTime
                });
            }
            return sourceFiles;
        }

        /*public async Task SyncFilesAsync(bool all, string source, string destination, IProgress<int> progress, DateTime? lastDate, string extension, bool isAndroidFiles = false)
        {
            await Task.Run(() =>
            {
                if (lastDate == null)
                    lastDate = GetLastDateInDestination(destination);
                _logger.Log($"Последняя дата в папке назначения: {lastDate:yy.MM.dd}");

                HashSet<FileParam> sourceFileset = new HashSet<FileParam>();
                if (isAndroidFiles)
                    sourceFileset = _adbService.GetAndroidFilesList(extension, lastDate);
                else
                    this.GetSourceFiles(source, extension, lastDate);

                _logger.Log($"Файлов для копирования: {sourceFileset.Count}");

                if (sourceFileset.Count == 0)
                {
                    _logger.Log("Нет новых файлов для копирования");
                    return;
                }

                HashSet<FileParam> existingFiles = new HashSet<FileParam>();
                if(all)
                    existingFiles = this.GetExistingFiles(destination);
                DateTime currentDate = DateTime.MinValue;
                int i = 0;
                foreach (FileParam file in sourceFileset)
                {
                    if (currentDate != file.CreationDate)
                    {
                        currentDate = file.CreationDate;
                        var dateFolder = Path.Combine(folder, currentDate.ToString("yy.MM.dd"));
                        this.EnsureDirectoryExists(dateFolder);
                        _logger.Log($"Создана папка: {dateFolder}");
                    }

                    var destPath = Path.Combine(folder, currentDate.ToString("yy.MM.dd"), file.FileName);

                    if (isAndroidFiles)
                        _adbService.CopyAndroidFiles(file.FileName, destPath);
                    else
                        File.Copy(Path.Combine(source, file.FileName), destPath, false);
                    //File.SetCreationTime(destPath, file.CreationTime);
                    //File.SetLastWriteTime(destPath, file.CreationTime);
                    _logger.Log($"Скопировано: {destPath}");

                    progress?.Report((i + 1) * 100 / sourceFileset.Count);
                }
            });
        }*/

        public async Task SyncLastFilesAsync(string source, string destination, IProgress<int> progress, DateTime? lastDate, string extension, bool isAndroidFiles = false)
        {
            await Task.Run(() =>
            {
                int copiedCount = 0;
                if (lastDate == null)
                    lastDate = GetLastDateInDestination(destination); // если последняя не выбрана на форме, ищем последнюю дату в папке назначения 
                _logger.Log($"Последняя дата в папке назначения: {lastDate:yy.MM.dd}");

                HashSet<FileParam> sourceFileset = new HashSet<FileParam>(); //файлы с фотоаппарта или смартфона
                if (isAndroidFiles) // если стоит галочка копирование со смартфона
                    sourceFileset = _adbService.GetAndroidFilesList(source, extension, lastDate); // получить файлы со смартфона
                else
                    sourceFileset = this.GetSourceFiles(source, extension, lastDate); //получить файлы с фотоаппарата

                _logger.Log($"Файлов для копирования: {sourceFileset.Count}");

                if (sourceFileset.Count == 0)
                {
                    _logger.Log("Нет новых файлов для копирования");
                    return;
                }

                DateTime currentDate = DateTime.MinValue;
                
                foreach (FileParam file in sourceFileset)
                {
                    if (currentDate.Date != file.CreationDate.Date) //если дата фотографии меняется, создаем новую папку 
                    {
                        currentDate = file.CreationDate;
                        var dateFolder = Path.Combine(folder, currentDate.ToString("yy.MM.dd")); 
                        this.EnsureDirectoryExists(dateFolder);
                        _logger.Log($"Создана папка: {dateFolder}");
                    }

                    var destPath = Path.Combine(folder, currentDate.ToString("yy.MM.dd"), file.FileName);

                    if (isAndroidFiles)
                        _adbService.CopyAndroidFiles(source, file.FileName, destPath); // копирование файлов с смартфона
                    else
                        File.Copy(Path.Combine(source, file.FileName), destPath, false); //копирование файлов с фотоаппарата
                    //File.SetCreationTime(destPath, file.CreationTime);
                    //File.SetLastWriteTime(destPath, file.CreationTime);
                    _logger.Log($"Скопировано: {destPath}");

                    progress?.Report((copiedCount + 1) * 100 / sourceFileset.Count);
                }
            });
        }

        public async Task SyncAllFilesAsync(string source, string destination, IProgress<int> progress, string extension, bool isAndroidFiles = false)
        {
            await Task.Run(() =>
            {
                int copiedCount = 0;
                HashSet<FileParam> sourceFileset = new HashSet<FileParam>();

                if (isAndroidFiles)              
                    sourceFileset = _adbService.GetAndroidFilesList(source, extension);              
                else
                    sourceFileset = this.GetSourceFiles(source, extension);


                HashSet<FileParam> existingFiles = this.GetExistingFiles(destination);
                DateTime currentDate = DateTime.MinValue;
                foreach (FileParam file in sourceFileset)
                {
                    if (!existingFiles.Contains(file))
                    {
                        string destFolder = Path.Combine(folder, file.CreationDate.ToString("yy.MM.dd"));
                        if (currentDate != file.CreationDate)
                            this.EnsureDirectoryExists(destFolder);
                       // DateTime d = DateTime.Parse("12/09/2021");
                        if (destFolder == "E:\\тест\\24.10.18")
                            System.Diagnostics.Debugger.Break();
                        var destFile = Path.Combine(destFolder, file.FileName);
                        
                        if(isAndroidFiles)
                            _adbService.CopyAndroidFiles(source, file.FileName, destFolder);
                        else
                            File.Copy(Path.Combine(source, file.FileName), Path.Combine(destFolder, file.FileName), false);

                        _logger.Log($"Скопировано: {destFile}");

                        copiedCount++;                     
                    }
                }

                _logger.Log($"Скопировано файлов: {copiedCount}");
            });
        }

       

        private bool ContainsInvalidChars(string path)
        {
            char[] invalidChars = Path.GetInvalidPathChars();
            bool result = false;
            foreach (char c in invalidChars)
            {
                if (path.Contains(c.ToString()))
                {
                    _logger.Log($"Путь содержит невалидные знаки: {c.ToString()}");
                    result = true;
                }
            }
            return result;
        }

        public void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public HashSet<FileParam> GetExistingFiles(string destinationPath)
        {
            var existingFiles = new HashSet<FileParam>();

            if (!Directory.Exists(destinationPath))
                return existingFiles;

            var dirInfo = new DirectoryInfo(destinationPath);
            // Получаем все папки с датами
            var dateFolders = dirInfo.GetDirectories()
                        .Select(d => d.Name)                     // Берём только имена
                        .Where(name => Regex.IsMatch(name, @"^\d{2}\.\d{2}\.\d{2}(?:\s.+)?$"))  // Фильтрация
                        .ToArray();

            foreach (string dateFolder in dateFolders)
            {
                string dateName = Path.GetFileName(Path.Combine(destinationPath, dateFolder)).Substring(0, 8);
                var files = Directory.GetFiles(Path.Combine(destinationPath, dateFolder))
                    .Select(f => Path.GetFileName(f));

                foreach (var file in files)
                {
                    existingFiles.Add(new FileParam
                    {
                        FileName = Path.GetFileName(file),
                        CreationDate = DateTime.ParseExact(dateName, "yy.MM.dd",
                                       System.Globalization.CultureInfo.InvariantCulture) 
                    });
                   
                }
            }

            return existingFiles;
        }
     
        private DateTime GetLastDateInDestination(string destinationPath)
        {
            var dirInfo = new DirectoryInfo(destinationPath);
            string lastDir = dirInfo.GetDirectories()  // Получаем DirectoryInfo[]
                        .Select(d => d.Name)                     // Берём только имена
                        .Where(name => Regex.IsMatch(name, @"^\d{2}\.\d{2}\.\d{2}(?:\s.+)?$"))  // Фильтрация
                        .ToArray()
                        .Last();
            DateTime lastDate = DateTime.ParseExact(
                     lastDir.Substring(0, 8),
                     "yy.MM.dd",
                     CultureInfo.InvariantCulture
                 );
            return lastDate;

        }      
    }
}
