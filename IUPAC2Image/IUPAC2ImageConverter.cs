/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/17/2019
 * Time: 11:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Coordinates2Image;
using Formula2Graph;
using IUPAC2Formula;
using System.Collections.Generic;
using System.Windows.Media.Imaging;


namespace IUPAC2Image
{

	public class IUPAC2ImageConverter
	{
		
		AdvancedDrawer _advancedDrawer = null;
		
		public IUPAC2ImageConverter(string iupacName, int imageWidth, int imageHeight, int verticeLength, IPainter painter)
		{
			List<Graph2Coordinates.Node> nodes;
			List<Graph2Coordinates.Vertice> vertices;
			
			GetNodesAndVertices(iupacName, imageWidth, imageHeight, verticeLength, out nodes, out vertices);
			_advancedDrawer = new AdvancedDrawer(nodes, vertices, painter);
		}
		
		
		private void GetNodesAndVertices(string iupacName, int imageWidth, int imageHeight, int verticeLength, out List<Graph2Coordinates.Node> nodes, out List<Graph2Coordinates.Vertice> vertices)
		{
			string formula = GetFormula(iupacName);
			Chain graph = GetGraph(formula);
			
			string nodesLine = GraphNodes2Line(graph);
			List<string> verticesLines = GraphVertices2Lines(graph);
			
			nodes = new List<Graph2Coordinates.Node>();
			Graph2Coordinates.Node.InitNodesFromLine(nodesLine, nodes);
			
			vertices = new List<Graph2Coordinates.Vertice>();
		    Graph2Coordinates.Vertice.InitVerticesFromLines(verticesLines, nodes, vertices);
			
			Graph2Coordinates.Node.InitNodeLocations(nodes, vertices, verticeLength);
			Graph2Coordinates.Node.RemoveUnConnectedNodes(nodes, vertices);
			Graph2Coordinates.Node.Reposition(nodes, vertices, imageWidth, imageHeight);
		}

		public void DrawOnCanvas()
		{
			_advancedDrawer.Draw();
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