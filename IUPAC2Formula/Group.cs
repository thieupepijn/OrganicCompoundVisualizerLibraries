/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/23/2019
 * Time: 9:00 PM
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
	/// Description of Group.
	/// </summary>
	public class Group
	{
		
		public List<Formula> Formulas {get; private set;}
		
		public Group(string locationsline, string nameline)
		{
			
			if((nameline.StartsWith(Constants.StartBracket, StringComparison.OrdinalIgnoreCase)) && (nameline.EndsWith(Constants.EndBracket, StringComparison.OrdinalIgnoreCase)))
			{
				nameline = nameline.TrimStart("(".ToCharArray());
				nameline = nameline.TrimEnd(")".ToCharArray());
				
				int locationOnParent = Convert.ToInt16(locationsline);
				IUPACCompound compound = new IUPACCompound(locationOnParent, nameline);
				
				Formulas = new List<Formula>();
				Formulas.Add(compound.Formula);
			}
			else
			{
				
				List<string> locations = locationsline.Split(",".ToCharArray()).ToList();
				string chainName = GeneralUtils.UtilStrings.RemovePrefix(nameline);
				int chainLength = UtilChainLengths.FindSubChainLength(chainName);
				
				Formulas = new List<Formula>();
				foreach(string location in locations)
				{
					Formula formula = new Formula(Convert.ToInt16(location), chainName);
					Formulas.Add(formula);
				}
			}
		}
		

		
		
		
	}
}
