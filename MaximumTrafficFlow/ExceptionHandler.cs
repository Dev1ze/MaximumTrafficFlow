using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MaximumTrafficFlow
{
    public static class ExceptionHandler
    {
        private static System.Windows.Forms.Label NoneExistNode { get; set; }
        private static System.Windows.Forms.Label NoneExistEdge { get; set; }
        private static System.Windows.Forms.Label EmptyFields { get; set; }
        public static bool IsError { get; private set; }

        public static void Handle(System.Windows.Forms.Label nonExsistNode, System.Windows.Forms.Label emptyFields, 
            System.Windows.Forms.Label nonExsistEdge)
        {
            NoneExistNode = nonExsistNode;
            EmptyFields = emptyFields;
            NoneExistEdge = nonExsistEdge;
            ExceptionChecker.OnExsistNode += NotifyNoneExistNode;
            ExceptionChecker.OnEmptyFields += NotifyEmptyFields;
            ExceptionChecker.OnExistEdge += NotifyNoneExistEdge;
            IsError = false;
        }

        private static void NotifyNoneExistNode()
        {
            NoneExistNode.Visible = true;
            EmptyFields.BringToFront();
            IsError = true; 
        }
        private static void NotifyEmptyFields()
        {
            EmptyFields.Visible = true;
            EmptyFields.BringToFront();
            IsError = true;
        }
        private static void NotifyNoneExistEdge()
        {
            NoneExistEdge.Visible = true;
            EmptyFields.BringToFront();
            IsError = true;
        }
    }
}
