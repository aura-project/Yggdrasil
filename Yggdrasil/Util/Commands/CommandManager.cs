﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Yggdrasil.Util.Commands
{
	/// <summary>
	/// Generalized command manager
	/// </summary>
	/// <typeparam name="TCommand"></typeparam>
	/// <typeparam name="TFunc"></typeparam>
	public abstract class CommandManager<TCommand, TFunc>
		where TCommand : Command<TFunc>
		where TFunc : class
	{
		protected Dictionary<string, TCommand> _commands;

		protected CommandManager()
		{
			_commands = new Dictionary<string, TCommand>();
		}

		/// <summary>
		/// Adds command to list of command handlers.
		/// </summary>
		/// <param name="command"></param>
		protected void Add(TCommand command)
		{
			_commands[command.Name] = command;
		}

		/// <summary>
		/// Returns arguments parsed from line.
		/// </summary>
		/// <remarks>
		/// Matches words and multiple words in quotation.
		/// </remarks>
		/// <example>
		/// arg0 arg1 arg2 -- 3 args: "arg0", "arg1", and "arg2"
		/// arg0 arg1 "arg2 arg3" -- 3 args: "arg0", "arg1", and "arg2 arg3"
		/// </example>
		protected IList<string> ParseLine(string line)
		{
			var args = new List<string>();
			var quote = false;
			for (int i = 0, n = 0; i <= line.Length; ++i)
			{
				if ((i == line.Length || line[i] == ' ') && !quote)
				{
					if (i - n > 0)
						args.Add(line.Substring(n, i - n).Trim(' ', '"'));

					n = i + 1;
					continue;
				}

				if (line[i] == '"')
					quote = !quote;
			}

			return args;
		}

		/// <summary>
		/// Returns command or null, if the command doesn't exist.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public TCommand GetCommand(string name)
		{
			TCommand command;
			_commands.TryGetValue(name, out command);
			return command;
		}
	}
}