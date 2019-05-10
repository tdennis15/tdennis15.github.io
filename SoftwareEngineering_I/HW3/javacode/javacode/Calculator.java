
// API Imports
import java.util.Scanner;
import java.io.IOException;

/**
 *  Command line postfix calculator.  This code makes use of java.lang.IllegalArgumentException
 *	to indicate when there is a problem with the input expression.  I probably should have written my own
 *	exception class that is specific to this application, but this one sounds appropriate. 
 *
 *@author    Scot Morse
 */
public class Calculator
{
	/**
	 *  Our data structure, used to hold operands for the postfix calculation.
	 */
	private StackADT stack = new LinkedStack();

	/** Scanner to get input from the user from the command line. */
	private Scanner scin = new Scanner( System.in );

	/**
	 *  Entry point method. Disregards any command line arguments.
	 *
	 *@param  args  The command line arguments
	 */
	public static void main( String[] args )
	{
		// Instantiate a "Main" object so we don't have to make everything static
		Calculator app = new Calculator();
		boolean playAgain = true;
		System.out.println("\nPostfix Calculator. Recognizes these operators: + - * /");
		while( playAgain )
		{
			playAgain = app.doCalculation();
		}
		System.out.println("Bye.");
	}

	/**
	 *  Get input string from user and perform calculation, returning true when
	 *  finished. If the user wishes to quit this method returns false.
	 *
	 *@return    true if a calculation succeeded, false if the user wishes to quit
	 */
	private boolean doCalculation()
	{
		System.out.println("Please enter q to quit\n");
		String input = "2 2 +";
		System.out.print("> ");			// prompt user
	
		input = scin.nextLine();		
		// looks like nextLine() blocks for input when used on an InputStream (System.in).  Docs don't say that!
		
		// See if the user wishes to quit
		if( input.startsWith( "q" ) || input.startsWith( "Q" ) )
		{
			return false;
		}
		// Go ahead with calculation
		String output = "4";
		try
		{
			output = evaluatePostFixInput( input );
		}
		catch( IllegalArgumentException e )
		{
			output = e.getMessage();
		}
		System.out.println("\n\t>>> " + input + " = " + output);
		return true;
	}


	/**
	 *  Evaluate an arithmetic expression written in postfix form.
	 *
	 *@param  input                         Postfix mathematical expression as a String
	 *@return                               Answer as a String
	 *@exception  IllegalArgumentException  Something went wrong
	 */
	public String evaluatePostFixInput( String input ) throws IllegalArgumentException
	{
		if( input == null || input.equals("") )
			throw new IllegalArgumentException("Null or the empty string are not valid postfix expressions.");
		// Clear our stack before doing a new calculation
		stack.clear();

		String s;	// Temporary variable for token read
		double a;	// Temporary variable for operand
		double b;	// ...for operand
		double c;	// ...for answer

		Scanner st = new Scanner( input );
		while( st.hasNext() )
		{
			if( st.hasNextDouble() )
			{
				stack.push( new Double( st.nextDouble() ) );	// if it's a number push it on the stack
			}
			else
			{
				// Must be an operator or some other character or word.
				s = st.next();
				if( s.length() > 1 )
					throw new IllegalArgumentException("Input Error: " + s + " is not an allowed number or operator");
				// it may be an operator so pop two values off the stack and perform the indicated operation
				if( stack.isEmpty() )
					throw new IllegalArgumentException( "Improper input format. Stack became empty when expecting second operand." );
				b = ( (Double)( stack.pop() ) ).doubleValue();
				if( stack.isEmpty() )
					throw new IllegalArgumentException( "Improper input format. Stack became empty when expecting first operand." );
				a = ( (Double)( stack.pop() ) ).doubleValue();
				// Wrap up all operations in a single method, easy to add other binary operators this way if desired
				c = doOperation( a, b, s );
				// push the answer back on the stack
				stack.push( new Double( c ) );
			}
		}// End while
		return ( (Double)( stack.pop() ) ).toString();
	}


	/**
	 *  Perform arithmetic.  Put it here so as not to clutter up the previous method, which is already pretty ugly.
	 *
	 *@param  a                             First operand
	 *@param  b                             Second operand
	 *@param  s                             operator
	 *@return                               The answer
	 *@exception  IllegalArgumentException  Something's fishy here
	 */
	public double doOperation( double a, double b, String s ) throws IllegalArgumentException
	{
		double c = 0.0;
		if( s.equals( "+" ) )		// Can't use a switch-case with Strings, so we do if-else
			c = ( a + b );
		else if( s.equals( "-" ) )
			c = ( a - b );
		else if( s.equals( "*" ) )
			c = ( a * b );
		else if( s.equals( "/" ) )
		{
			try
			{
				c = ( a / b );
				if( c == Double.NEGATIVE_INFINITY || c == Double.POSITIVE_INFINITY )
					throw new IllegalArgumentException("Can't divide by zero");
			}
			catch( ArithmeticException e ) 
			{
				throw new IllegalArgumentException(e.getMessage());
			}
		}
		else
			throw new IllegalArgumentException( "Improper operator: " + s + ", is not one of +, -, *, or /" );

		return c;
	}

}// end class Calculator


