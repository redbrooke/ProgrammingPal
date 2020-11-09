using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingPal
{
    /// <summary>This class is abstract and only used to parse commands and encode the data. If there are errors these are encoded and sent to its children too,</summary>
    abstract class CommandHandler
    {
        string command;
        string[] split;
        string[] parameters = { "invalid", "invalid"};
        int[] paramsAsInt = { 99, 99 }; // needs to be assigned in scole, hence null.
        public static string[] CommandsTwoParams = { "drawto", "moveto", "rectangle" };
        public static string[] CommandsOneParams = { "square", "circle", "triangle" };
        public static string[] CommandsNoParams = { "clear", "reset", "run" };
        public static string[] CommandsString = { "color", "fill" };

        /// <summary>This method takes a line of code and splits it into a special data-type. These dataypes use Tuples and are layed out as (string, int, int) </summary>
        public Tuple<string, int, int> parse(String line) 
        {
            command = "";

            line = line.ToLower();
            split = line.Split(' ');

            command = split[0];

            //checks if the paramets are needed
            if (!CommandsNoParams.Contains(command) && split.Length > 1)
            {
                parameters = split[1].Split(',');
            }
            else if (!CommandsNoParams.Contains(command) && split.Length == 1)
            {
                return new Tuple<string, int, int>("error", 2, 1);
            }
            else if (!CommandsNoParams.Contains(command) && split.Length <= 1) 
            { 
                return new Tuple<string, int, int>("error", 1, 3);
            }

            command = checkCommand(command);
            if (command == "error") 
            {
                return new Tuple<string, int, int>(command, 2, 1);
            }
            // Checks to see if the parameters are supposed to be strings
            if (CommandsString.Contains(command))
            {
                paramsAsInt = parseString(parameters[0]);
            }
            else
            {
                paramsAsInt = checkParams(parameters);
            }

            var parsed = new Tuple<string, int, int>(command, paramsAsInt[0], paramsAsInt[1]);
            return parsed;
        }

        /// <summary>This method checks that the command is valid.</summary>
        private string checkCommand(String command)
        {
            if (CommandsTwoParams.Contains(command) | CommandsOneParams.Contains(command) | CommandsNoParams.Contains(command) | CommandsNoParams.Contains(command))
            {
                return command;
            }
            else 
            {
                int[] paramsAsInt = new int[] { 2, 1 };
                return "error";
            }
        }

        /// <summary>This class checks if the paramters are valid and encodes them.</summary>
        private int[] checkParams(string[] parameters) 
        {
            // Error checking for if its a command needing two parameters
            if (CommandsTwoParams.Contains(command) && parameters.Length == 2)
            {
                if (int.TryParse(parameters[0], out int first) && (int.TryParse(parameters[1], out int second)))
                {
                    return new int[] { first, second };
                }
                else
                {
                    command = "error";
                    return new int[] { 1, 1 };
                }
            }
            // Error checking for if its a command needing one parameter
            else if (CommandsOneParams.Contains(command) && parameters.Length == 1)
            {
                if (int.TryParse(parameters[0], out int first))
                {
                    return new int[] { first, 0 };
                }
                else
                {
                    command = "error";
                    return new int[] { 1, 1 };
                }
            }
            //Error checking for if its a command needing no parameters
            else if (CommandsNoParams.Contains(command))
            {
                return new int[] { 0, 0 };
            }
            //Error checking for if the command is already set to error flag.
            else if (command == "error")
            {
                return paramsAsInt;
            }
            //Returns unknown error
            else
            {
                command = "error";
                return new int[] { 0, 0 };
            }
        }

        /// <summary>This class is for when the command uses a string</summary>
        private int[] parseString(string cutMe)
        {
            // Parses/encodes the color command
            if (command == "color") 
            {
                switch (cutMe){
                    case "red":
                        return new int[] { 1, 0 };
                    case "black":
                        return new int[] { 2, 0 };
                    case "blue":
                        return new int[] { 3, 0 };
                }
                command = "error";
                return new int[] { 3, 2 };
            }

            //Parses/encodes the fill command
            if (command == "fill")
            {
                switch (cutMe)
                {
                    case "on":
                        return new int[] { 1, 0 };
                    case "off":
                        return new int[] { 2, 0 };
                }
                // Error, not recognized param
                command = "error";
                return new int[] { 3, 3 };
            }

            //Error, cutMe not set
            command = "error";
            return new int[]{ 3,1};
        }    
    }
}
