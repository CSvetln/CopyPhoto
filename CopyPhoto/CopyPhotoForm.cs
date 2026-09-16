using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyPhoto
{
    public partial class frmCopyPhoto : Form
    {
        private readonly IFileService _fileService;
        private readonly ILoggerService _loggerService;


        public frmCopyPhoto()
        {      
            InitializeComponent();
            _loggerService = new LoggerService(txtLogs, this);         
            var adbService = new AdbService(@"C:\platform-tools\adb.exe");
            _fileService = new FileService( adbService, _loggerService);
            btnBrowseSource.Enabled = !chkAndroidCopy.Checked;
           // txtSource.ReadOnly = chkAndroidCopy.Checked;
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtSource.Text = dialog.SelectedPath;
                    CheckPaths();
                }
            }
        }

        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtDest.Text = dialog.SelectedPath;
                    CheckPaths();
                }
            }
        }

        void CheckPaths()
        {
            btnCopyLastPhoto.Enabled = !string.IsNullOrEmpty(txtDest.Text) &&
                               !string.IsNullOrEmpty(txtDest.Text);

            btnCopyAllPhoto.Enabled = !string.IsNullOrEmpty(txtDest.Text) &&
                               !string.IsNullOrEmpty(txtDest.Text);
        }

        private async void btnCopyLastPhoto_Click(object sender, EventArgs e)
        {    
            var progress = new Progress<int>(value => progressBar.Value = value);
            DateTime? lastDate;
            if (chkLastDate.Checked)
                lastDate = dtpLastDate.Value;
            else
                lastDate = null;

            await _fileService.SyncLastFilesAsync(txtSource.Text, txtDest.Text, progress, lastDate, txtExtension.Text, chkAndroidCopy.Checked);

            OpenDestinationFolder();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private async void btnCopyAllPhoto_Click(object sender, EventArgs e)
        {
            var progress = new Progress<int>(value => progressBar.Value = value);
            await _fileService.SyncAllFilesAsync(txtSource.Text, txtDest.Text, progress, txtExtension.Text, chkAndroidCopy.Checked);

            OpenDestinationFolder();
        }

        private void OpenDestinationFolder()
        {
            Process.Start("explorer.exe", "E:\\тест");
        }

        private void frmCopyPhoto_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            Properties.Settings.Default.Save();
        }

        private void chkLastDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpLastDate.Enabled = !dtpLastDate.Enabled;
        }

        private void chkAndroidCopy_CheckedChanged(object sender, EventArgs e)
        {
            btnBrowseSource.Enabled = !chkAndroidCopy.Checked;
            //txtSource.ReadOnly = chkAndroidCopy.Checked;


            txtSource.Text = "/sdcard/DCIM/Camera/";          
        }
    }
}
