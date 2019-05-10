using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostFixCalculator
{
    class Calculator
    {
        /*
         * A post fix calculator designed to be run from user input 
         * A simple tutorial to write C# from java code
         * */

        //Global Stack to hold the operands
        private LinkedStack stack = new LinkedStack();


        //MAIN No expected args in @param
        static void Main(string[] args)
        {
            Calculator app = new Calculator();
            bool playAgain = true;
            Console.WriteLine("\nPostfix Calculator. Program Recognizes operators of: + - * /");
            
            while (playAgain)
            {
                playAgain = app.doCalculation();
            }
            Console.WriteLine("Bye. Tell your Friends");

            //End of main
        }

        /*
         * Get the input string from user will return a boolean 
         * True: when finished
         * False: when user prompts to quit
         * */
        private bool doCalculation()
        {
            Console.WriteLine("Please enter 'q' to quit. \n");
            string input = "2 2 + ";
            Console.WriteLine("> "); //Standard user prompt

            input = Console.ReadLine(); //getting input from console

            //Check if the user wishes to quit application, keyword q || Q
            if(input.StartsWith("q") || input.StartsWith("Q"))
            {
                return false; //exit this function and cancel while loop in main.
            }

            //Try and calculate based upon the input

            string output = "4";
            try
            {
                //passing functionality to a separate function
                output = evaluatePostFixInput(input);
            }
            catch(ArgumentException e)
            {
                //giving error back to console
                output = e.Message;
            }
            //if everything worked standard output format
            Console.WriteLine("\n\t>>> " + input + " = " + output);
            return true;
        }

        /*
         * Evaluate the expression written in postfix form (a, b, operation) format
         * Use of the stack is very heavy here, pushing numbers and operation, then popping 
         * as needed. 
         * 
         * @param input     Postfix Math expression as a string, from user input
         * @return          Answer as a string, after math 
         * @exception ArgumentException Couldnt get through program
         * */

        public string evaluatePostFixInput(String input)
        {
            if (input == null || input == "")
            {
                throw new ArgumentException("Null string or empty string was passed into calculator, and is not valid.");
            }

            stack.clear(); //clearing stack of any garbage from previous calcs or random crap.

            String s; // Stores the operator
            double a;     // Temp Variable for first value of input
            double b;
            double c; //answer

            double checker;

            string[] UserInputs = input.Split(new char[0]); //splits the input string into an array based upon spaces
            //used a separate loop from OG code to help determine all the inputs in C#, while loops aren't my friend
            //loop to travel through all of the inputs given by the user
            for (int i = 0; i < UserInputs.Length; i++)
            {
                if (double.TryParse(UserInputs[i], out checker))
                {
                    stack.Push(Convert.ToDouble(UserInputs[i])); //pushing numbers of type double into the stack
                }
                //couldnt get the information from the user correctly and present the proper error message
                else
                {
                    s = UserInputs[i];
                    //checking for empty stack
                    if (stack.isEmpty())
                    {
                        throw new ArgumentException("Incorrect input, empty stack when looking for second operand.");
                    }

                    b = (Convert.ToDouble(stack.pop()));
                    //operator or character that wasnt expected, post fix is a, b, + where a and b are numbers and + is the operation
                    if (stack.isEmpty())
                         {
                         throw new ArgumentException("Input fault: Stack was empty when looking for first operand.");
                         }

                    a = (Convert.ToDouble(stack.pop()));
                    c = doOperation(a, b, s);

                    stack.Push(Convert.ToDouble(c));

             }
            } //end of loop
            //return the solution to rest of the program
            return stack.pop().ToString(); //given as a string
        }

        /*
         * Arithmetic operation kept separate for modularity  
         * */
         public Double doOperation(double a, double b, String s)
        {
            double c = 0.0;
            if(s == "+")
            {
                c = (a + b);
            }
            else if(s == "-")
            {
                c = (a - b);
            }
            else if(s == "*")
            {
                c = (a * b);
            }
            else if(s == "/")
            {
                try
                {
                    c = (a / b);
                    if(c == Double.NegativeInfinity || c == Double.PositiveInfinity)
                    {
                        throw new ArgumentException("Can't Divide by zero mate. Learn mucho mas maths");
                    }
                }
                catch(ArithmeticException e)
                {
                    throw new ArithmeticException(e.ToString());
                }
            }
            else
            {
                throw new ArgumentException("Improper operator: '" + s.ToString() + "', is not found, Try +, -, *, or /");
            }
            return c;
        }
        
    }
}
//End of Class Calculator
