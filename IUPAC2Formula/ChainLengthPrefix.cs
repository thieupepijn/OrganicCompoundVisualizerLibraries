/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 8/19/2019
 * Time: 11:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace IUPAC2Formula
{
	
	
	public class ChainLengthPrefix
	{
		public int Length {get; private set;}
		public string Prefix { get; private set;}
		
		public ChainLengthPrefix(int length)
		{
			Length = length;
			Prefix = GetPrefix(length);
		}
		
		//information taken from https://en.intl.chemicalaid.com/references/prefixes.php
		//and: Systematic Nomenclature of Organic Chemistry
		//by D. Hellwinkel
		private string GetPrefix(int length)
		{
			switch(length)
			{
					case 1: return "meth";
					case 2: return "eth";
					case 3: return "prop";
					case 4: return "but";
					case 5: return "pent";
					case 6: return "hex";
					case 7: return "hept";
					case 8: return "oct";
					case 9: return "non";
					case 10: return "dec";
					case 11: return "undec";
					case 12: return "dodec";
					case 13: return "tridec";
					case 14: return "tetradec";
					case 15: return "pentadec";
					case 16: return "hexadec";
					case 17: return "heptadec";
					case 18: return "octadec";
					case 19: return "nonadec";
					case 20: return "icos";
					case 21: return "henicos";
					case 22: return "doicos";
					case 23: return "triicos";
					case 24: return "tetraicos";
					case 25: return "pentaicos";
					default: return string.Empty;
			}
			
		}
	}
}
