/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/2/2019
 * Time: 9:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Formula2Graph
{
	public class Node
	{
		public int Number {get; private set;}
		public Node Parent {get; private set;}
			
		public Node(int number, Node parent)
		{
			Number = number;
			Parent = parent;
		}
		
		public override string ToString()
		{
			if (Parent != null)
			{
				return string.Format("{0},{1}", Number, Parent.Number);
			}
			else 
			{
				return string.Format("{0},", Number);
			}
		}
	}
	
}