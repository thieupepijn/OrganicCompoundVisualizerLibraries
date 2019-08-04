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
				mainChainDescription = UtilStrings.RemoveAtStart(mainChainDescription, "cyclo");
			}
			else
			{
				chaintype = Enums.ChainTypes.Straight;
			}
			
			int mainChainLength = CarbonChain.FindMainChainLength(mainChainDescription);
			
			string remaining;
			if (iupacName.Contains(Constants.EndBracket))
			{
				remaining = UtilStrings.RemoveEverythingAfter(iupacName, Constants.EndBracket);
			}
			else
			{
				remaining = UtilStrings.RemoveEverythingAfter(iupacName, Constants.SubChainEnd);
			}
			
			List<int> tripleBondLocations = GetTripleBondLocations(iupacName);
			Formula = new Formula(chaintype, 0, mainChainLength, tripleBondLocations, remaining);			
		}
		
		
		public IUPACCompound(int locationOnParent, string name)
		{
			string chainDescription = FindSubChainPart(name);
			int chainLength = CarbonChain.FindSubChainLength(chainDescription);
			string remaining = UtilStrings.RemoveAtEnd(name, chainDescription);
			List<int> tripleBondLocations = GetTripleBondLocations(name);
			Formula = new Formula(Enums.ChainTypes.Straight, locationOnParent, chainLength, tripleBondLocations, remaining);
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
				else if (line.EndsWith(Constants.SubChainEnd, StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				else
				{
					if(line.Contains(Constants.EndBracket))
					{
						return UtilStrings.RemoveEverythingBefore(line, Constants.EndBracket);						
					}
					else
					{
						return UtilStrings.RemoveEverythingBefore(line, Constants.SubChainEnd);
					}
				}
			}
			return String.Empty;
		}
		
		
		private string FindSubChainPart(string line)
		{			
			List<string> subGroupNames = CarbonChain.GetAllSubChainNames();
			string subGroupName = UtilStrings.FindPattern(line, subGroupNames, UtilStrings.SearchDirection.Backward);
			return subGroupName;
		}
		
		
		private List<int> GetTripleBondLocations(string line)
		{
			if (line.EndsWith("yne"))
			{
				return UtilStrings.FindLastNumberGroup(line);
			}
			else 
			{
				return new List<int>();
			}
		}
		
		
	}
}