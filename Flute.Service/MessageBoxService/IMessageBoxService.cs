using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppService
{
    public interface IMessageBoxService
    {
        void Debug(object text);
        void ShowInfo(string title, string text, string detail);
        void ShowWarning(string title, string text, string detail);
        void AskQuestion(string title, string text, string detail);
        void ShowError(string title, string text, string detail);
        void ShowFatal(string title, Exception ex);
    }
}
