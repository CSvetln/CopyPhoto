using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyPhoto
{
    public class LoggerService : ILoggerService
    {
        private readonly TextBox _logTextBox;
        private readonly Form _form;

        public LoggerService(TextBox logTextBox, Form form)
        {
            _logTextBox = logTextBox;
            _form = form;
        }

        public void Log(string message)
        {
            if (_logTextBox.InvokeRequired)
            {
                _form.Invoke(new Action<string>(Log), message);
                return;
            }

            _logTextBox.AppendText($"{DateTime.Now:HH:mm:ss} - {message}\r\n");
            _logTextBox.ScrollToCaret();
        }
    }
}
