/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/3/2019
 * Time: 11:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace GeneralUtils
{
	
	public class UtilStrings
	{
		public static bool ContainsNumber(string line)
		{
			if ((line.Contains("1") || (line.Contains("2")) || (line.Contains("3")) || (line.Contains("4")) ||
			     (line.Contains("5")) || (line.Contains("6")) || (line.Contains("7")) || (line.Contains("8")) || (line.Contains("9"))))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static string RemoveEverythingBefore(string line, string before)
		{
			for (int counter=line.Length-1; counter >= 0; counter--)
			{
				string lineStart = line.Substring(0, counter);
				string lineEnd = line.Substring(counter);
				if (lineStart.EndsWith(before, StringComparison.OrdinalIgnoreCase))
				{
					return lineEnd;
				}
			}
			return line;
		}
		
		
		public static string RemoveEverythingAfter(string line, string after)
		{
			for (int counter=line.Length-1; counter >= 0; counter--)
			{
				string lineStart = line.Substring(0, counter);
				if (lineStart.EndsWith(after, StringComparison.OrdinalIgnoreCase))
				{
					return lineStart;
				}
			}
			return line;			
		}
	}
}