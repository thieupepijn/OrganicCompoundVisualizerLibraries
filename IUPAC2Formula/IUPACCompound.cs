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
		private string _iupacName{get; set;}
		private string _formula{get; set;}
		
		private int _mainChainLength{get; set;}
		
		public IUPACCompound(string iupacName)
		{
			string mainChainDescription = FindMainChainPart(iupacName);
			int mainChainLength = FindMainChainLength(mainChainDescription);
			
			_formula = MakeFormula(mainChainLength);
			
			string yo = UtilStrings.RemoveEverythingAfter(iupacName, "yl");
		}
		
		public string ShowFormula()
		{
			return _formula;
		}
		
		public string MakeFormula(int mainchainLength)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("S,");
			builder.Append("0,");
			builder.Append(mainchainLength.ToString());
			builder.Append(",()");
			return builder.ToString();		
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
				string countingWord = Number2BasicName(counter);
				if (line.StartsWith(countingWord, StringComparison.OrdinalIgnoreCase))
				{
					return counter;
				}
			}
			return 0;
		}
		
		private string Number2BasicName(int number)
        {
            switch (number)
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
                default: return "unknown";
            }
        }	
		
	}
}