/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 8/17/2019
 * Time: 11:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace IUPAC2Formula
{
	
	public class CarbonMainChain
	{
		public int Length {get; set;}
		public string Name {get; set;}
		public string Prefix{get; set;}
		
		public CarbonMainChain(int length)
		{
			Length = length;
			Name = GetName(Length);
			Prefix = GetPrefix(Length);
		}
		
		public static List<String> GetAllNames()
		{
			List<string> names = new List<string>();
			for (int counter = 1; counter < 26; counter++)
			{
				string name = new CarbonSubChain(counter).Name;
				names.Add(name);
			}
			return names.OrderByDescending(n => n.Length).ToList();
		}
		
		
		public static int FindMainChainLength(string line)
		{
			for (int counter=1;counter<26;counter++)
			{
				string countingWord =  new CarbonMainChain(counter).Prefix;
				if (line.StartsWith(countingWord, StringComparison.OrdinalIgnoreCase))
				{
					return counter;
				}
			}
			return 0;
		}
		
		
		//TODO THIS SHOULD BE IMPLEMENTED FURTHER
		private string GetName(int length)
		{
			switch(length)
			{
					case 1: return "methane";
					case 2: return "ethane";
					case 3: return "propane";
					case 4: return "butane";
					case 5: return "pentane";
					case 6: return "hexane";
					case 7: return "heptane";
					case 8: return "octane";
					case 9: return "nonane";
					case 10: return "decane";
					case 11: return "undecane";
					default: return string.Empty;
			}
		}
		
		
		//TODO THIS SHOULD BE IMPLEMENTED FURTHER
		private string GetPrefix(int length)
		{
			switch(length)
			{
					case 1: return "meth";
					case 2: return "eth";
					case 3: return "prop";
					case 4: return "but";
					case 5: return "pent";
					case 6: return "hex";
					case 7: return "hept";
					case 8: return "oct";
					case 9: return "non";
					case 10: return "dec";
					case 11: return "undec";
					default: return string.Empty;
			}
		}
		
		
		
		
	}
}
