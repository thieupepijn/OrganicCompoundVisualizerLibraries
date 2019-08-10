/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/2/2019
 * Time: 9:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula2Graph
{
	/// <summary>
	/// Description of Chain.
	/// </summary>
	public class Chain
	{
		public Chain ParentChain{get; private set;}
		public Enums.ChainTypes ChainType{get; private set;}
		public List<Node> Nodes {get; private set;}
		public List<Vertice> Vertices{get; private set;}
		
		
		public Chain(string line, Chain parentChain)
		{
			ParentChain = parentChain;
			string[] elements = line.Split(",".ToCharArray());
			string chainTypeCode = elements[0];
			ChainType = ChainTypeCode2ChainType(chainTypeCode);
			int position = Convert.ToInt16(elements[1]);
			if ((parentChain != null) && (parentChain.ChainType == Enums.ChainTypes.Circular))
			{
				position++;
			}
			
			int length = Convert.ToInt16(elements[2]);
			
			Node parentNode;
			int startNumber;
			if (ParentChain == null)
			{
				startNumber = 0;
				parentNode = null;
			}
			else
			{
				startNumber = GetTotalNodes(ParentChain);
				parentNode =  parentChain.Nodes[position-1];
			}
			
			if (ChainType == Enums.ChainTypes.Straight)
			{
				Nodes = MakeStraightNodes(length, parentNode, startNumber);
				Vertices = MakeStraighVertices(Nodes, parentNode);
			}
			else //if(ChainType == Enums.ChainTypes.Circular)
			{
				Nodes = MakeCircularNodes(length, parentNode, startNumber);
				Vertices = MakeCircularVertices(Nodes);
			}
			
			
			//apply triplebond-locations
			string doubleBondLocationsLine = elements[3];
			ApplyMultipleBondLocations2Vertices(doubleBondLocationsLine, Vertices, 2);
			
			//apply triplebond-locations
			string tripleBondLocationsLine = elements[4];
			ApplyMultipleBondLocations2Vertices(tripleBondLocationsLine, Vertices, 3);
			
			
			string remainder = GetRemainder(line);
			if (String.IsNullOrEmpty(remainder))
			{
				//do nothing
			}
			else
			{
				List<string> remainderelements = remainder.Split("-".ToCharArray()).ToList();
				foreach(string remainderelement in remainderelements)
				{
					Chain subchain = new Chain(remainderelement, this);
					Nodes.AddRange(subchain.Nodes);
					Vertices.AddRange(subchain.Vertices);
				}
			}
		}
		
		private void ApplyMultipleBondLocations2Vertices(string locationsLine, List<Vertice> vertices, int thickness)
		{
			List<int> locations = LocationsLine2Locations(locationsLine);
			ApplyMultipleBondLocations2Vertices(locations, vertices, thickness);
		}
		
		
		private void ApplyMultipleBondLocations2Vertices(List<int> locations, List<Vertice> vertices, int thickness)
		{
			foreach(int location in locations)
			{	
				Vertices[location].ThickNess = thickness;
			}			
		}
		
		private List<int> LocationsLine2Locations(string line)
		{
			if (line[0] != ';')
			{
				List<int> locations = new List<int>();
				List<string> elements = line.Split(";".ToCharArray()).ToList();
				foreach(string element in elements)
				{
					int location = Convert.ToInt16(element);
					locations.Add(location);
				}
				return locations;
			}
			else
			{
				return new List<int>();
			}
		}
		
		
		private Enums.ChainTypes ChainTypeCode2ChainType(string code)
		{
			if (String.Equals(code, "S", StringComparison.OrdinalIgnoreCase))
			{
				return Enums.ChainTypes.Straight;
			}
			else if(String.Equals(code, "C", StringComparison.OrdinalIgnoreCase))
			{
				return Enums.ChainTypes.Circular;
			}
			else  //shouldn't happen
			{
				return Enums.ChainTypes.Straight;
			}
		}
		
		
		private List<Node> MakeStraightNodes(int chainLength, Node parentNode, int startNumber)
		{
			List<Node> nodes = new List<Node>();
			Node oldNode = parentNode;
			
			for(int counter=startNumber;counter<startNumber + chainLength;counter++)
			{
				Node node = new Node(counter, oldNode);
				oldNode = node;
				nodes.Add(node);
			}
			return nodes;
		}
		
		
		private List<Node> MakeCircularNodes(int chainLength, Node parentNode, int startNumber)
		{
			List<Node> nodes = new List<Node>();
			if(parentNode == null)
			{
				parentNode = new Node(startNumber, null);
				nodes.Add(parentNode);
				startNumber++;
			}
			
			for(int counter=startNumber;counter<startNumber + chainLength;counter++)
			{
				Node node = new Node(counter, parentNode);
				nodes.Add(node);
			}
			return nodes;
		}
		
		private List<Vertice> MakeStraighVertices(List<Node> nodes, Node parentNode)
		{
			List<Vertice> vertices = new List<Vertice>();
			for(int counter=0;counter<nodes.Count - 1;counter++)
			{
				Node node1 = nodes[counter];
				Node node2 = nodes[counter+1];
				Vertice vertice = new Vertice(node1, node2);
				vertices.Add(vertice);
			}
			
			if (parentNode != null)
			{
				Node node1 = parentNode;
				Node node2 = nodes[0];
				Vertice vertice = new Vertice(node1, node2);
				vertices.Add(vertice);
			}
			return vertices;
		}
		
		
		private List<Vertice> MakeCircularVertices(List<Node> nodes)
		{
			List<Vertice> vertices = new List<Vertice>();
			for(int counter=1;counter<nodes.Count - 1;counter++)
			{
				Node node1 = nodes[counter];
				Node node2 = nodes[counter+1];
				Vertice vertice = new Vertice(node1, node2);
				vertices.Add(vertice);
			}
			Vertice closingVertice = new Vertice(nodes[1], nodes[nodes.Count - 1]);
			vertices.Add(closingVertice);
			return vertices;
		}

		
		private string GetRemainder(string line)
		{
			int braceletposition = line.IndexOf('(');
			int remainderlength = (line.Length - braceletposition) - 2;
			string remainder = line.Substring(braceletposition+1, remainderlength);
			return remainder;
		}
		
		private int GetTotalNodes(Chain parent)
		{
			int totalNodes = 0;
			if(parent != null)
			{
				totalNodes += parent.Nodes.Count;
				parent = parent.ParentChain;
				totalNodes += GetTotalNodes(parent);
			}
			return totalNodes;
		}
		
		
	}
}
