using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal.logic
{
    /// <summary>
    /// The class intended for variable creation
    /// </summary>
    class variable
    {
        private string name;
        private string value;
        /// <summary>
        /// Gets the value
        /// </summary>
        /// <returns>Returns the variables value</returns>
        public string GetValue()
        {
            return value;
        }

        /// <summary>
        /// Sets the vairables value
        /// </summary>
        /// <param name="operand">The value to be stored in the variable</param>
        public void SetValue(string operand)
        {
            value = operand;
        }

        /// <summary>
        /// Gets the name of the variable
        /// </summary>
        /// <returns>Sets the variable</returns>
        public string GetName()
        {
            return name;
        }
        /// <summary>
        /// Sets the variables name
        /// </summary>
        /// <param name="operand">The name for the variable. </param>
        public void SetName(string operand)
        {
            name = operand;
        }

    }
}
