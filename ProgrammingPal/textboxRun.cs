using ProgrammingPal.logic;
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

            // compileCode
            Compiler compile = new Compiler();
            string[] compiledCode = 
            // Parses the compiled code
            Array.ForEach(fullInput, input =>
            {
                toDraw.Add(parse(input));
            });


            return toDraw;
        }

    }
}
