using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal
{
    class textboxRun : CommandHandler
    {
        public Tuple<string, int, int> returnInstruction(string input)
        { 
            //parses input.
            var parsedInput = parse(input);
            var toDraw = new Tuple<string, int, int>(parsedInput.Item1, parsedInput.Item2, parsedInput.Item3);
            return toDraw;
        }

    }
}
