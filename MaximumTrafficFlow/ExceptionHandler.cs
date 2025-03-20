using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaximumTrafficFlow
{
    public static class ExceptionHandler
    {
        private static System.Windows.Forms.Label ErrorText { get; set; }
        public static bool IsError { get; private set; }
        public static void HandleBuildEdge(System.Windows.Forms.Label errorText)
        {
            ErrorText = errorText;
            ExceptionChecker.OnNoneExsistNode += NotifyError;
            ExceptionChecker.OnExistEdge += NotifyError;
            ExceptionChecker.OnEmptyFields += NotifyError;
            ExceptionChecker.OnIdenticalNode += NotifyError;
            ExceptionChecker.OnInputStock += NotifyError;
            ExceptionChecker.OnOutputIstock += NotifyError;
            IsError = false;
        }

        public static void HandleFindMinimalCut(System.Windows.Forms.Label errorText)
        {
            ErrorText = errorText;
            ExceptionChecker.OnIsolatedNode += NotifyError;
            ExceptionChecker.OnExsistGraph += NotifyError;
            IsError = false;
        }

        public static void HandleDeleteNode(System.Windows.Forms.Label errorText)
        {
            ErrorText = errorText;
            ExceptionChecker.OnDeleteNode += NotifyError;
            IsError = false;
        }

        private static void NotifyError(string text)
        {
            ErrorText.Text = text;
            IsError = true;
            Task.Run(() => ShowException(ErrorText));
        }

        private static void ShowException(System.Windows.Forms.Label textBlock)
        {
            textBlock.Invoke(new Action(() => textBlock.Visible = true));
            Thread.Sleep(2000);
            textBlock.Invoke(new Action(() => textBlock.Visible = false));
        }
    }
}
