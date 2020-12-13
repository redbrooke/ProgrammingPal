using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal.logic
{
    class logicFactory
    {
        object returnLogic = null;
        public object createLogic(string logic, string firstParam, string secondParam) 
        {
            if (logic == "if") 
            { 
                ifStatement returnLogic = new ifStatement();
                returnLogic.setFirstValue(firstParam);
                String[] strlist = secondParam.Split(',');
                returnLogic.setOperation(strlist[0]);
                returnLogic.setSecondValue(strlist[1]);
            }

            else if (logic == "def") 
            { 
                function returnLogic = new function(); 
                returnLogic.SetName(firstParam); 
                returnLogic.SetPointer(int.Parse(secondParam)); 
            }

            else if (logic == "while") { loop returnLogic = new loop(); }
            else if (logic == "variable") { variable returnLogic = new variable(); }
            return returnLogic;
        }
    }
}
