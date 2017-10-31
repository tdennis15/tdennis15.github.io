using System;
using System.Collections.Generic;
using System.Text;

namespace PostFixCalculator
{
    /*
     * Node class to hold data and carry it between classes
     * */
    class Node
    {
        object data; //global variables
        Node next; //next node in chain

        //default constructor
        public Node()
        {
            data = null;
            next = null;
        }

        //constructor with 2 params for data and next
        //iData and iNext for input data and input next
        public Node(object iData, Node iNext)
        {
            data = iData;
            next = iNext;
        }

        /*
         * the following code is Aaron Earl's solution to the global variable accessibility issue with the other classes 
         * accessing this class.
         * */

        public object Data { get { return data; } set { data = value; } }

        public Node Next { get { return next; } set { next = value; } }
    }
}
