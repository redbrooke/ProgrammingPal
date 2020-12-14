using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPal.logic
{
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
		public List<String> getCompiledCode(String[] lines)
		{
			while (programCounter < lines.Length) 
			{
				line = lines[programCounter].ToLower();
				split = line.Split(' ');
				foreach (String piece in lines) 
				{ 
					
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
						variableList.Add((variable)logicCreator.createLogic("variable", command, split[2]));
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

/* 
	//VARIABLES
	if var command
		found = checkVariable(parameter)
		if found >= 0
			report syntax_error variable already declared
		else
			variableNames[variableCounter] = parameter
			variableValues[variableCounter++] = 0
	

endwhile

method int checkVariables(name)
	for loop = 0 to variableCounter
*/

