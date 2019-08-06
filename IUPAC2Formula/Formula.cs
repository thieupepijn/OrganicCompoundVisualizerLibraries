/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/3/2019
 * Time: 11:41 PM
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
	/// <summary>
	/// Description of Formula.
	/// </summary>
	public class Formula
	{
		public Enums.ChainTypes ChainType {get; private set;}
		public int LocationOnParent{get; private set;}
		public int Length{get; private set;}
		public List<int> DoubleBondLocations {get; private set; }
		public List<int> TripleBondLocations {get; private set; }
		public List<Formula> SubFormulas{get; private set;}
		
		
		public Formula(Enums.ChainTypes chaintype, int locationOnParent, int length, List<int> doubleBondLocations, List<int> tripleBondLocations, string remaining)
		{
			ChainType = chaintype;
			LocationOnParent = locationOnParent;
			Length = length;			
			DoubleBondLocations = doubleBondLocations;
			TripleBondLocations = tripleBondLocations;				
			SubFormulas = GetSubFormulas(remaining);			
		}
		
		
		public Formula(int location, string subchainname)
		{
			ChainType = Enums.ChainTypes.Straight;
			LocationOnParent = location;
			Length =  CarbonChain.FindSubChainLength(subchainname);
			
			//no double and triplebondlocations in subchains
			DoubleBondLocations = new List<int>();
			TripleBondLocations = new List<int>();
			
			SubFormulas = new List<Formula>();
		}
		
		private List<Formula> GetSubFormulas(string line)
		{
			if(String.IsNullOrEmpty(line))
			{
				return new List<Formula>();
			}
			else
			{
				List <Formula> formulas = new List<Formula>();
				List<string> lines = UtilStrings.SplitOnlyOutsideBrackets(line, Constants.GroupSeperator, "#");
				
				for(int counter=0; counter<lines.Count;counter++)
				{
					line = lines[counter];
					if (line.EndsWith(Constants.SubChainEnd, StringComparison.OrdinalIgnoreCase))
					{
						string locationsString = lines[counter-1];	
						Group group = new Group(locationsString, line);
						formulas.AddRange(group.Formulas);
					}
					else if((line.StartsWith(Constants.StartBracket, StringComparison.OrdinalIgnoreCase)) && (line.EndsWith(Constants.EndBracket, StringComparison.OrdinalIgnoreCase)))
					{
						string locationsString = lines[counter-1];	
						Group group = new Group(locationsString, line);
						formulas.AddRange(group.Formulas);
					}
				}
				return formulas;
			}
		}
				
		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			
			if (ChainType == Enums.ChainTypes.Straight)
			{
				builder.Append("S");
			}
			else if (ChainType == Enums.ChainTypes.Cyclo)
			{
				builder.Append("C");
			}
			
			builder.Append(",");
			builder.Append(LocationOnParent);
			builder.Append(",");
			builder.Append(Length);
			builder.Append(",");			
			builder.Append(Locations2String(DoubleBondLocations));
			builder.Append(",");
			builder.Append(Locations2String(TripleBondLocations));
			builder.Append(",");
			builder.Append("(");
			builder.Append(string.Join("-", SubFormulas));
			builder.Append(")");
			return builder.ToString();
		}
		
		private string Locations2String(List<int> locations)
		{
			if ((locations == null) || (locations.Count < 1))
			{
				return ";";
			}
			else 
			{
				return string.Join(";", locations);
			}			
		}
		
		
		
	}
}
