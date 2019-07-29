/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/17/2019
 * Time: 11:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using IUPAC2Formula;
using Formula2Graph;
using Graph2Coordinates;
using Coordinates2Image;


namespace IUPAC2Image
{

	public class IUPAC2ImageConverter
	{
		
		Drawer _drawer;
		
		public IUPAC2ImageConverter(string iupacName, int imageWidth, int imageHeight)
		{	
			List<Graph2Coordinates.Node> nodes;
			List<Graph2Coordinates.Vertice> vertices;		
			GetNodesAndVertices(iupacName, imageWidth, imageHeight, out nodes, out vertices);	
			_drawer = new Drawer(nodes, vertices, imageWidth, imageHeight); 
		}
		
		
		public IUPAC2ImageConverter(string iupacName, int imageWidth, int imageHeight, Color backGroundColor, Brush letterColor, Brush ballsColor, Brush linesColor)
		{
			List<Graph2Coordinates.Node> nodes;
			List<Graph2Coordinates.Vertice> vertices;
			
			GetNodesAndVertices(iupacName, imageWidth, imageHeight, out nodes, out vertices);			
			_drawer = new Drawer(nodes, vertices, imageWidth, imageHeight, backGroundColor, letterColor, ballsColor, linesColor);	
		}
		
		private void GetNodesAndVertices(string iupacName, int imageWidth, int imageHeight, out List<Graph2Coordinates.Node> nodes, out List<Graph2Coordinates.Vertice> vertices)
		{
			string formula = GetFormula(iupacName);
			Chain graph = GetGraph(formula);
			
			string nodesLine = GraphNodes2Line(graph);
			List<string> verticesLines = GraphVertices2Lines(graph);
			
			nodes = new List<Graph2Coordinates.Node>();
			UtilNodesAndVertices.InitNodesFromLine(nodesLine, nodes);
			
			vertices = new List<Graph2Coordinates.Vertice>();
			UtilNodesAndVertices.InitVerticesFromLines(verticesLines, nodes, vertices);
			
			UtilNodesAndVertices.InitializeNodeLocations(nodes, vertices);
			UtilNodesAndVertices.RemoveUnConnectedNodes(nodes, vertices);
			UtilNodesAndVertices.Reposition(nodes, vertices, imageWidth, imageHeight);
		}
		
		
		
		
		public Bitmap DrawToBitmap()
		{
			return _drawer.Draw2Bitmap();	
		}
		
		public BitmapImage DrawToBitmapImage()
		{
			return _drawer.Draw2BitmapImage();
		}
		
		
		public void DrawToFile(string filepath)
		{
			_drawer.Draw2File(filepath);
		}
		
		
		private static string GetFormula(string line)
		{
			IUPACCompound compound = new IUPACCompound(line);
			return compound.ShowFormula();
		}
		
		private static Chain GetGraph(string formula)
		{
			return new Chain(formula, null);
		}
		
		private static string GraphNodes2Line(Chain graph)
		{
			return string.Join(";", graph.Nodes);
		}
		
		private static List<string> GraphVertices2Lines(Chain graph)
		{
			List<string> lines = new List<string>();
			graph.Vertices.ForEach(v => lines.Add(v.ToString()));
			return lines;
		}
		
		
		
		
	}
}