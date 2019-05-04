/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/5/2019
 * Time: 12:07 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph2Coordinates
{
	/// <summary>
	/// Description of Circle.
	/// </summary>
	public class Circle
	{
		public Location Center;
		public int Radius;
		public List<Location> Circumference;
		
		public Circle(Location center, int radius)
		{
			Center = center;
			Radius = radius;
			Circumference = GetCircumference(Center, Radius);
		}
		
		public Circle(Location center, int verticeLength, int numberOfChildren)
		{
			Center = center;
			
			int cirumferenceLength = numberOfChildren * verticeLength;
			Radius = (int)(cirumferenceLength / (2 * Math.PI));
			Circumference = GetCircumference(Center, Radius);
		}
		
		public Location RandomPointFromCircumference(Random random)
		{
			return Circumference[random.Next(Circumference.Count)];
		}
		
		public Location LocationMostFarAway(List<Node> nodes)
		{
			Circumference = Circumference.OrderByDescending(l => l.DistanceClosestNode(nodes)).ThenByDescending(l => l.SummedDistance(nodes)).ToList<Location>();
			return Circumference[0];
		}
		
		public Location CircumenferenceAtAngle(int angle)
		{
			return CircumenferenceAtAngle(angle, Center, Radius);
		}
		
		private Location CircumenferenceAtAngle(int angle, Location center, int radius)
		{
			double angleRadius = Degrees2Radials(angle);
			double x = center.X + (radius * Math.Cos(angleRadius));
			double y = center.Y + (radius * Math.Sin(angleRadius));
			return new Location((int)x, (int)y);
		}
		
		private List<Location> GetCircumference(Location center, int radius)
		{
			List<Location> locations = new List<Location>();
			for (int angle=0;angle<360;angle+=10)
			{
				Location location = CircumenferenceAtAngle(angle, center, radius);
				locations.Add(location);
			}
			return locations;
		}
		
		private double Degrees2Radials(double degrees)
		{
			return degrees * (Math.PI/ 180);
		}
		
	}
}
