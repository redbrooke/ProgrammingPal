using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal.logic
{
    class function
    {
        private string name;
        private int pointer;

        public int GetPointer()
        {
            return pointer;
        }

        public void SetPointer(int operand)
        {
            pointer = operand;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string operand)
        {
            name = operand;
        }
    }
}
