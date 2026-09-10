
namespace CopyPhoto
{
    partial class frmCopyPhoto
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCopyLastPhoto = new System.Windows.Forms.Button();
            this.btnCopyAllPhoto = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.btnBrowseDest = new System.Windows.Forms.Button();
            this.dtpLastDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.chkAndroidCopy = new System.Windows.Forms.CheckBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.grpDest = new System.Windows.Forms.GroupBox();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.grpExtension = new System.Windows.Forms.GroupBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.chkLastDate = new System.Windows.Forms.CheckBox();
            this.grpSource.SuspendLayout();
            this.grpDest.SuspendLayout();
            this.grpExtension.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCopyLastPhoto
            // 
            this.btnCopyLastPhoto.BackColor = System.Drawing.Color.Lime;
            this.btnCopyLastPhoto.ForeColor = System.Drawing.Color.Black;
            this.btnCopyLastPhoto.Location = new System.Drawing.Point(18, 369);
            this.btnCopyLastPhoto.Name = "btnCopyLastPhoto";
            this.btnCopyLastPhoto.Size = new System.Drawing.Size(179, 52);
            this.btnCopyLastPhoto.TabIndex = 4;
            this.btnCopyLastPhoto.Text = "Синхронизировать последние файлы";
            this.btnCopyLastPhoto.UseVisualStyleBackColor = false;
            this.btnCopyLastPhoto.Click += new System.EventHandler(this.btnCopyLastPhoto_Click);
            // 
            // btnCopyAllPhoto
            // 
            this.btnCopyAllPhoto.BackColor = System.Drawing.Color.Lime;
            this.btnCopyAllPhoto.Location = new System.Drawing.Point(18, 443);
            this.btnCopyAllPhoto.Name = "btnCopyAllPhoto";
            this.btnCopyAllPhoto.Size = new System.Drawing.Size(179, 52);
            this.btnCopyAllPhoto.TabIndex = 5;
            this.btnCopyAllPhoto.Text = "Синхронизировать все файлы";
            this.btnCopyAllPhoto.UseVisualStyleBackColor = false;
            this.btnCopyAllPhoto.Click += new System.EventHandler(this.btnCopyAllPhoto_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Location = new System.Drawing.Point(214, 443);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(179, 52);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Остановить";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(482, 472);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(384, 23);
            this.progressBar.TabIndex = 8;
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(472, 29);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogs.Size = new System.Drawing.Size(381, 370);
            this.txtLogs.TabIndex = 9;
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(333, 59);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSource.TabIndex = 10;
            this.btnBrowseSource.Text = "Обзор:";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // btnBrowseDest
            // 
            this.btnBrowseDest.Location = new System.Drawing.Point(339, 37);
            this.btnBrowseDest.Name = "btnBrowseDest";
            this.btnBrowseDest.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDest.TabIndex = 11;
            this.btnBrowseDest.Text = "Обзор:";
            this.btnBrowseDest.UseVisualStyleBackColor = true;
            this.btnBrowseDest.Click += new System.EventHandler(this.btnBrowseDest_Click);
            // 
            // dtpLastDate
            // 
            this.dtpLastDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CopyPhoto.Properties.Settings.Default, "dtpLastDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpLastDate.Enabled = false;
            this.dtpLastDate.Location = new System.Drawing.Point(214, 401);
            this.dtpLastDate.Name = "dtpLastDate";
            this.dtpLastDate.Size = new System.Drawing.Size(200, 20);
            this.dtpLastDate.TabIndex = 12;
            this.dtpLastDate.Value = global::CopyPhoto.Properties.Settings.Default.dtpLastDate;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Копирование:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.chkAndroidCopy);
            this.grpSource.Controls.Add(this.txtSource);
            this.grpSource.Controls.Add(this.btnBrowseSource);
            this.grpSource.Location = new System.Drawing.Point(12, 29);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(436, 114);
            this.grpSource.TabIndex = 16;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Каталог для синхронизации (фотоаппарат):";
            // 
            // chkAndroidCopy
            // 
            this.chkAndroidCopy.AutoSize = true;
            this.chkAndroidCopy.Checked = global::CopyPhoto.Properties.Settings.Default.chkAndroidCopy;
            this.chkAndroidCopy.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CopyPhoto.Properties.Settings.Default, "chkAndroidCopy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAndroidCopy.Location = new System.Drawing.Point(6, 29);
            this.chkAndroidCopy.Name = "chkAndroidCopy";
            this.chkAndroidCopy.Size = new System.Drawing.Size(165, 17);
            this.chkAndroidCopy.TabIndex = 7;
            this.chkAndroidCopy.Text = "Синхронизация с телефона";
            this.chkAndroidCopy.UseVisualStyleBackColor = true;
            this.chkAndroidCopy.CheckedChanged += new System.EventHandler(this.chkAndroidCopy_CheckedChanged);
            // 
            // txtSource
            // 
            this.txtSource.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::CopyPhoto.Properties.Settings.Default, "folderSyns", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSource.Location = new System.Drawing.Point(6, 62);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(297, 20);
            this.txtSource.TabIndex = 2;
            this.txtSource.Text = global::CopyPhoto.Properties.Settings.Default.folderSyns;
            // 
            // grpDest
            // 
            this.grpDest.Controls.Add(this.txtDest);
            this.grpDest.Controls.Add(this.btnBrowseDest);
            this.grpDest.Location = new System.Drawing.Point(12, 162);
            this.grpDest.Name = "grpDest";
            this.grpDest.Size = new System.Drawing.Size(439, 101);
            this.grpDest.TabIndex = 17;
            this.grpDest.TabStop = false;
            this.grpDest.Text = "Каталог для синхронизации (носитель):";
            // 
            // txtDest
            // 
            this.txtDest.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::CopyPhoto.Properties.Settings.Default, "folderDest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDest.Location = new System.Drawing.Point(6, 40);
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(300, 20);
            this.txtDest.TabIndex = 3;
            this.txtDest.Text = global::CopyPhoto.Properties.Settings.Default.folderDest;
            // 
            // grpExtension
            // 
            this.grpExtension.Controls.Add(this.txtExtension);
            this.grpExtension.Location = new System.Drawing.Point(12, 281);
            this.grpExtension.Name = "grpExtension";
            this.grpExtension.Size = new System.Drawing.Size(436, 72);
            this.grpExtension.TabIndex = 18;
            this.grpExtension.TabStop = false;
            this.grpExtension.Text = "Расширение файла(через точку)";
            // 
            // txtExtension
            // 
            this.txtExtension.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::CopyPhoto.Properties.Settings.Default, "txtExtension", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtExtension.Location = new System.Drawing.Point(7, 31);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(296, 20);
            this.txtExtension.TabIndex = 0;
            this.txtExtension.Text = global::CopyPhoto.Properties.Settings.Default.txtExtension;
            // 
            // chkLastDate
            // 
            this.chkLastDate.AutoSize = true;
            this.chkLastDate.Checked = global::CopyPhoto.Properties.Settings.Default.chkLastDate;
            this.chkLastDate.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CopyPhoto.Properties.Settings.Default, "chkLastDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkLastDate.Location = new System.Drawing.Point(214, 369);
            this.chkLastDate.Name = "chkLastDate";
            this.chkLastDate.Size = new System.Drawing.Size(156, 17);
            this.chkLastDate.TabIndex = 14;
            this.chkLastDate.Text = "Выбрать последнюю дату";
            this.chkLastDate.UseVisualStyleBackColor = true;
            this.chkLastDate.CheckedChanged += new System.EventHandler(this.chkLastDate_CheckedChanged);
            // 
            // frmCopyPhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 515);
            this.Controls.Add(this.grpExtension);
            this.Controls.Add(this.grpDest);
            this.Controls.Add(this.grpSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkLastDate);
            this.Controls.Add(this.dtpLastDate);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnCopyAllPhoto);
            this.Controls.Add(this.btnCopyLastPhoto);
            this.Name = "frmCopyPhoto";
            this.Text = "Копирование фотографий";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCopyPhoto_FormClosing);
            this.grpSource.ResumeLayout(false);
            this.grpSource.PerformLayout();
            this.grpDest.ResumeLayout(false);
            this.grpDest.PerformLayout();
            this.grpExtension.ResumeLayout(false);
            this.grpExtension.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.Button btnCopyLastPhoto;
        private System.Windows.Forms.Button btnCopyAllPhoto;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chkAndroidCopy;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.Button btnBrowseDest;
        private System.Windows.Forms.DateTimePicker dtpLastDate;
        private System.Windows.Forms.CheckBox chkLastDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.GroupBox grpDest;
        private System.Windows.Forms.GroupBox grpExtension;
        private System.Windows.Forms.TextBox txtExtension;
    }
}

