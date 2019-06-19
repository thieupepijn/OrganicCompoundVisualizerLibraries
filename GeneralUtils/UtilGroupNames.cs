/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 6/16/2019
 * Time: 10:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralUtils
{
	/// <summary>
	/// Description of UtilGroupNames.
	/// </summary>
	public class UtilGroupNames
	{
		
		public static string FindSubGroupOnEnd(string inline)
		{
			List<String> subLines = UtilStrings.FindAllEndings(inline);
			
			foreach(string subLine in subLines)
			{
				
				if (String.Equals(subLine, "methyl", StringComparison.OrdinalIgnoreCase))
				{
					return "methyl";
				}
				else if (String.Equals(subLine, "ethyl", StringComparison.OrdinalIgnoreCase))
				{
					return "ethyl";
				}
				else if (String.Equals(subLine, "propyl", StringComparison.OrdinalIgnoreCase))
				{
					return "propyl";
				}
				else if (String.Equals(subLine, "butyl", StringComparison.OrdinalIgnoreCase))
				{
					return "butyl";
				}
				else if (String.Equals(subLine, "pentyl", StringComparison.OrdinalIgnoreCase))
				{
					return "pentyl";
				}
				else if (String.Equals(subLine, "hexyl", StringComparison.OrdinalIgnoreCase))
				{
					return "hexyl";
				}
			}
			return String.Empty;
		}
		
		
	}
}
