/**
 * A singly linked stack implementation.
 */
public class LinkedStack implements StackADT
{
	private Node top;
	
	public LinkedStack()
	{
		top = null;	// Empty stack condition
	}
	
	public Object push(Object newItem)
	{
		if( newItem == null )
		{
			return null;
		}
		Node newNode = new Node(newItem,top);
		top = newNode;
		return newItem;
	}
	
	public Object pop()
	{
		if( isEmpty() )
		{
			return null;
		}
		Object topItem = top.data;
		top = top.next;
		return topItem;
	}
	
	public Object peek()
	{
		if( isEmpty() )
		{
			return null;
		}
		return top.data;
	}
	
	public boolean isEmpty()
	{
		return top == null;
	}
	
	public void clear()
	{
		top = null;
	}
	
}
