/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/5/2019
 * Time: 12:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Graph2Coordinates
{
	    public class Vertice
    {

        public Node Node1;
        public Node Node2;
        public int ThickNess;

        public Vertice(Node node1, Node node2, int thickNess)
        {
            Node1 = node1;
            Node2 = node2;
            ThickNess = thickNess;
        }
        
        public Vertice(string line, List<Node> nodes, int thickNess)
        {
        	string[] elements = line.Split(",".ToCharArray());
        	int nodeNumber1 = Convert.ToInt16(elements[0]);
        	int nodeNumber2 = Convert.ToInt16(elements[1]);
        	Node1 = nodes.Find(node => node.IdNumber == nodeNumber1);
        	Node2 = nodes.Find(node => node.IdNumber == nodeNumber2);	
        	ThickNess = thickNess;
        }
        
              
		public override string ToString()
		{
			return string.Format("{0}, {1}", Node1.IdNumber, Node2.IdNumber);
		}
		
		public static void InitVerticesFromLines(List<string> lines, List<Node> nodes, List<Vertice> vertices)
		{
			foreach(string line in lines)
			{
				Vertice vertice = new Vertice(line, nodes, 1);
				vertices.Add(vertice);
			}
		}

    }
}
