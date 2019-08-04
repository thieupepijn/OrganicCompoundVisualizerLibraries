/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/2/2019
 * Time: 9:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Formula2Graph
{
	/// <summary>
	/// Description of Vertice.
	/// </summary>
	public class Vertice
	{
		public Node Node1 {get; private set;}
		public Node Node2 {get; private set;}
		public int ThickNess {get; set;}
		public Vertice(Node node1, Node node2)
		{
			Node1 = node1;
			Node2 = node2;
			ThickNess = 1;
		}
		
		public override string ToString()
		{
			return string.Format("{0},{1},{2}", Node1.Number, Node2.Number, ThickNess);
		}
	}
}
