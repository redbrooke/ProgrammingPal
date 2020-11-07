using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal
{
    class CommandHandler
    {

        public Tuple<string, int, int> parse(String line) 
        {
            string[] split;
            string command;
            string[] parameters;
            int[] paramsAsInt = { 0, 0 }; // needs to be assigned in scole, hence null. 

            line = line.ToLower();
            split = line.Split(' ');

            command = split[0];
            parameters = split[1].Split(',');

            for (int i = 0; i < parameters.Length; i++)
            {
                paramsAsInt[i] = int.Parse(parameters[i]);
            }

            // error check

            var parsed = new Tuple<string, int, int>(command, paramsAsInt[0], paramsAsInt[1]);
            return parsed;
        }

    }
}
