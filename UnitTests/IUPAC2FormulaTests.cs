/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 8/3/2019
 * Time: 10:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using NUnit.Framework;
using IUPAC2Formula;

namespace UnitTests
{
	[TestFixture]
	public class IUPAC2FormulaTests
	{
		
		[Test]
		public void GetAllNamesProperlySorted()
		{
			List<string> names = MultiplyingAffix.GetAllNames();
			Assert.AreEqual(9, names[0].Length);
			Assert.AreEqual(2, names[24].Length);
		}
		
		[Test]
		public void RemoveMultiplyingAffixTest()
		{
			string line = "trimethyl";
			string lineWithoutPrefix = MultiplyingAffix.RemoveMultiplyingAffixName(line);
			StringAssert.AreEqualIgnoringCase("methyl", lineWithoutPrefix);
		}
		
	}
}
