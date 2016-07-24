using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList.CustomCircularLinkedList
{
    public class CircularLinkedList<T> : IEnumerable<T>
    {
        #region Construcror


        #endregion
        #region Private Field/Representations

        private Node<T> headOfList;

        private Node<T> tailOfList;

        #endregion
        #region Propperties
        public int Count { get; set; }

        public Node<T> First
        {
            get
            {
                return headOfList;
            }
        }

        public Node<T> Last
        {
            get
            {
                return tailOfList;
            }
        }

        public bool IsEmpty
        {
            get { return headOfList == null; }
        }

        #endregion

        #region Public Methods

        public Node<T> AddLastElement(T value)
        {
            Node<T> node = new Node<T>(value);

            if (headOfList == null)
            {
                headOfList = node;
                tailOfList = headOfList;
                tailOfList.NextNode = headOfList;
            }
            else
            {
                tailOfList.NextNode = node;
                node.NextNode = headOfList;
                tailOfList = node;
            }

            ++Count;

            return node;
        }
               
        public Node<T> AddFirstElement(T value)
        {
            Node<T> node = new Node<T>(value);

            if (headOfList == null)
            {
                headOfList = node;
                tailOfList = headOfList;
                tailOfList.NextNode = headOfList;
            }
            else
            {
                node.NextNode = headOfList;
                headOfList = node;
                tailOfList.NextNode = node;
            }

            ++Count;

            return node;
        }

        public Node<T> AddElementAfter(Node<T> node, T value)
        {
            if (node == null)
            {
                throw new Exception("Node cannot be null");
            }

            if (tailOfList == node)
            {
                return AddLastElement(value);
            }

            Node<T> newNode = new Node<T>(value) { NextNode = node.NextNode };
            node.NextNode = newNode;

            ++Count;

            return node;
        }
                
        public Node<T> Find(T value)
        {
            Node<T> prevNode = FindPrevNode(value);

            if (prevNode == null)
            {
                return null;
            }

            return prevNode.NextNode;
        }

       public void Remove(T value)
        {
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            Node<T> prevNode = FindPrevNode(value);

            if (prevNode == null)
            {
                return;
            }

            if (prevNode.NextNode == tailOfList)
            {
                tailOfList = prevNode;
                tailOfList.NextNode = headOfList;
                return;
            }

            if (prevNode.NextNode == headOfList)
            {
                tailOfList.NextNode = headOfList.NextNode;
                headOfList = headOfList.NextNode;
                return;
            }

            prevNode.NextNode = prevNode.NextNode.NextNode;
        }


        private Node<T> FindPrevNode(T value)
        {
            if (headOfList == null)
            {
                throw new Exception("List is empty");
            }

            Node<T> temp = headOfList;
            int length = 0;

            if (headOfList.NodeData.Equals(value))
            {
                return tailOfList;
            }

            while (temp != null && length <= Count)
            {
                if (temp.NextNode != null && temp.NextNode.NodeData.Equals(value))
                {
                    return temp;
                }

                temp = temp.NextNode;
                ++length;
            }

            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> temp = headOfList;

            while (temp != null)
            {
                yield return temp.NodeData;
                temp = temp.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

    }
}
