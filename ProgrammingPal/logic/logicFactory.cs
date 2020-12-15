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



            if (logic == "while") { loop returnLogic = new loop(); }
            else if (logic == "variable") { variable returnLogic = new variable(); }
            return returnLogic;
        }

        public ifStatement createIf(string logic, string firstParam, string secondParam) 
        {
            ifStatement returnLogic = new ifStatement();
            returnLogic.setFirstValue(firstParam);
            String[] strlist = secondParam.Split(',');
            returnLogic.setOperation(strlist[0]);
            returnLogic.setSecondValue(strlist[1]);
            return returnLogic;
        }

        public function createDef(string logic, string firstParam, string secondParam) 
        {
            function returnLogic = new function();
            returnLogic.SetName(firstParam);
            returnLogic.SetPointer(int.Parse(secondParam));
            return returnLogic;
        }
        public variable createVar(string logic, string firstParam, string secondParam) 
        {
            variable returnLogic = new variable();
            returnLogic.SetName(firstParam);
            returnLogic.SetValue(secondParam);
            return returnLogic;
        }
    }
}
