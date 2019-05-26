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
		
	}
}