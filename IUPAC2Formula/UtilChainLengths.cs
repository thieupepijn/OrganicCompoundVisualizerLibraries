/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/4/2019
 * Time: 1:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace IUPAC2Formula
{
	/// <summary>
	/// Description of UtilChainLengths.
	/// </summary>
	public static class UtilChainLengths
	{
		public static int FindMainChainLength(string line)
		{
			for (int counter=1;counter<11;counter++)
			{
				string countingWord = new CarbonChain(counter).Prefix;
				if (line.StartsWith(countingWord, StringComparison.OrdinalIgnoreCase))
				{
					return counter;
				}
			}
			return 0;
		}
		
		public static int FindSubChainLength(string line)
		{
			for (int counter=1;counter<11;counter++)
			{				
				string subchainName = new CarbonChain(counter).SubChainName;
				if (line.EndsWith(subchainName, StringComparison.OrdinalIgnoreCase))
				{
					return counter;
				}
			}
			return 0;
		}
		
		
	}
}
