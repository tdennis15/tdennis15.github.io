using System;
using System.Collections.Generic;
using System.Text;

namespace PostFixCalculator
{
    /*
     *Interface for the stack functionality in LinkedStack.
     * Basic Stack functionality.
     **/

    interface IStackADT
    {

        /*
         *  * Push an item onto the top of the stack. Pushing an object that 
	 * doesn’t exist should result in an error and should not succeed.
	 * Pushing an object that is not an item should result in an error.
	 * This operation returns a reference (pointer or link, but not a copy)
	 * to the item pushed so that an anonymous object can be pushed and then used.
	 * @param newItem The object to push onto the top of the stack.  Should not be null
	 * @return A reference to the object that was pushed, or null if newItem == null
     * 
     * difference between Java and C# is dont declare the scope public
         * */
        object Push(object newItem);

        /**
         * Remove and return the top item on the stack. This operation should 
         * result in an error if the stack is empty. Returns a reference to the 
         * item removed.
         * @return A reference that was popped (and removed) from the stack or null if
         * 			the stack is empty
         */
        object pop();

        /**
 * Return the top item but do not remove it. Generally should result in 
 * an error if the stack is empty. An acceptable alternative is to return 
 * something which the user can use to check to see if the stack was in fact empty.
 * @return A reference to the item currently on the top of the stack or null if
 * 			the stack is empty
 */
        object peek();

        /**
	 * Query the stack to see if it is empty or not. Cannot produce an error.
	 * @return True if the stack is empty, false otherwise
	 */
        bool isEmpty();

        /**
         * Reset the stack by emptying it. The exact technique used to clear 
         * the stack is up to the implementor. The user should pay attention to what 
         * this behavior is.
         */
        void clear();
    }
}
