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
using System.Windows.Media.Imaging;
using System.IO;
using Graph2Coordinates;


namespace Coordinates2Image
{
	
	public class Drawer
	{
		
		private List<Node> _nodes;
		private List<Vertice> _vertices;
		private int _imageWidth;
		private int _imageHeight;
		
		public Drawer(List<Node> nodes, List<Vertice> vertices, int imageWidth, int imageHeight)
		{
			_nodes = nodes;
			_vertices = vertices;
			_imageWidth = imageWidth;
			_imageHeight = imageHeight;
		}
		
		
		public Bitmap Draw2Bitmap()
		{
			Bitmap bitmap = new Bitmap(_imageWidth, _imageHeight);
			using (Graphics graafix = Graphics.FromImage(bitmap))
			{
				DrawNodes(_nodes, graafix);
				DrawVertices(_vertices, graafix);
				return bitmap;
			}
		}
		
		public BitmapImage Draw2BitmapImage()
		{
			Bitmap bitmap = Draw2Bitmap();			
			using(MemoryStream memory = new MemoryStream())
			{
				bitmap.Save(memory, ImageFormat.Png);
				memory.Position = 0;
				BitmapImage bitmapImage = new BitmapImage();
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = memory;
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.EndInit();
				return bitmapImage;
			}		
		}
		
		
		public void Draw2File(string imageFilePath)
		{
			Bitmap bitmap = Draw2Bitmap();
			bitmap.Save(imageFilePath, ImageFormat.Bmp);
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