using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal.logic
{
    /// <summary>
    /// Contains the logic for if statements.
    /// </summary>
    class ifStatement
    {
        private string firstValue;
        private string secondValue;
        private string operation;
        /// <summary>
        /// Sets the first value in the equation
        /// </summary>
        /// <param name="first">The first value</param>
        public void setFirstValue(string first) { firstValue = first; }
        /// <summary>
        /// Sets the second value in the equation
        /// </summary>
        /// <param name="second">The second value</param>
        public void setSecondValue(string second) { secondValue = second; }
        /// <summary>
        /// Sets the logical operation to be performed on the two values
        /// </summary>
        /// <param name="op">Sets the logical operation (=, < , > )</param>
        public void setOperation(string op) { operation = op; }
        /// <summary>
        /// Checks the logical statement
        /// </summary>
        /// <returns>Returns ture of false depending on the outcome of the check.</returns>
        public bool checkStatement() 
        {
            switch (operation)
            {
                case "=":
                    if (firstValue == secondValue)
                        {
                        return true; 
                        }
                    else 
                    {
                        return false; 
                    }
                case ">":
                    if (int.TryParse(firstValue, out int firstNum) && int.TryParse(secondValue, out int secondNum))
                    {
                        if (firstNum > secondNum)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else 
                    {
                        break;
                    }
                case "<":
                    if (int.TryParse(firstValue, out int firstNumb) && int.TryParse(secondValue, out int secondNumb))
                    {
                        if (firstNumb < secondNumb)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        break;
                    }
            }
            return false;
        }
    }
}
