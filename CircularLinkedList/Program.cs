using CircularLinkedList.CustomCircularLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var circularLinkedList = new CircularLinkedList<int>();
            circularLinkedList.AddLastElement(1);
            circularLinkedList.AddLastElement(2);
            circularLinkedList.AddLastElement(3);
            circularLinkedList.AddLastElement(4);
            circularLinkedList.AddLastElement(5);

            circularLinkedList.AddFirstElement(6);

            var node = circularLinkedList.Find(3);

            if (node != null)
            {
                circularLinkedList.AddElementAfter(node,33);
            }

            circularLinkedList.Remove(5);

            var element = circularLinkedList.First;

            do
            {
                Console.WriteLine(element.NodeData);

                element = element.NextNode;

            } while (element != circularLinkedList.Last);

            Console.WriteLine(circularLinkedList.Last.NodeData);
            Console.ReadLine();
        }
    }
}
