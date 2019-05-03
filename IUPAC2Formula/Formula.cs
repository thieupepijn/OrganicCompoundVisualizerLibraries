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
		
		public Formula(string typecode, int locationOnParent, int length)
		{
			TypeCode = typecode;
			LocationOnParent = locationOnParent;
			Length = length;					
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
