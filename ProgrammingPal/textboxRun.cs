using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal
{
    /// <summary>This class houses the logic for the commadnLine</summary>
    class textboxRun : CommandHandler
    {
        /// <summary>This class takes in the users commandline input and feeds it to the parser, then returns a formatted version.</summary>
        public Tuple<string, int, int> returnInstruction(string input)
        { 
            //parses input.
            var parsedInput = parse(input);
            var toDraw = new Tuple<string, int, int>(parsedInput.Item1, parsedInput.Item2, parsedInput.Item3);
            return toDraw;
        }

    }
}
