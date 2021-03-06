﻿using System.Text;

namespace Yggdrasil.Extensions
{
	/// <summary>
	/// Extensions for the StringBuilder type.
	/// </summary>
	public static class StringBuilderExtensions
	{
		/// <summary>
		/// Appends the string returned by processing a composite format
		/// string and the default line terminator to this instance. Each
		/// format item is replaced by the string representation of a
		/// corresponding argument in a parameter array.
		/// </summary>
		/// <param name="sb"></param>
		/// <param name="format"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static StringBuilder AppendLine(this StringBuilder sb, string format, params object[] args)
		{
			sb.AppendFormat(format, args);
			sb.AppendLine();

			return sb;
		}
	}
}
