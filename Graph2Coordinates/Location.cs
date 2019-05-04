/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/5/2019
 * Time: 12:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph2Coordinates
{
	public class Location
	{

		public int X;
		public int Y;

		public Location(int x, int y)
		{
			X = x;
			Y = y;
		}
		
		public Location(Random random, int maxX, int maxY)
		{
			X = random.Next(maxX);
			Y = random.Next(maxY);
		}


		public void FlipXY()
		{
			int buffer = X;
			X = Y;
			Y = buffer;
		}
		
		
		public static int Distance(Location location1, Location location2)
		{
			int distanceX = Math.Abs(location1.X  - location2.X);
			int distanceY = Math.Abs(location1.Y - location2.Y);
		    int xSquared = distanceX * distanceX;
			int ySquared = distanceY * distanceY;
			return (int)Math.Sqrt(xSquared + ySquared);
		}

		
		public int DistanceClosestNode(List<Node> nodes)
		{
			if ((nodes == null || (nodes.Count < 1)))
			{
				return Int16.MaxValue;
			}
			else
			{
				nodes = nodes.OrderBy(n => Distance(this, n.Location)).ToList<Node>();
				return Distance(this, nodes[0].Location);
			}
		}
		
		public int SummedDistance(List<Node> nodes)
		{
			int sum = 0;
			foreach(Node node in nodes)
			{
				sum += Distance(this, node.Location);
			}
			return sum;
		}
		
	}
}
