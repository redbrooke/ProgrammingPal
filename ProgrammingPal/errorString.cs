using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal
{
    /// <summary>This class uses the error testing. It essentially takes an error code and parses it into a displayable string </summary>
    abstract class ErrorString
    {
        /// <summary>Method to generate the error string.</summary>
        public string getError(Tuple<string, int, int> error)
            {
            string returnMe = "ERROR: ";
            switch (error.Item2) 
            {
                case 0:
                    returnMe += "Unknown";
                    break;
                case 1:
                    returnMe += "Invalid";
                    break;
                case 2:
                    returnMe += "Invalid";
                    break;
                case 3:
                    returnMe += "String Param Error";
                    break;
                case 99:
                    returnMe += "Uncaught";
                    break;
            }
            return returnMe;
            }
    }
}
