using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Text;
=======
>>>>>>> ricardo
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class GraphNode<T>
    {
<<<<<<< HEAD
        //naam van node (A/B/C... 1/2/3... whatever)
        T value;
        //coördinaten
        public double xD;
        public double yD;
        public double zD;
        //aanliggende nodes
        List<GraphNode<T>> neighbors;

        public GraphNode(T value, double x, double y, double z)
        {
            //Benodigd voor aanmaken
            xD = x;
            yD = y;
            zD = z;
            this.value = value;
            neighbors = new List<GraphNode<T>>();
        }

        //Deze volgende methoden spreken voor zich
        public T Value
        {
            get { return value; }

        }

        public IList<GraphNode<T>> Neighbors
        {
            get { return neighbors.AsReadOnly(); }
        }
        public bool AddNeighbor(GraphNode<T> neighbor)
        {
            if (neighbors.Contains(neighbor))
            {
                return false;
            }
            else
            {
                neighbors.Add(neighbor);
                return true;
            }
        }
        public bool RemoveNeighbor(GraphNode<T> neighbor)
        {
            return neighbors.Remove(neighbor);
        }
        public bool RemoveAllNeighbors()
        {
            for (int i = neighbors.Count - 1; i <= 0; i--)
            {

            }
            return true;
        }


=======
>>>>>>> ricardo
    }

    public class Graph<T>
    {
<<<<<<< HEAD
        List<GraphNode<T>> nodes = new List<GraphNode<T>>();
        public Graph()
        {

        }
        public int Count
        {
            get { return nodes.Count; }
        }
        public IList<GraphNode<T>> Nodes
        {
            get { return nodes.AsReadOnly(); }
        }
        public void Clear()
        {
            foreach (GraphNode<T> node in nodes)
            {
                node.RemoveAllNeighbors();
            }
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                nodes.RemoveAt(i);
            }
        }
        public bool AddNode(T value, double x, double y, double z)
        {
            if (Find(value) != null)
            {
                return false;
            }
            else
            {
                nodes.Add(new GraphNode<T>(value, x, y, z));
                return true;
            }

        }
        public bool AddEdge(T value1, T value2)
        {
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);
            if (node1 == null || node2 == null)
            {
                return false;
            }
            else if (node1.Neighbors.Contains(node2))
            {
                return false;
            }
            else
            {
                node1.AddNeighbor(node2);
                node2.AddNeighbor(node1);
                return true;
            }

        }
        public bool RemoveEdge(T value1, T value2)
        {
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);
            if (node1 == null || node2 == null)
            {
                return false;
            }
            else if (!node1.Neighbors.Contains(node2))
            {
                return false;
            }
            else
            {
                node1.RemoveNeighbor(node2);
                node2.RemoveNeighbor(node1);
                return true;
            }

        }
        public GraphNode<T> Find(T value)
        {
            foreach (GraphNode<T> node in nodes)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }
            return null;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                builder.Append(nodes[i].ToString());
                if (i < Count - 1)
                {
                    builder.Append(",");
                }

            }
            return base.ToString();
        }

    }
}
=======
    }
}
>>>>>>> ricardo
