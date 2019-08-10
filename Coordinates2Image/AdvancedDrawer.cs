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
		private List<Node> _nodes;
		private List<Vertice> _vertices;
		private IPainter _painter;
		
		public AdvancedDrawer(List<Node> nodes, List<Vertice> vertices, IPainter painter)
		{
			_nodes = nodes;
			_vertices = vertices;
			_painter = painter;
		}
		
		public void Draw()
		{
			_painter.DrawBackGround();
			
			foreach(Vertice vertice in _vertices)
			{
				_painter.DrawLine(vertice.Node1.Location.X, vertice.Node1.Location.Y, vertice.Node2.Location.X, vertice.Node2.Location.Y);
			}
			
			foreach(Node node in _nodes)
			{		
				_painter.DrawCircle(node.Location.X, node.Location.Y, 50);
				_painter.DrawString(node.Description(_vertices), node.Location.X, node.Location.Y);
			}	
		}
		
		
	}
}
