using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MaximumTrafficFlow
{
    public static class ExceptionChecker
    {
        public static event Action OnExsistNode;
        public static event Action OnEmptyFields;
        public static event Action OnExistEdge;
        public static void CheckExsistNode(List<Node> nodes, string indexFrom, string indexTo)
        {
            if(indexFrom != "" && indexTo != "")
            {
                int startIndex = int.Parse(indexFrom);
                int endIndex = int.Parse(indexTo);
                if(nodes.Count == 0)
                {
                    OnExsistNode.Invoke();
                    return;
                }
                if (startIndex > nodes[nodes.Count - 1].Number | startIndex < nodes[0].Number)
                {
                    OnExsistNode.Invoke();
                }
                if (endIndex < nodes[0].Number | endIndex > nodes[nodes.Count - 1].Number)
                {
                    OnExsistNode.Invoke();
                }
            }
        } //Проверка существование узлов
        public static void CheckEmptyFields(List<TextBox> textBoxes)
        {
            foreach(TextBox textBox in textBoxes)
            {
                if(textBox.Text.Length == 0)
                {
                    OnEmptyFields.Invoke();
                    return;
                }
            }
        } //Проверка заполнения всех полей
        public static void CheckExsistEdge(List<Edge> edges, string indexFrom, string indexTo)
        {
            List<int> inputFields = new List<int>() 
            {
                int.Parse(indexFrom) - 1,
                int.Parse(indexTo) - 1,
            };
            if (inputFields[0] == inputFields[1])
            {
                OnExistEdge.Invoke();
                return;
            }

            foreach(Edge edge in edges)
            {
                List<int> actualEdges = new List<int>()
                {
                    edge.StartIndex,
                    edge.EndIndex,
                };
                if (actualEdges.SequenceEqual(inputFields)) //Проверка на идентичность списков, включая порядок
                {
                    OnExistEdge.Invoke();
                    return;
                }
            }
        }


    }
}
