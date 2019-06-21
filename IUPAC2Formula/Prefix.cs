﻿/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 6/21/2019
 * Time: 11:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using GeneralUtils;

namespace IUPAC2Formula
{
	/// <summary>
	/// Description of Prefix.
	/// </summary>
	public class Prefix
	{
		public int PrefixNumber {get; set;}
		public string PrefixWord {get; set;}
		
		public Prefix(int number)
		{
			PrefixNumber = number;
			PrefixWord = GetPrefixWord(PrefixNumber);
		}
		
		public static List<string> GetAllPrefixWords()
		{
			List<string> prefixWords = new List<string>();
			for (int counter = 1; counter < 6; counter++)
			{
				string prefixWord = new Prefix(counter).PrefixWord;
				prefixWords.Add(prefixWord);
			}
			return prefixWords;
		}
		
		public static string RemovePrefix(string line)
		{
			List<string> prefixWords = GetAllPrefixWords();
			string prefixword = UtilStrings.FindPattern(line, prefixWords, UtilStrings.SearchDirection.Forward);
			if (!String.IsNullOrEmpty(prefixword))
			{
				return UtilStrings.RemoveAtStart(line, prefixword);
			}
			else
			{
				return line;
			}
		}
		
		private string GetPrefixWord(int number)
		{
			if (number == 2)
			{
				return "di";
			}
			else if (number == 3)
			{
				return "tri";
			}
			else if (number == 4)
			{
				return "tetra";
			}
			else if (number == 5)
			{
				return "penta";
			}
			else if (number == 6)
			{
				return "hexa";
			}
			else
			{
				return string.Empty;
			}
		}
		
		
		
	}
}
