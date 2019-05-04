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

        public Vertice(Node node1, Node node2)
        {
            Node1 = node1;
            Node2 = node2;
        }
        
        public Vertice(string line, List<Node> nodes)
        {
        	string[] elements = line.Split(",".ToCharArray());
        	int nodeNumber1 = Convert.ToInt16(elements[0]);
        	int nodeNumber2 = Convert.ToInt16(elements[1]);
        	Node1 = nodes.Find(node => node.Number == nodeNumber1);
        	Node2 = nodes.Find(node => node.Number == nodeNumber2);	
        }
        
        
          
//        public void Draw(Canvas canvas)
//        {
//        	Line line = new Line();
//        	line.Stroke = new SolidColorBrush(Colors.Red);
//        	line.StrokeThickness = 3;
//        	
//        	line.X1 = Node1.Location.X + 10;
//        	line.Y1 = Node1.Location.Y + 10;
//        	line.X2 = Node2.Location.X + 10;
//        	line.Y2 = Node2.Location.Y + 10;
//        	canvas.Children.Add(line); 	
//        }
        
		public override string ToString()
		{
			return string.Format("{0}, {1}", Node1.Number, Node2.Number);
		}

    }
}
