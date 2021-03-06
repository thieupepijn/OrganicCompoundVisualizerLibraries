﻿/*
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
			
			int mainChainLength = CarbonMainChain.FindMainChainLength(mainChainDescription);
			
			string remaining;
			if (iupacName.Contains(Constants.EndBracket))
			{
				remaining = UtilStrings.RemoveEverythingAfter(iupacName, Constants.EndBracket);
			}
			else
			{
				remaining = UtilStrings.RemoveEverythingAfter(iupacName, Constants.SubChainEnd);
			}
			
			List<int> doubleBondLocations, tripleBondLocations;
			GetDoubleAndTripleBondLocations(iupacName, out doubleBondLocations, out tripleBondLocations);
			Formula = new Formula(chaintype, 0, mainChainLength, doubleBondLocations, tripleBondLocations, remaining);
		}
		
		
		public IUPACCompound(int locationOnParent, string name)
		{
			string chainDescription = FindSubChainPart(name);
			int chainLength = CarbonSubChain.FindSubChainLength(chainDescription);
			string remaining = UtilStrings.RemoveAtEnd(name, chainDescription);
			List<int> doubleBondLocations, tripleBondLocations;
			GetDoubleAndTripleBondLocations(name, out doubleBondLocations, out tripleBondLocations);
			Formula = new Formula(Enums.ChainTypes.Straight, locationOnParent, chainLength, doubleBondLocations, tripleBondLocations, remaining);
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
			List<string> subGroupNames = CarbonSubChain.GetAllNames();
			string subGroupName = UtilStrings.FindPattern(line, subGroupNames, UtilStrings.SearchDirection.Backward);
			return subGroupName;
		}
		
		private void GetDoubleAndTripleBondLocations(string line, out List<int> doubleBondLocations, out List<int> tripleBondLocations)
		{		
			
			if ((line.EndsWith("yne")) && (line.Contains("en-")))
			{
				doubleBondLocations = UtilStrings.FindSecondLastNumberGroup(line);
				tripleBondLocations = UtilStrings.FindLastNumberGroup(line);
			}
			else if (line.EndsWith("ene"))
			{
				doubleBondLocations = UtilStrings.FindLastNumberGroup(line);
				tripleBondLocations = new List<int>();
			}
			else if(line.EndsWith("yne"))
			{
				doubleBondLocations = new List<int>();
				tripleBondLocations = UtilStrings.FindLastNumberGroup(line);
			}
			else 
			{
				doubleBondLocations = new List<int>();
				tripleBondLocations = new List<int>();
			}	
			doubleBondLocations = doubleBondLocations.ConvertAll(l => l - 1);
			tripleBondLocations = tripleBondLocations.ConvertAll(l => l - 1);
		}
		
				
	}
}