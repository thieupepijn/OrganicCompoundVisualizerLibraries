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

namespace Graph2Coordinates
{
	public class Node
	{


		public int Number {get; private set;}
		public Node ParentNode = null;
		public Location Location = null;
		
		public Node(int number, Node parentNode)
		{
			Number = number;
			ParentNode = parentNode;
		}
		
		public Node(string line, List<Node> nodes)
		{
			string[] elements = line.Split(",".ToCharArray());
			Number = Convert.ToInt16(elements[0]);
					
			if(!String.IsNullOrEmpty(elements[1]))
			{
				int parentNodeNumber = Convert.ToInt16(elements[1]);
				ParentNode = nodes.Find(node => node.Number == parentNodeNumber);
			}
			else
			{
			   ParentNode = null;
			}				
		}
		
		
		public void Initlocation(List<Node> nodes, List<Vertice> vertices, int counter)
		{
			if (ParentNode == null)
			{
				Location = new Location(0, 0);
			}
			else if (ParentNode.IsConnected(vertices)) //normal parent-node
			{
				Circle circle = new Circle(ParentNode.Location, Constants.DistanceBetweenPoints);
				List<Node> nodesBefore =   new List<Node>(nodes).GetRange(0, counter);
				nodesBefore.RemoveAll(node => node == ParentNode);
				Location = circle.LocationMostFarAway(nodesBefore);
			}	
			else //circle-center parent-node
			{
				List<Node> childNodes = ParentNode.ChildNodes(nodes);
				int childNumber = childNodes.FindIndex(n => n == this);
				int angle = (360 / childNodes.Count) * childNumber;				
				Circle circle = new Circle(ParentNode.Location, Constants.DistanceBetweenPoints, childNodes.Count);
				Location = circle.CircumenferenceAtAngle(angle);		
			}
		}
		
				
		public bool IsConnected(Node otherNode, List<Vertice> vertices)
		{
			foreach(Vertice vertice in vertices)
			{
				if ((this == vertice.Node1) && (otherNode == vertice.Node2))
				{
					return true;
				}
				else if((this == vertice.Node2) && (otherNode == vertice.Node1))
				{
					return true;
				}
			}
			return false;
		}
				
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
		
		
		public List<Node> ChildNodes(List<Node> nodes)
		{
			return nodes.FindAll(n => ((n.ParentNode != null) && (n.ParentNode == this)));
		}
		
		public static int Distance(Node node1, Node node2)
		{
			return Location.Distance(node1.Location, node2.Location);
		}
		
		
		public void Move(int moveX, int moveY)
		{
			int newX = Location.X + moveX;
			int newY = Location.Y + moveY;
			Location = new Location(newX, newY);
		}

		
		public override string ToString()
		{
			return Number.ToString();
		}
		
		
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
				if (otherNode.Number == Number)
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
			return Number;
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
		
		
		
	
	}
}
