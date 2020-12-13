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
        private List<Tuple<String, int, int>> toDraw = new List<Tuple<String, int, int>>();

        /// <summary>This class takes in the users commandline input and feeds it to the parser, then returns a formatted version.</summary>
        public List<Tuple<string, int, int>> returnInstructions(string[] fullInput)
        {
           // 
            bool done = false;
            var count = 0;

            // Parses the compiled code
            Array.ForEach(fullInput, input =>
            {

                var parsedInput = parse(input);
                var toDrawNext = new Tuple<string, int, int>(parsedInput.Item1, parsedInput.Item2, parsedInput.Item3);
                toDraw[count] = toDrawNext;
                count++;
            });


            return toDraw;
        }

    }
}
