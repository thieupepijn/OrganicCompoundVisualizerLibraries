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
			
			using (Graphics grafix = Graphics.FromImage(bitmap))
			{
				foreach(Node node in nodes)
				{
					grafix.DrawEllipse(new Pen(Color.Red, 5), node.Location.X, node.Location.Y, 50, 50);
					
					bitmap.Save(imageFilePath, ImageFormat.Bmp);
				}
			}
			
		}
		
		
		
	}
}