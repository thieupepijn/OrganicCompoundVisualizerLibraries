/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/4/2019
 * Time: 12:36 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace IUPAC2Formula
{
	/// <summary>
	/// Description of GreekNumberChainLength.
	/// </summary>
	public class GreekNumberChainLength
	{
		public int Number {get; private set;}
		public string Prefix {get; private set;}
		
		public GreekNumberChainLength(int number)
		{
			Number = number;
			Prefix = Number2Prefix(Number);
			
		}
		
	   private string Number2Prefix(int number)
        {
            switch (number)
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
                default: return "unknown";
            }
        }	
		
	}
}
