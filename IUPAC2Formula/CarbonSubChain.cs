﻿/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 6/19/2019
 * Time: 9:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace IUPAC2Formula
{
	/// <summary>
	/// Description of CarbonSubChain.
	/// </summary>
	public class CarbonSubChain
	{
		public int Length {get; set;}
		public string Name {get; set;}
		public string Prefix {get; set;}
		
		public CarbonSubChain(int length)
		{
			Length = length;
			Name = GetName(Length);	
			Prefix = Name.Replace("yl", String.Empty);
		}
		
		public static List<String> GetAllNames()
		{
			List<string> names = new List<string>();
			for (int counter = 1; counter < 7; counter++)
			{
				string name = new CarbonSubChain(counter).Name;
				names.Add(name);	
			}
			return names;
		}
		
		private string GetName(int length)
		{
			if (length == 1)
			{
				return "methyl";
			}
			else if (length == 2)
			{
				return "ethyl";
			}
			else if (length == 3)
			{
				return "propyl";
			}
			else if (length == 4)
			{
				return "butyl";
			}
			else if (length == 5)
			{
				return "pentyl";
			}
			else if (length == 6)
			{
				return "hexyl";
			}
			else if (length == 7)
			{
				return "heptyl";
			}
			else if (length == 8)
			{
				return "octyl";
			}
			else if (length == 9)
			{
				return "nonyl";
			}
			else if (length == 10)
			{
				return "decyl";
			}
			else
			{
				return string.Empty;
			}
		}
		
		
		
		
		
	}
}
