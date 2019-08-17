/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 8/3/2019
 * Time: 10:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using IUPAC2Formula;

namespace UnitTests
{
	[TestFixture]
	public class IUPAC2FormulaTests
	{
		
		[Test]
		public void RemovePrefixTest()
		{
			string line = "trimethyl";
			string lineWithoutPrefix = MultiplyingAffix.RemoveMultiplyingAffix(line);
			StringAssert.AreEqualIgnoringCase("methyl", lineWithoutPrefix);
		}
		
	}
}
