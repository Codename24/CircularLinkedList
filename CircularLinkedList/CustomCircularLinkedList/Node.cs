using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList.CustomCircularLinkedList
{
    public class Node<T>
    {
        public Node(T nodeData)
        {
            this.NodeData = nodeData;
        }

        public T NodeData { get; set; }

        public Node<T> NextNode { get; set; }
    }
}
