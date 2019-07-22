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
		private Brush _drawingColor;
		private Color _backgroundColor;
		
		public Drawer(List<Node> nodes, List<Vertice> vertices, int imageWidth, int imageHeight, Brush drawingColor, Color backGroundColor)
		{
			_nodes = nodes;
			_vertices = vertices;
			_imageWidth = imageWidth;
			_imageHeight = imageHeight;
			_drawingColor = drawingColor;
			_backgroundColor = backGroundColor;
		}
		
		
		public Drawer(List<Node> nodes, List<Vertice> vertices, int imageWidth, int imageHeight)
		{
			_nodes = nodes;
			_vertices = vertices;
			_imageWidth = imageWidth;
			_imageHeight = imageHeight;
			_drawingColor = Brushes.Black;
			_backgroundColor = Color.White;
		}
		
		
		public Bitmap Draw2Bitmap()
		{
			Bitmap bitmap = new Bitmap(_imageWidth, _imageHeight);
			
			using (Graphics graafix = Graphics.FromImage(bitmap))
			{
				graafix.Clear(_backgroundColor);
				FontFamily fontFamily = new FontFamily("Arial");
				Font font = new Font(fontFamily, 25, FontStyle.Regular, GraphicsUnit.Pixel);
				DrawVertices(_vertices, graafix, font);
				DrawNodes(_nodes, graafix, font);
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
		
		
		private void DrawNodes(List<Node> nodes, Graphics graafix, Font font)
		{
			foreach(Node node in nodes)
			{
				int x, y, width, height;
				GetDrawingLocationAndSize(node, graafix, font, out x, out y, out width, out height);
				graafix.FillEllipse(Brushes.Pink, x, y, width, height);
				graafix.DrawString("C", font, _drawingColor, x, y);
			}
		}
		
		private void GetDrawingLocationAndSize(Node node, Graphics graafix, Font font, out int x, out int y, out int width, out int height)
		{
			SizeF size = graafix.MeasureString("C", font);
			x = (int)(node.Location.X - (0.5 * size.Width));
			y = (int)(node.Location.Y - (0.5 * size.Height));
			width = (int)size.Width;
			height = (int)size.Height;
		}
		
		
		private void DrawVertices(List<Vertice> vertices, Graphics graafix, Font font)
		{
			foreach(Vertice vertice in vertices)
			{
				int x1, y1, width1, height1;
				GetDrawingLocationAndSize(vertice.Node1, graafix, font, out x1, out y1, out width1, out height1);
				x1 += (int)(width1 / 2);
				y1 += (int)(height1 / 2);
				
				int x2, y2, width2, height2;
				GetDrawingLocationAndSize(vertice.Node2, graafix, font, out x2, out y2, out width2, out height2);
				x2 += (int)(width2 / 2);
				y2 += (int)(height2 / 2);
				
				graafix.DrawLine(new Pen(_drawingColor, 2), x1, y1, x2, y2);
			}
		}
		
		private int Average(int start, int end)
		{
			return start +  (Math.Abs(start - end) / 2);
		}
		
		
		
		
		
	}
}