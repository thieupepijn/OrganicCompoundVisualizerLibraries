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
		public int Length {get; private set;}
		public string Name {get; private set;}
		public string Prefix{get; private set;}
		
		public CarbonMainChain(int length)
		{
			Length = length;
			Name = GetName(Length);
			Prefix = GetPrefix(Length);
		}
		
		public static List<String> GetAllNames()
		{
			List<string> names = new List<string>();
			foreach(CarbonMainChain mainChain in GetAllMainChains())
			{
				names.Add(mainChain.Name);
			}			
			return names.OrderByDescending(n => n.Length).ToList();
		}
		
		
		public static List<CarbonMainChain> GetAllMainChains()
		{			
			List<CarbonMainChain> mainChains = new List<CarbonMainChain>();
			for (int counter = 1; counter <= Constants.MaxChainlength; counter++)
			{
				CarbonMainChain mainChain = new CarbonMainChain(counter);
				mainChains.Add(mainChain);
			}
			return mainChains.OrderByDescending(c => c.Name.Length).ToList();
		}
		
		
		public static int FindMainChainLength(string line)
		{	
			foreach(CarbonMainChain mainChain in GetAllMainChains())
			{
				string countingWord =  mainChain.Prefix;
				if ((!string.IsNullOrEmpty(countingWord)) && (line.StartsWith(countingWord, StringComparison.OrdinalIgnoreCase)))
				{
					return mainChain.Length;
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
