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

        public static void Handle(System.Windows.Forms.Label nonExsistNode)
        {
            ErrorText = nonExsistNode;

            ExceptionChecker.OnNoneExsistNode += NotifyNoneExistNode;
            ExceptionChecker.OnExistEdge += NotifyNoneExistNode;
            ExceptionChecker.OnEmptyFields += NotifyNoneExistNode;
            ExceptionChecker.OnIdenticalNode += NotifyNoneExistNode;
            ExceptionChecker.OnInputStock += NotifyNoneExistNode;
            ExceptionChecker.OnOutputIstock += NotifyNoneExistNode;
            IsError = false;
        }

        private static void NotifyNoneExistNode(string text)
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
