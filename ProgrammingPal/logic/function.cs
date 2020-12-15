using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal.logic
{
    /// <summary>
    /// This contains the method logic.
    /// </summary>
    class function
    {
        private string name;
        private int pointer;
        /// <summary>
        /// Gets the pointer from memory.
        /// </summary>
        /// <returns>The pointer for the start of the function.</returns>
        public int GetPointer()
        {
            return pointer;
        }

        /// <summary>
        /// Allows the user to set the pointer
        /// </summary>
        /// <param name="operand">The line for the start of the function</param>
        public void SetPointer(int operand)
        {
            pointer = operand;
        }

        /// <summary>
        /// Gets the name of the function from memory
        /// </summary>
        /// <returns>Returns the functions name</returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Sets the name of the method
        /// </summary>
        /// <param name="operand">The methods name.</param>
        public void SetName(string operand)
        {
            name = operand;
        }
    }
}
