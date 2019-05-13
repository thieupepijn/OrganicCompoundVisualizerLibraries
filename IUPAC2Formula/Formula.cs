﻿/*
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
		public List<Formula> SubFormulas{get; private set;}
		
		
		public Formula(Enums.ChainTypes chaintype, int locationOnParent, int length, string remaining)
		{
			ChainType = chaintype;
			LocationOnParent = locationOnParent;
			Length = length;
			SubFormulas = GetSubFormulas(remaining);
		}
		
			
		public Formula(int location, string subchainname)
		{
			ChainType = Enums.ChainTypes.Straight;
			LocationOnParent = location;
			Length = UtilChainLengths.FindSubChainLength(subchainname);
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
				List<string> lines = line.Split("-".ToCharArray()).ToList();
				
				for(int counter=0; counter<lines.Count;counter++)
				{
					line = lines[counter];
					if (line.EndsWith("yl", StringComparison.OrdinalIgnoreCase))
					{
						string locationsString = lines[counter-1];
						List<string> locations = locationsString.Split(",".ToCharArray()).ToList();
						foreach(string location in locations)
						{
							Formula formula = new Formula(Convert.ToInt16(location), line);
							formulas.Add(formula);
						}
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
			builder.Append("(");
			builder.Append(string.Join("-", SubFormulas));
			builder.Append(")");
			return builder.ToString();
		}
		
	}
}
