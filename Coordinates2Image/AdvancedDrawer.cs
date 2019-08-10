/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 8/10/2019
 * Time: 6:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Graph2Coordinates;
using System.Collections.Generic;

namespace Coordinates2Image
{
	/// <summary>
	/// Description of AdvancedDrawer.
	/// </summary>
	public class AdvancedDrawer
	{
		
		private IPainter _painter;
		
		public AdvancedDrawer(List<Node> nodes, List<Vertice> vertices, IPainter painter)			
		{
			_painter = painter;	
		}
		
		public void Draw()
		{
			_painter.DrawBackGround();
			_painter.DrawString();
		}
	}
}
