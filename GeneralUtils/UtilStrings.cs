﻿/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/3/2019
 * Time: 11:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

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
		
		
		public static string RemoveAtEnd(string line, string away)
		{
			if (line.EndsWith(away))
			{
				int length = line.Length - away.Length;
				
				return line.Substring(0, length);
			}
			else
			{
				return line;
			}
		}
		
		
		public static List<string> SplitOnlyOutsideBrackets(string line, string splitCharacter, string characterNotOccuringInLine)
		{
			string lineWithoutSplitCharactersBetweenBrackets = ReplaceBetweenBrackets(line, splitCharacter, characterNotOccuringInLine);
			List<string> lines = lineWithoutSplitCharactersBetweenBrackets.Split(splitCharacter.ToCharArray()).ToList();
			
			for(int counter=0; counter<lines.Count;counter++)
			{
				lines[counter] = lines[counter].Replace(characterNotOccuringInLine, splitCharacter);
			}
			return lines;
		}

		
		public static string ReplaceBetweenBrackets(string line, string target, string substitute)
		{
			StringBuilder builder = new StringBuilder();
			
			for (int counter = 0; counter < line.Length; counter++)
			{
				char currentChar = line[counter];
				if (currentChar == Convert.ToChar(target))
				{
					int openingBrackets = NumberOfOpeningBracketsBefore(line, counter);
					int closingBrackets = NumberOfClosingBracketsBefore(line, counter);
					
					if (openingBrackets > closingBrackets)
					{
						builder.Append(substitute);
					}
					else
					{
						builder.Append(target);
					}
				}
				else
				{
					builder.Append(currentChar);
				}
			}
			return builder.ToString();
		}
		
		
		private static int NumberOfOpeningBracketsBefore(string line, int indexnumber)
		{
			int number = 0;
			string before = line.Substring(0, indexnumber);
			List<char> characters = before.ToCharArray().ToList();
			foreach(char character in characters)
			{
				if (character == '(')
				{
					number++;
				}
			}
			return number;
		}
		
		
		private static int NumberOfClosingBracketsBefore(string line, int indexnumber)
		{
			int number = 0;
			string before = line.Substring(0, indexnumber);
			List<char> characters = before.ToCharArray().ToList();
			foreach(char character in characters)
			{
				if (character == ')')
				{
					number++;
				}
			}
			return number;
		}
		
		public static List<string> FindAllStartings(string line)
		{
			List<string> subStrings = new List<string>();
			
			for(int counter=1;counter<line.Length;counter++)
			{
				string subLine = line.Substring(0, counter);
				subStrings.Add(subLine);
			}
			return subStrings;
		}
		
		public enum SearchDirection { Forward, Backward }
		
		public static List<string> FindAllEndings(string line)
		{
			List<string> subStrings = new List<string>();
			
			for(int counter=1;counter<line.Length;counter++)
			{
				int start = line.Length - counter;
				string subLine = line.Substring(start);
				subStrings.Add(subLine);
			}
			return subStrings;
		}
		
		
		public static string FindPattern(string line, List<string> patterns, SearchDirection searchdirection)
		{
			List<String> contents;
			
			if (searchdirection == SearchDirection.Forward)
			{
				contents = FindAllStartings(line);
			}
			else //Searchdirection == backward
			{
				contents = FindAllEndings(line);
			}
			
			patterns = patterns.OrderByDescending(p => p.Length).ToList();
			foreach(string content in contents)
			{
				foreach(string pattern in patterns)
				{
					if (String.Equals(pattern, content, StringComparison.OrdinalIgnoreCase))
					{
						return pattern;
					}
				}
			}
			return null;
		}
		
		
		public static List<int> FindLastNumberGroup(string line)
		{
			List<string> subLines = line.Split("-".ToCharArray()).ToList();
			for (int counter=subLines.Count-1; counter >= 0; counter--)
			{
				string subLine = subLines[counter];
				if ((!String.IsNullOrEmpty(subLine)) && (subLine.Length > 0) && (Char.IsDigit(subLine[0])))
				{
					List<int> numbers = NumberCommaLine2Numbers(subLine);
					return numbers;
				}
			}
			return new List<int>();
		}
		
		public static List<int> FindSecondLastNumberGroup(string line)
		{
			List<string> subLines = line.Split("-".ToCharArray()).ToList();
			bool already = false;
			for (int counter=subLines.Count-1; counter >= 0; counter--)
			{
				string subLine = subLines[counter];
				if ((!String.IsNullOrEmpty(subLine)) && (subLine.Length > 0) && (Char.IsDigit(subLine[0])))
				{
					if (already)
					{
						List<int> numbers = NumberCommaLine2Numbers(subLine);
						return numbers;
					}
					else
					{
						already = true;
					}
				}
			}
			return new List<int>();
		}
		
		public static string RemoveAllLetters(string line)
		{
			List<Char> noLetters = line.Where(c => !Char.IsLetter(c)).ToList();
			string rv = string.Concat(noLetters);
			return rv;
		}
		
		public static List<int> NumberCommaLine2Numbers(string line)
		{
			List<string> elements = line.Split(",".ToCharArray()).ToList();
			List<int> numbers = elements.Select(e => int.Parse(e)).ToList();
			return numbers;
		}
		
		
		
		
	}
}