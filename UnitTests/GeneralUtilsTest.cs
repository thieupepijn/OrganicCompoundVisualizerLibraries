/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/26/2019
 * Time: 10:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using NUnit.Framework;
using GeneralUtils;
using IUPAC2Formula;

namespace UnitTests
{
	[TestFixture]
	public class GeneralUtilTest
	{
		
		[Test]
		public void ReplaceBetweenBracketsTest()
		{
			
			string resultaat = UtilStrings.ReplaceBetweenBrackets("12-34(56-8-9)3456-4(555-7)", "-", "#");
			StringAssert.AreEqualIgnoringCase("12-34(56#8#9)3456-4(555#7)", resultaat);
		}
		
		
		[Test]
		public void SplitOnlyOutsideBracketsTest()
		{
			string line = "12-34(56-8-9)3456-4(555-7)";
			List<string> lines = UtilStrings.SplitOnlyOutsideBrackets(line, "-", "#");
			Assert.AreEqual(3, lines.Count, string.Empty);
		}
		
		
		[Test]
		public void RemoveAtEndTest()
		{
			string line = "1-methylpentyl";
			string away = "pentyl";
			
			string stripped = UtilStrings.RemoveAtEnd(line, away);
			StringAssert.AreEqualIgnoringCase("1-methyl", stripped);			
		}
		
		[Test]
		public void FindAllEndingSubstringsTest()
		{
			
			string line = "methylpentyl";
			List<string> subStrings = UtilStrings.FindAllEndings(line);
			Assert.AreEqual(11, subStrings.Count);		
		}

		[Test]
		public void FindSubGroupTest()
		{
			List<string> subGroups = CarbonSubChain.GetAllNames();
			string line = "1-methylpentyl";
			string subgroup = UtilStrings.FindPattern(line, subGroups);
			StringAssert.AreEqualIgnoringCase("pentyl", subgroup);
		}
		
		
		


		
	}
}