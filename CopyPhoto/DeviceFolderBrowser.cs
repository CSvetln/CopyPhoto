using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyPhoto
{
    class DeviceFolderBrowser
    {
        public string BrowseForSpecialFolders()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Выберите папку на подключенном устройстве";
                dialog.ShowNewFolderButton = false;
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }
            }
            return null;
        }
        public string SelectFolderFromDevice()
            {
                try
                {
                    using (var dialog = new OpenFileDialog())
                    {
                        // ОСНОВНЫЕ НАСТРОЙКИ
                        dialog.ValidateNames = false;
                        dialog.CheckFileExists = false;
                        dialog.CheckPathExists = true;
                        dialog.FileName = "Выберите папку";
                        dialog.Title = "Выберите папку на подключенном устройстве";

                        // ПОКАЗЫВАЕМ ДИАЛОГ (правильно для Windows Forms)
                        DialogResult result = dialog.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            string selectedPath = Path.GetDirectoryName(dialog.FileName);

                            if (!string.IsNullOrEmpty(selectedPath))
                            {
                                Console.WriteLine($"Выбранный путь: {selectedPath}");
                                return selectedPath;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка выбора папки",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
    }
}
