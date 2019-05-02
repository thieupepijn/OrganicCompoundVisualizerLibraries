/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/2/2019
 * Time: 9:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Formula2Graph
{
	/// <summary>
	/// Description of Util.
	/// </summary>
	public class Util
	{
		public static void AddNodesAndVertices(string line, List<Node> nodes, List<Vertice> vertices)
		{
			string[] elements = line.Split("-".ToCharArray());
			
			int position = Convert.ToInt16(elements[0]);
			int length = Convert.ToInt16(elements[1]);
			
			AddNodes(position, length, nodes);
			AddVertices(position, length, vertices, nodes);
		}
		
		private static void AddNodes(int subChainPosition, int subChainLength, List<Node> nodes)
		{
			int start = nodes.Count;
			int end = start+subChainLength;
			Node oldNode = nodes[subChainPosition];
			for(int counter=start;counter<end;counter++)
			{	
					Node node = new Node(counter, oldNode);
					oldNode = node;
					nodes.Add(node);		
			}
		}
					
		private static string MakeVertice(int number1, int number2)
		{
			string vertice = string.Format("{0},{1}", number1, number2);
			return vertice;
		}
		
		
		private static void AddVertices(int subChainPosition, int subChainLength, List<Vertice> vertices, List<Node> nodes)
		{
			int start = nodes.Count;
			int end = start+subChainLength;
			for(int counter=start;counter<nodes.Count-1;counter++)
			{
				if (counter==start)
				{
					Node node1 = nodes[counter];
					Node node2 = nodes[counter+1];	
					Vertice vertice = new Vertice(node1, node2);
					vertices.Add(vertice);
				}
			}
		}
		
	}
}
