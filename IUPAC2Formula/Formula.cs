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

namespace IUPAC2Formula
{
	/// <summary>
	/// Description of Formula.
	/// </summary>
	public class Formula
	{
		public string TypeCode {get; private set;}
		public int LocationOnParent{get; private set;}
		public int Length{get; private set;}
		public List<Formula> SubFormulas{get; private set;}
		
		
		public Formula(string typecode, int locationOnParent, int length, string remaining)
		{
			TypeCode = typecode;
			LocationOnParent = locationOnParent;
			Length = length;	
			SubFormulas = GetSubFormulas(remaining);		
		}
				
		
		
		public Formula(string locations, string subchainname)
		{
			TypeCode = "S";
			string location = locations.Split(",".ToCharArray()).First();
			LocationOnParent = Convert.ToInt16(location);
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
						string previous = lines[counter-1];
						Formula formula = new Formula(previous, line);
						formulas.Add(formula);
					}					
				}				
				return formulas;
			}			
		}
		
		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(TypeCode);
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
