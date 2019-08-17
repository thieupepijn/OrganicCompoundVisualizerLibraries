/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 6/19/2019
 * Time: 9:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace IUPAC2Formula
{

	public class CarbonSubChain
	{
		public int Length {get; private set;}
		public string Name {get; private set;}
			
		public CarbonSubChain(int length)
		{
			Length = length;
			Name = GetName(Length);
		}
		
		public static List<String> GetAllNames()
		{
			List<string> names = new List<string>();
			for (int counter = 1; counter < Constants.MaxChainlength; counter++)
			{
				string name = new CarbonSubChain(counter).Name;
				names.Add(name);
			}
			return names.OrderByDescending(n => n.Length).ToList();
		}
		
		
		public static int FindSubChainLength(string line)
		{
			for (int counter=1;counter<11;counter++)
			{
				string subchainName = new CarbonSubChain(counter).Name;
				if (line.EndsWith(subchainName, StringComparison.OrdinalIgnoreCase))
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
					case 1: return "methyl";
					case 2: return "ethyl";
					case 3: return "propyl";
					case 4: return "butyl";
					case 5: return "pentyl";
					case 6: return "hexyl";
					case 7: return "heptyl";
					case 8: return "octyl";
					case 9: return "nonyl";
					case 10: return "decyl";
					default: return string.Empty;
			}
		}
		
					
	}
}
