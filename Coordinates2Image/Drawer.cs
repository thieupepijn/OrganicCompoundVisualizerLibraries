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
		
		private const string MEASURINGSTRING = "CCC";
		
		private List<Node> _nodes;
		private List<Vertice> _vertices;
		private int _imageWidth;
		private int _imageHeight;
		private Color _backgroundColor;	
		private Brush _letterColor;
		private Brush _ballsColor;
		private Brush _linesColor;
		
		
		public Drawer(List<Node> nodes, List<Vertice> vertices, int imageWidth, int imageHeight, Color backGroundColor, Brush letterColor, Brush ballsColor, Brush linesColor)
		{
			_nodes = nodes;
			_vertices = vertices;
			_imageWidth = imageWidth;
			_imageHeight = imageHeight;
			_backgroundColor = backGroundColor;
			_letterColor = letterColor;
			_ballsColor = ballsColor;
			_linesColor = linesColor;
		}
		
		
		public Drawer(List<Node> nodes, List<Vertice> vertices, int imageWidth, int imageHeight)
		{
			_nodes = nodes;
			_vertices = vertices;
			_imageWidth = imageWidth;
			_imageHeight = imageHeight;
			_letterColor = Brushes.Black;
			_backgroundColor = Color.White;
			_ballsColor = Brushes.White;
			_linesColor = Brushes.Black;
		}
		
		
		public Bitmap Draw2Bitmap()
		{
			Bitmap bitmap = new Bitmap(_imageWidth, _imageHeight);
			
			using (Graphics graafix = Graphics.FromImage(bitmap))
			{
				graafix.Clear(_backgroundColor);
				FontFamily fontFamily = new FontFamily("Arial");
				Font font = new Font(fontFamily, 15, FontStyle.Regular, GraphicsUnit.Pixel);
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
				GetDrawingLocationAndSize(node, graafix, MEASURINGSTRING, font, out x, out y, out width, out height);
				graafix.FillEllipse(_ballsColor, x, y, width, height);
				GetDrawingLocationAndSize(node, graafix, "C4", font, out x, out y, out width, out height);
				graafix.DrawString("C4", font, _letterColor, x, y);
			}
		}
		
		private void GetDrawingLocationAndSize(Node node, Graphics graafix, string measurestring, Font font, out int x, out int y, out int width, out int height)
		{
			SizeF size = graafix.MeasureString(measurestring, font);
			
			if (size.Height > size.Width)
			{
				x = (int)(node.Location.X - (0.5 * size.Height));
				y = (int)(node.Location.Y - (0.5 * size.Height));
				width = (int)size.Height;
				height = (int)size.Height;
			}
			else
			{
				x = (int)(node.Location.X - (0.5 * size.Width));
				y = (int)(node.Location.Y - (0.5 * size.Width));
				width = (int)size.Width;
				height = (int)size.Width;
			}
		}
		
		
		private void DrawVertices(List<Vertice> vertices, Graphics graafix, Font font)
		{
			foreach(Vertice vertice in vertices)
			{
				int x1, y1, width1, height1;
				GetDrawingLocationAndSize(vertice.Node1, graafix, MEASURINGSTRING, font, out x1, out y1, out width1, out height1);
				x1 += (int)(width1 / 2);
				y1 += (int)(height1 / 2);
				
				int x2, y2, width2, height2;
				GetDrawingLocationAndSize(vertice.Node2, graafix, MEASURINGSTRING, font, out x2, out y2, out width2, out height2);
				x2 += (int)(width2 / 2);
				y2 += (int)(height2 / 2);
				
				graafix.DrawLine(new Pen(_linesColor, 2), x1, y1, x2, y2);
			}
		}
		
		private int Average(int start, int end)
		{
			return start +  (Math.Abs(start - end) / 2);
		}
		
		
		
		
		
	}
}