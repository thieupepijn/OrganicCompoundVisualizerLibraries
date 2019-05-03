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
		
		public Formula(string typecode, int locationOnParent, int length, string remaining)
		{
			TypeCode = typecode;
			LocationOnParent = locationOnParent;
			Length = length;	

			Formula subFormula = new Formula(remaining);
		}
		
		public Formula(string inline)
		{
			if (!string.IsNullOrEmpty(inline))
			{
				List<string> lines = inline.Split("-".ToCharArray()).ToList();
				
				foreach(string line in lines)
				{
					if (line.EndsWith("yl", StringComparison.OrdinalIgnoreCase))
					{
						int lengte = UtilChainLengths.FindSubChainLength(line);
						
					}
					    
					
				}
				
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
			builder.Append("()");
			return builder.ToString();
		}
		
	}
}
