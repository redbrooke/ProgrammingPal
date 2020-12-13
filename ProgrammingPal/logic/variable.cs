using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal.logic
{
    class variable
    {
        private string name;
        private string value;

        public string GetValue()
        {
            return value;
        }

        public void SetValue(string operand)
        {
            value = operand;
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
