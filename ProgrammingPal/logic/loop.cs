using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal.logic
{
    class loop
    {
        private int iteration = 0;
        private bool loopFlag = true;
        private string firstValue;
        private string secondValue;
        private string operation;
        public void setFirstValue(string first) { firstValue = first; }
        public void setSecondValue(string second) { secondValue = second; }
        public void setOperation(string op) { operation = op; }

        // Checks if the input 
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
