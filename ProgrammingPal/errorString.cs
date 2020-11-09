using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal
{
    class errorString
    {
        public string getError(Tuple<string, int, int> error)
            {
            string returnMe = "ERROR: ";
            switch (error.Item2) 
            {
                case 0:
                    returnMe += "Unknown";
                    break;
                case 1:
                    returnMe += "Invalid Parameter";
                    break;
                case 2:
                    returnMe += "Invalid Command";
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
