/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/9/2019
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Graph2Coordinates;


namespace Coordinates2Image
{
	
	public class Drawer
	{
		
		public Drawer(List<Node> nodes, List<Vertice> vertices, int imageWidth, int imageHeight, string imageFilePath)
		{
			Bitmap bitmap = new Bitmap(imageWidth, imageHeight);
			
			using (Graphics graafix = Graphics.FromImage(bitmap))
			{
				DrawNodes(nodes, graafix);
				DrawVertices(vertices, graafix);
				bitmap.Save(imageFilePath, ImageFormat.Bmp);
			}
			
		}
		
		
		private void DrawNodes(List<Node> nodes, Graphics graafix)
		{
			foreach(Node node in nodes)
			{
				graafix.FillEllipse(Brushes.Red, node.Location.X, node.Location.Y, 25, 25);
			}
		}
		
		
		private void DrawVertices(List<Vertice> vertices, Graphics graafix)
		{
			foreach(Vertice vertice in vertices)
			{
				int x1 = Average(vertice.Node1.Location.X, vertice.Node1.Location.X + 25);
				int y1 = Average(vertice.Node1.Location.Y, vertice.Node1.Location.Y + 25);
				
				int x2 = Average(vertice.Node2.Location.X, vertice.Node2.Location.X + 25);
				int y2 = Average(vertice.Node2.Location.Y, vertice.Node2.Location.Y + 25);
						
				graafix.DrawLine(new Pen(Color.Red, 2), x1, y1, x2, y2);
			}
		}
		
		private int Average(int start, int end)
		{
			return start +  (Math.Abs(start - end) / 2);
		}
		
	
		
		
		
	}
}