﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal
{
    /// <summary>This class takes in the users command text box input and feeds it to the parser, then returns a formatted version.</summary>
    class commandRun : CommandHandler
    {
        public Tuple<string,int, int> returnInstruction(string input)
        { //Tuple is like an array but immutable and more memory efficient. https://developerpublish.com/3-options-to-return-multiple-values-from-a-method-in-c/

            //parses input.
            var parsedInput = parse(input);


            var toDraw = new Tuple<string, int, int>(parsedInput.Item1, parsedInput.Item2, parsedInput.Item3);
            return toDraw;
        }

    }
}
