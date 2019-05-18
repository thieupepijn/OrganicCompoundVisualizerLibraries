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
			Enums.ChainTypes chaintype;
			
			if (mainChainDescription.StartsWith("cyclo"))
			{
				chaintype = Enums.ChainTypes.Cyclo;
				mainChainDescription = mainChainDescription.Remove(0, 5); //start and ending of cyclo
			}
			else
			{
				chaintype = Enums.ChainTypes.Straight;
			}
			
			int mainChainLength = UtilChainLengths.FindMainChainLength(mainChainDescription);
			
			string remaining;
			if (iupacName.Contains(")"))
			{
				remaining = UtilStrings.RemoveEverythingAfter(iupacName, ")");
			}
			else
			{
				remaining = UtilStrings.RemoveEverythingAfter(iupacName, "yl");
			}
			
			Formula = new Formula(chaintype, 0, mainChainLength, remaining);
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
					if(line.Contains(")"))
					{
						return UtilStrings.RemoveEverythingBefore(line, ")");						
					}
					else
					{
						return UtilStrings.RemoveEverythingBefore(line, "yl");
					}
				}
			}
			return String.Empty;
		}
		
		
		
		
		
	}
}