using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal.logic
{
    /// <summary>
    /// A factory class for creating logic
    /// </summary>
    class logicFactory
    {
        object returnLogic = null;
        /// <summary>
        /// Intended to create an if statement
        /// </summary>
        /// <param name="logic">The type of logic to be peformed on the two values</param>
        /// <param name="firstParam">the first value to be checked</param>
        /// <param name="secondParam">The second value to be checked.</param>
        /// <returns></returns>
        public ifStatement createIf(string logic, string firstParam, string secondParam) 
        {
            ifStatement returnLogic = new ifStatement();
            returnLogic.setFirstValue(firstParam);
            String[] strlist = secondParam.Split(',');
            returnLogic.setOperation(strlist[0]);
            returnLogic.setSecondValue(strlist[1]);
            return returnLogic;
        }
        /// <summary>
        /// Intended to create a function
        /// </summary>
        /// <param name="logic">The type of logic to be peformed on the two values</param>
        /// <param name="firstParam">the first value to be checked</param>
        /// <param name="secondParam">The second value to be checked.</param>
        /// <returns></returns>
        public function createDef(string logic, string firstParam, string secondParam) 
        {
            function returnLogic = new function();
            returnLogic.SetName(firstParam);
            returnLogic.SetPointer(int.Parse(secondParam));
            return returnLogic;
        }
        /// <summary>
        /// Intended to create a variable
        /// </summary>
        /// <param name="logic">The type of logic to be peformed on the two values</param>
        /// <param name="firstParam">the first value to be checked</param>
        /// <param name="secondParam">The second value to be checked.</param>
        /// <returns></returns>
        public variable createVar(string logic, string firstParam, string secondParam) 
        {
            variable returnLogic = new variable();
            returnLogic.SetName(firstParam);
            returnLogic.SetValue(secondParam);
            return returnLogic;
        }
    }
}
