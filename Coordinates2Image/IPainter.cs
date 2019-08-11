/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 8/10/2019
 * Time: 6:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Coordinates2Image
{
	/// <summary>
	/// Description of IPainter.
	/// </summary>
	public interface IPainter
	{
		
		void DrawBackGround();
		
		void DrawString(string line, int x, int y);
					
		void DrawCircle(int centerX, int centerY, int radius);
		
		void DrawLine(int x1, int y1, int x2, int y2, int thickness);
		
		
	}
}
