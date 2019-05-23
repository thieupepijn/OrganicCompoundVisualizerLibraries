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
		
		
		public static string GetEverythingBetweenStartAndEnd(string start, string end, string line)
		{
			int startPosition = line.IndexOf(start);
			int endPosition = line.LastIndexOf(end);
			int difference = endPosition - startPosition;
			
			return line.Substring(startPosition+1, difference-1);
		}
		
		
		
		public static string ReplaceEverythingBetweenStartAndEnd(string start, string end, string line, string replaceline)
		{
			
			int startPosition = line.IndexOf(start);
			int endPosition = line.LastIndexOf(end);
			int difference = endPosition - startPosition;
			
			line = line.Remove(startPosition, difference+1);
			return line.Insert(startPosition, replaceline);
		}
		
		
		public static string ReplaceOnlyBetweenStartAndEnd(string start, string end, string line, string target, string substitute)
		{
			
			int startPosition = line.IndexOf(start);
			int endPosition = line.LastIndexOf(end);
			int difference = endPosition - startPosition;
			
			string substring = line.Substring(startPosition, difference);
			string substringReplaced = substring.Replace(target, substitute);
			
			return line.Replace(substring, substringReplaced);
		}
		
		
		public static string RemoveAtStart(string line, string away)
		{
			if (line.StartsWith(away))
			{
				return line.Remove(0, away.Length);
			}
			else
			{
				return line;
			}
		}
		
		
		public static string RemovePrefix(string line)
		{
			if (line.StartsWith("di", StringComparison.OrdinalIgnoreCase))
			{
				return RemoveAtStart(line, "di");
			}
			else if (line.StartsWith("tri", StringComparison.OrdinalIgnoreCase))
			{
				return RemoveAtStart(line, "tri");
			}
			else if (line.StartsWith("tetra", StringComparison.OrdinalIgnoreCase))
			{
				return RemoveAtStart(line, "tetra");
			}
			else if (line.StartsWith("penta", StringComparison.OrdinalIgnoreCase))
			{
				return RemoveAtStart(line, "penta");
			}
			else 
			{
				return line;
			}	
		}
		
		
	}
}