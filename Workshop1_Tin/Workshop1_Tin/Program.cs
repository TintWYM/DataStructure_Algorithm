using System;
namespace DataStructureWorkshops.LList
{
    class Program
    {
        static void Main(string[] args)
        {
            LList myList = new LList();
            myList.Add("FOPCS");
            myList.Add("OOPCS");
            myList.Insert(2, "MVC.NET");
            if (myList.Contains("OOPCS"))
                myList.Insert(3, "Design");
            myList.Insert(1, "Data Structures");
            myList.Replace(3, "Java");
            myList.RemoveAt(1);
            myList.Replace(1, "Android");
            Console.WriteLine();
            for (int i = 0; i < myList.Count(); i++)
                Console.WriteLine(myList.GetAt(i));
        }
    }
    class LList
    {
        public Node Head { set; get; }
        private int numElements;

        public LList()
        {
            Head = null;
            numElements = 0;
        }
        public void Add(string element)
        {
            Node newNode = new Node(element);
            if (numElements == 0)
            {
                Head = newNode;
            }
            else
            {
                Node lastNode = GetLastNode();
                lastNode.Next = newNode;
            }
            numElements++;
        }
        private Node GetNodeAt(int index)
        {
            if (index >= 0 && index <= numElements - 1)
            {
                Node curNode = Head;
                for (int i = 0; i < index; i++)
                {
                    curNode = curNode.Next;
                }
                return curNode;
            }
            return null;
        }
        private Node GetLastNode()
        {
            return GetNodeAt(numElements - 1);
        }
        public void Insert(int index, string newElement)
        {
            if (index >= 0 && index <= numElements)
            {
                Node newNode = new Node(newElement);
                if (index == 0)
                {
                    newNode.Next = Head;
                    Head = newNode;
                }
                else
                {
                    Node nodeBefore = GetNodeAt(index - 1);
                    Node nodeAfter = nodeBefore.Next;
                    nodeBefore.Next = newNode;
                    newNode.Next = nodeAfter;
                }
                numElements++;
            }
            // else Invalid Index
        }
        public string GetAt(int index)
        {
            Node node = GetNodeAt(index);
            if (node != null)
                return node.Data;
            return null;
        }
        public void RemoveAt(int index)
        {
            if (index >= 0 && index <= numElements - 1)
            {
                if (index == 0)
                {
                    Head = Head.Next;
                }
                else
                {
                    // Get the node before the one that we want to remove
                    Node beforeNode = GetNodeAt(index - 1);
                    Node nodeToRemove = beforeNode.Next;
                    // Get the node after the one that we want to remove
                    Node afterNode = nodeToRemove.Next;
                    beforeNode.Next = afterNode;
                }
                numElements--;
            }
            // else Invalid index
        }
        public int Count()
        {
            return numElements;
        }
        public void Replace(int index, string newElement)
        {
            Node node = GetNodeAt(index);
            if (node != null)
            {
                node.Data = newElement;
            }
        }
        public bool Contains(string element)
        {
            // Loop through all the node inside the list
            Node curNode = Head;
            for (int i = 0; i <= numElements - 1; i++)
            {
                // Get the current node
                // If the current node's data is the same as the element
                if (curNode.Data.Equals(element))
                    return true;
                else
                {
                    // Go to the next node
                    curNode = curNode.Next;
                }
            }
            // After looping, element can not be found after going through all the node
            return false;
        }
    }
    class Node
    {
        public string Data { set; get; }
        public Node Next { set; get; }
        public Node(string data)
        {
            Data = data;
            Next = null;
        }
    }
}
