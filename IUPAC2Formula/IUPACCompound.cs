/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 4/30/2019
 * Time: 7:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GeneralUtils;

namespace IUPAC2Formula
{
	
	public class IUPACCompound
	{
	//	private string _iupacName{get; set;}
		public Formula Formula{get; private set;}
		
		private int _mainChainLength{get; set;}
		
		public IUPACCompound(string iupacName)
		{
			string mainChainDescription = FindMainChainPart(iupacName);
			int mainChainLength = FindMainChainLength(mainChainDescription);
			
			Formula = new Formula("S", 0, mainChainLength); //MakeFormula(mainChainLength);
			
			string yo = UtilStrings.RemoveEverythingAfter(iupacName, "yl");
		}
		
		public string ShowFormula()
		{
			return Formula.ToString();
		}
		
				
		private string FindMainChainPart(string inline)
		{
			List<string> lines = inline.Split("-".ToCharArray()).ToList();

			foreach(string line in lines)
			{
				if (UtilStrings.ContainsNumber(line))
				{
					continue;
				}
				else if (line.EndsWith("yl", StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				else
				{
					return UtilStrings.RemoveEverythingBefore(line, "yl");
				}
			}
			return String.Empty;
		}
		
		private int FindMainChainLength(string line)
		{
			for (int counter=1;counter<11;counter++)
			{
				GreekNumberChainLength greekNumber = new GreekNumberChainLength(counter);
				string countingWord = greekNumber.Prefix;
				if (line.StartsWith(countingWord, StringComparison.OrdinalIgnoreCase))
				{
					return counter;
				}
			}
			return 0;
		}
		
		
		
	}
}