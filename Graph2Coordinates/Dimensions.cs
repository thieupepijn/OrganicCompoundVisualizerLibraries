/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/5/2019
 * Time: 12:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Graph2Coordinates
{
	/// <summary>
	/// Description of Dimensions.
	/// </summary>
	
	public class Dimensions
	{
		public int Width {get; private set;}
		public int Height {get; private set;}
		public Enums.DimensionsMode Mode {get;private set;}
		
		public Dimensions(int width, int height)
		{
			Width = width;
			Height = height;
			
			if (Width > Height)
			{
				Mode = Enums.DimensionsMode.LandScape;
			}
			else
			{
				Mode = Enums.DimensionsMode.Portrait;
			}
		}
		
	}
}
