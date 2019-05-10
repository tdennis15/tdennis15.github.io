using System;
using System.Collections.Generic;
using System.Text;

namespace PostFixCalculator
{
    /*
     * A linked stack for use in a postfix calculator, Strongly typed and will implement the interface IStackADT.
     * */
    class LinkedStack : IStackADT
    {
           //Node from separate class as a variable
        private Node top;

        public LinkedStack()
        {
            top = null; //empty stack
        }

        public object Push(object newItem)
        {
            if(newItem == null)
            {
                return null;
            }
            Node newNode = new Node(newItem, top);
            top = newNode;
            return newItem;
        }

        public object pop()
        {
            if (isEmpty())
            {
                return null;
            }
            object topItem = top.Data;
            top = top.Next;
            return topItem;
        }
        public object peek()
        {
            if (isEmpty())
            {
                return null;
            }
            return top.Data;
        }
        public Boolean isEmpty()
        {
            return top == null;
        }
        public void clear()
        {
            top = null;
        }
    }
    
}
