using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal.logic
{
	/// <summary>
	/// This class is intended to compile the users input into a program that can be ran using part 1's code.
	/// </summary>
	class Compiler
	{
		private List<String> compiledCode = new List<String>();
		private int programCounter = 0;
		private int loopCounter = 0;
		private bool loopFlag = false;
		private int loopSize = 0;
		private int variablecounter = 0;
		private int methodCounter = 0;
		private bool methodFlag = false;
		private bool methodExecuting = false;
		private int saveProgramCounter = 0;
		private bool executeLinesFlag = true;
		private int iteraton = 0;
		private string line;
		private string[] split;
		private string command;
		private string parameter;
		private logicFactory logicCreator = new logicFactory();
		private List<function> functionList = new List<function>();
		private List<variable> variableList = new List<variable>();
		private List<ifStatement> ifList = new List<ifStatement>();

		/// <summary>
		/// This method is intended to generate compiled code. In practice it will take the code with logic (e.g ifs and loops) and convert it into regular commands, like in part 1.
		/// </summary>
		/// <param name="lines">Lines is an array of the user's input line by line. It contains logic (e.g ifs and loops) </param>
		/// <returns>This returns a compiled version of the code that can be ran like a regular program.</returns>
		public List<String> getCompiledCode(String[] lines)
		{
			while (programCounter < lines.Length) 
			{
				line = lines[programCounter].ToLower();
				split = line.Split(' ');
				for (int x = 0; x  < (split.Length); x++)
				{
					foreach (variable var in variableList)
					{
						if (split[x] == var.GetName())
						{
							line = line.Replace(split[x], var.GetValue());
							split[x] = var.GetValue();
						}
					}
				}
				

				try
				{
					command = split[0];
				}
				catch (Exception e)
				{
					command = null;
				}
				try
				{
					parameter = split[1];
				}
				catch (Exception e) 
				{
					parameter = null;
				}
				// check syntax

				if (methodFlag == false && executeLinesFlag == true) // Checks if the code is meant to be running or not
				{
					if (command == "def") // creates a function
					{
						//HANDLE METHOD
						functionList.Add((function)logicCreator.createDef("def", parameter, (programCounter).ToString()));
						methodFlag = true;
					}
					else if (command == "call")
					{
						methodCounter = 0;
						foreach (function element in functionList)
						{
							if (element.GetName() == parameter)
							{
								programCounter += 1;
								saveProgramCounter = programCounter;
								programCounter = element.GetPointer();
								methodExecuting = true;
							}
							methodCounter++;
						}
					}
					else if (methodExecuting == true && command == "enddef") // If a method is running, check for the end.
					{
						programCounter = saveProgramCounter;
						methodExecuting = false;

					}
					// END OF FUCNTION LOGIC
					else if (command == "var") //IF ITS A VARIABLE
					{
						// add stuf to check if variable exists
						variableList.Add(logicCreator.createVar("variable", split[1], split[3]));
					}

					// ADD STUFF TO CALL VARIABLES

					// LOOP LOGIC
					else if (command == "loop")
					{
						iteraton = int.Parse(parameter);
						loopFlag = true;
						loopCounter = 0;
						loopSize = 0;
					}
					else if (command == "endloop")
					{
						if (loopFlag == true)
						{
							loopFlag = false;
							loopCounter++;
							if (loopCounter < iteraton)
							{
								programCounter = programCounter - loopSize;
							}
						}
					}


					// IF STATEMENT LOGIC
					else if (command == "if")
					{
						string revPolish = split[2] + "," + split[3];
						ifStatement tempIf = (ifStatement)logicCreator.createIf("if", parameter, revPolish);
						bool temp = tempIf.checkStatement();
						if (!temp) // Checks if the if statement is false
						{
							executeLinesFlag = false;
						}

					}
					else // If its a normal command
					{
						if (!(command == "endif" || command == "enddef"))
						{
							compiledCode.Add(line);
						}					
					}
					if (loopFlag == true) 
					{
						loopSize++;
					}
				}
				else if (methodFlag == true && command == "enddef") // checks for the end of the method.
				{
					methodFlag = false;
				}
				else if (executeLinesFlag == false && command == "endif") 
				{
					executeLinesFlag = true;
				}

				programCounter++;
			}
			return compiledCode;
		}
	}
}
