/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/5/2019
 * Time: 12:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph2Coordinates
{
	public class Node
	{

		#region public properties
		public int IdNumber {get; private set;}
		public Node ParentNode = null;
		public Location Location = null;
		#endregion public properties
		
		#region constructor and location-initialisation
		public Node(string line, List<Node> nodes)
		{
			string[] elements = line.Split(",".ToCharArray());
			IdNumber = Convert.ToInt16(elements[0]);
			
			if(!String.IsNullOrEmpty(elements[1]))
			{
				int parentNodeNumber = Convert.ToInt16(elements[1]);
				ParentNode = nodes.Find(node => node.IdNumber == parentNodeNumber);
			}
			else
			{
				ParentNode = null;
			}
		}
		
		
		public void InitLocation(List<Node> nodes, List<Vertice> vertices, int counter, int distanceBetweenPoints)
		{
			if (ParentNode == null)
			{
				Location = new Location(0, 0);
			}
			else if (ParentNode.IsConnected(vertices)) //normal parent-node
			{
				Circle circle = new Circle(ParentNode.Location, distanceBetweenPoints);
				List<Node> nodesBefore =   new List<Node>(nodes).GetRange(0, counter);
				nodesBefore.RemoveAll(node => node == ParentNode);
				Location = circle.LocationMostFarAway(nodesBefore);
			}
			else //circle-center parent-node
			{
				List<Node> childNodes = ParentNode.ChildNodes(nodes);
				int childNumber = childNodes.FindIndex(n => n == this);
				int angle = (360 / childNodes.Count) * childNumber;
				Circle circle = new Circle(ParentNode.Location, distanceBetweenPoints, childNodes.Count);
				Location = circle.CircumenferenceAtAngle(angle);
			}
		}
		#endregion constructor and location-initialisation
		
		#region connected functions
		public List<Node> ConnectedNodes(List<Vertice> vertices)
		{
			List<Node> nodes = new List<Node>();
			foreach(Vertice vertice in vertices)
			{
				if (this == vertice.Node1)
				{
					nodes.Add(vertice.Node2);
				}
				else if (this == vertice.Node2)
				{
					nodes.Add(vertice.Node1);
				}
			}
			return nodes;
		}
		
		
		public bool IsConnected(List<Vertice> vertices)
		{
			if (ConnectedNodes(vertices).Count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion connected functions
		
		#region description and tostring
		public string Description(List<Vertice> vertices)
		{
			List<Node> connectedNodes = ConnectedNodes(vertices);
			int numberOfHydrogens = 4 - connectedNodes.Count;
			
			if (numberOfHydrogens == 0)
			{
				return "C";
			}
			else if (numberOfHydrogens == 1)
			{
				return "CH";
			}
			else
			{
				return "CH" + numberOfHydrogens.ToString();
			}
		}
		
		public override string ToString()
		{
			return IdNumber.ToString();
		}
		#endregion description and tostring
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			else if (!(obj is Node))
			{
				return false;
			}
			else
			{
				Node otherNode = (Node)obj;
				if (otherNode.IdNumber == IdNumber)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public override int GetHashCode()
		{
			return IdNumber;
		}

		public static bool operator == (Node lhs, Node rhs)
		{
			if (Equals(lhs, rhs))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public static bool operator != (Node lhs, Node rhs)
		{
			return !(lhs == rhs);
		}

		#endregion
		
		#region other non-static functions
		public List<Node> ChildNodes(List<Node> nodes)
		{
			return nodes.FindAll(n => ((n.ParentNode != null) && (n.ParentNode == this)));
		}
		
		public void Move(int moveX, int moveY)
		{
			int newX = Location.X + moveX;
			int newY = Location.Y + moveY;
			Location = new Location(newX, newY);
		}
		#endregion other non-static functions
		
		#region static functions
		
		#region location functions
		
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
			Location average = AverageLocation(nodes);
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
		
		#endregion location functions
		
		#region init functions
		public static void InitNodesFromLine(string line, List<Node> nodes)
		{
			string[] nodeElements = line.Split(";".ToCharArray());
			foreach(string nodeElement in nodeElements)
			{
				Node node = new Node(nodeElement, nodes);
				nodes.Add(node);
			}
		}
		
		public static void InitNodeLocations(List<Node> nodes, List<Vertice> vertices, int distanceBetweenPoints)
		{
			for(int counter=0; counter<nodes.Count;counter++)
			{
				nodes[counter].InitLocation(nodes, vertices, counter, distanceBetweenPoints);
			}
		}
		
		#endregion init functions
		
		#region other static functions
		public static void RemoveUnConnectedNodes(List<Node> nodes, List<Vertice> vertices)
		{
			if(nodes.Count > 1)
			{
				nodes.RemoveAll(n => !n.IsConnected(vertices));
			}
		}
		#endregion other static functions
		
		#endregion static functions
		
		
		
		
		
	}
}
