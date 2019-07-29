/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/5/2019
 * Time: 12:30 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph2Coordinates
{
	public class UtilNodesAndVertices
	{
		//TODO MOST OF THIS SHOULD GO TO CLASSES NODES OR VERTICES
		public static void InitNodesFromLine(string line, List<Node> nodes)
		{
			string[] nodeElements = line.Split(";".ToCharArray());
			foreach(string nodeElement in nodeElements)
			{
				Node node = new Node(nodeElement, nodes);
				nodes.Add(node);
			}
		}
		
		public static void InitVerticesFromLines(List<string> lines, List<Node> nodes, List<Vertice> vertices)
		{
			foreach(string line in lines)
			{
				Vertice vertice = new Vertice(line, nodes, 1);
				vertices.Add(vertice);
			}
		}
		
		public static void InitializeNodeLocations(List<Node> nodes, List<Vertice> vertices)
		{
			for(int counter=0; counter<nodes.Count;counter++)
			{
				nodes[counter].Initlocation(nodes, vertices, counter);
			}
		}
		
		public static void RemoveUnConnectedNodes(List<Node> nodes, List<Vertice> vertices)
		{
			if(nodes.Count > 1)
			{
				nodes.RemoveAll(n => !n.IsConnected(vertices));
			}
		}
			
		public static void Reposition(List<Node> nodes, List<Vertice> vertices, int canvasWidth, int canvasHeight)
		{
			Dimensions nodeDimensions = GetDimensions(nodes);
			Dimensions canvasdimensions = new Dimensions(canvasWidth, canvasHeight);
			
			if (nodeDimensions.Mode != canvasdimensions.Mode)
			{
				FlipXY(nodes);
			}
			Location center = new Location(canvasWidth / 2, canvasHeight / 2);
			Center(nodes, center);		
		}

		private static Dimensions GetDimensions(List<Node> nodes)
		{
			List<Node> orderedNodesX = nodes.OrderBy(n => n.Location.X).ToList<Node>();
			int minX = orderedNodesX[0].Location.X;
			int maxX = orderedNodesX[orderedNodesX.Count-1].Location.X;
			
			List<Node> orderedNodesY = nodes.OrderBy(n => n.Location.Y).ToList<Node>();
			int minY = orderedNodesY[0].Location.Y;
			int maxY = orderedNodesY[orderedNodesY.Count-1].Location.Y;
			return new Dimensions(maxX - minX, maxY - minY);
		}
		
		private static void Center(List<Node> nodes, Location center)
		{
			Location average = UtilNodesAndVertices.AverageLocation(nodes);
			int diffX = center.X - average.X;
			int diffY = center.Y - average.Y;			
			nodes.ForEach(n => n.Move(diffX, diffY));			
		}
		
		private static void FlipXY(List<Node> nodes)
		{
			nodes.ForEach(n => n.Location.FlipXY());
		}
		
		private static Location AverageLocation(List<Node> nodes)
		{
			int sumX = 0;
			int sumY = 0;
			
			foreach(Node node in nodes)
			{
				sumX += node.Location.X;
				sumY += node.Location.Y;
			}
			
			int averageX = sumX / nodes.Count;
			int averageY = sumY / nodes.Count;
			
			return new Location(averageX, averageY);
		}
		
		
	}
}
