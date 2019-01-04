using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;
using System.Windows;
using System.Diagnostics;

namespace Flute.MessageBoxService
{
    public sealed class MessageBoxWPF
    {
        private MessageBoxWPF() { }
		/// <summary>
		/// Shows debug.
		/// </summary>
		/// <param name="text"></param>
        [Conditional("DEBUG")]
        public static void Debug(object text)
        {
            MessageBox.Show(text.ToString(),
                            "Debug",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }
		/// <summary>
		/// Shows info.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="text"></param>
		/// <param name="detail"></param>
		/// <returns></returns>
        public static void Info(string title, string text, string detail)
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
		/// <summary>
		/// Shows warning.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="text"></param>
		/// <param name="detail"></param>
		/// <returns></returns>
		public static void Warn(string title, string text, string detail)
		{
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Warning);
		}
		/// <summary>
		/// Shows error.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="text"></param>
		/// <param name="detail"></param>
		/// <returns></returns>
		public static void Error(string title, string text, string detail)
		{
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Error);
		}
		/// <summary>
		/// Shows fatal.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="ex"></param>
		/// <returns></returns>
		public static void Fatal(string title, Exception ex)
		{
            MessageBox.Show(ex.Message, title, MessageBoxButton.OK, MessageBoxImage.Error);
		}
		/// <summary>
		/// Shows confirmation.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="text"></param>
		/// <param name="detail"></param>
		/// <returns>DialogResult.Yes or DialogResult.No is returned.</returns>
		public static MessageBoxResult Confirm(string title, string text, string detail,MessageBoxResult defaultResult)
		{
			return MessageBox.Show(text, title, MessageBoxButton.YesNo, MessageBoxImage.Question,MessageBoxResult.Yes);
		}
    }
}
