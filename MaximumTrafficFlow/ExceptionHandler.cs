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
        private static System.Windows.Forms.Label NoneExistNode { get; set; } //Указаны несуществующие узлы
        private static System.Windows.Forms.Label ExistEdge { get; set; } //Такое ребро уже есть
        private static System.Windows.Forms.Label EmptyFields { get; set; } // Не все поля заполнены
        private static System.Windows.Forms.Label IdenticalNode { get; set; } //Ребро должно иметь направление
        public static bool IsError { get; private set; }

        public static void Handle
        (
            System.Windows.Forms.Label nonExsistNode, 
            System.Windows.Forms.Label exsistEdge,
            System.Windows.Forms.Label emptyFields, 
            System.Windows.Forms.Label identicalNode
        )
        {
            NoneExistNode = nonExsistNode;
            ExistEdge = exsistEdge;
            EmptyFields = emptyFields;
            IdenticalNode = identicalNode;
            ExceptionChecker.OnNoneExsistNode += NotifyNoneExistNode;
            ExceptionChecker.OnExistEdge += NotifyExistEdge;
            ExceptionChecker.OnEmptyFields += NotifyEmptyFields;
            ExceptionChecker.OnIdenticalNode += NotifyIdenticalNode;
            IsError = false;
        }

        private static void NotifyNoneExistNode()
        {
            //Заморозить поток дополнительный который задерживает показ на 3 секунды потом висибл опять фолс
            NoneExistNode.Visible = true;
            EmptyFields.BringToFront();
            IsError = true; 
        }

        private static void NotifyExistEdge()
        {
            ExistEdge.Visible = true;
            EmptyFields.BringToFront();
            IsError = true;
        }

        private static void NotifyEmptyFields()
        {
            EmptyFields.Visible = true;
            EmptyFields.BringToFront();
            IsError = true;
        }

        private static void NotifyIdenticalNode()
        {
            IdenticalNode.Visible = true;
            EmptyFields.BringToFront();
            IsError = true;
        }
    }
}
