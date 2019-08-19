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
		
				
	
		private string GetName(int length)
		{
			return GetPrefix(length) + "ane";
		}
		
		
		private string GetPrefix(int length)
		{
			return new ChainLengthPrefix(length).Prefix;
		}
		
		
		
		
	}
}
