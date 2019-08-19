/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 6/21/2019
 * Time: 11:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using GeneralUtils;

namespace IUPAC2Formula
{
	
	public class MultiplyingAffix
	{
		public int Number {get; private set;}
		public string Name {get; private set;}
		
		public MultiplyingAffix(int number)
		{
			Number = number;
			Name = GetAffixName(Number);
		}
		
		public static List<string> GetAllNames()
		{
			List<string> names = new List<string>();
			foreach(MultiplyingAffix affix in GetAllMultiplyingAffixes())
			{
				string name = affix.Name;
				names.Add(name);
			}
			return names.OrderByDescending(n => n.Length).ToList();
		}
		
		public static List<MultiplyingAffix> GetAllMultiplyingAffixes()
		{
			List<MultiplyingAffix> affixes = new List<MultiplyingAffix>();
			for (int counter = 1; counter <= Constants.MaxNumberOfSubChains; counter++)
			{
				MultiplyingAffix affix = new MultiplyingAffix(counter);
				affixes.Add(affix);
			}
			return affixes;
		}
		
		
		public static string RemoveMultiplyingAffixName(string line)
		{
			List<string> affixNames = GetAllNames();
			string affixName = UtilStrings.FindPattern(line, affixNames, UtilStrings.SearchDirection.Forward);
			if (!String.IsNullOrEmpty(affixName))
			{
				return UtilStrings.RemoveAtStart(line, affixName);
			}
			else
			{
				return line;
			}
		}
		
		//information taken from https://en.wikipedia.org/wiki/IUPAC_numerical_multiplier
		//and: Systematic Nomenclature of Organic Chemistry
		//by D. Hellwinkel
		private string GetAffixName(int number)
		{
			switch (number)
			{
					case 1: return "mono";
					case 2: return "di";
					case 3: return "tri";
					case 4: return "tetra";
					case 5: return "penta";
					case 6: return "hexa";
					case 7: return "hepta";
					case 8: return "octa";
					case 9: return "nona";
					case 10: return "deca";
					case 11: return "undeca";
					case 12: return "dodeca";
					case 13 : return "trideca";
					case 14: return "tetradeca";
					case 15: return "pentadeca";
					case 16: return "hexadeca";
					case 17: return "heptadeca";
					case 18: return "octadeca";
					case 19: return "nonadeca";
					case 20: return "icosa";
					case 21: return "henicosa";
					case 22: return "docosa";
					case 23: return "tricosa";
					case 24: return "tetrasa";
					case 25: return "pentasa";
					default: return String.Empty;
			}			
		}
		
		
		
	}
}
