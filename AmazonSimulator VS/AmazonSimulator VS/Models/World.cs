using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;

namespace Models
{
    public class World : IObservable<Command>, IUpdatable
    {
        private List<C3Dmodel> worldObjects = new List<C3Dmodel>();
        private List<IObserver<Command>> observers = new List<IObserver<Command>>();
        public List<GraphNode> allthenodes = new List<GraphNode>();

        public World()
        {
            Robot r = CreateRobot(1, 0.5, 10);
            Robot r2 = CreateRobot(1, 0.5, 1);
            Vrachtwagen v = CreateVrachtwagen(30, 10, -3.5);
            Dock d = CreateDock(-2, 1.2, -5);
            Dock d2 = CreateDock(12, 1.2, -5);
            Stellage s = CreateStellage(10, 0.2, 10);
            Stellage s2 = CreateStellage(1, 0.2, 10);
            Stellage s3 = CreateStellage(10, 0.2, 5);
            Stellage s4 = CreateStellage(6, 0.2, 8);
            v.Rotate(0, -90 * (Math.PI / 180), 0);
            List<GraphNode> route1 = new List<GraphNode>();
            List<GraphNode> route2 = new List<GraphNode>();
            List<Vector> vectorlist1 = new List<Vector>();
            List<Vector> vectorlist2 = new List<Vector>();


            // S P A G H E T 
            GraphNode NodeA = CreateNode("A", 1, 0.5, 1);
            GraphNode NodeB = CreateNode("B", 1, 0.5, 2);
            GraphNode NodeC = CreateNode("C", 1, 0.5, 3);
            GraphNode NodeD = CreateNode("D", 1, 0.5, 4);
            GraphNode NodeE = CreateNode("E", 1, 0.5, 5);
            GraphNode NodeF = CreateNode("F", 2, 0.5, 1);
            GraphNode NodeG = CreateNode("G", 2, 0.5, 2);
            GraphNode NodeH = CreateNode("H", 2, 0.5, 3);
            GraphNode NodeI = CreateNode("I", 2, 0.5, 4);
            GraphNode NodeJ = CreateNode("J", 2, 0.5, 5);
            GraphNode NodeK = CreateNode("K", 3, 0.5, 1);
            GraphNode NodeL = CreateNode("L", 3, 0.5, 2);
            GraphNode NodeM = CreateNode("M", 3, 0.5, 3);
            GraphNode NodeN = CreateNode("N", 3, 0.5, 4);
            GraphNode NodeO = CreateNode("O", 3, 0.5, 5);
            GraphNode NodeP = CreateNode("P", 4, 0.5, 1);
            GraphNode NodeQ = CreateNode("Q", 4, 0.5, 2);
            GraphNode NodeR = CreateNode("R", 4, 0.5, 3);
            GraphNode NodeS = CreateNode("S", 4, 0.5, 4);
            GraphNode NodeT = CreateNode("T", 4, 0.5, 5);
            GraphNode NodeU = CreateNode("U", 5, 0.5, 1);
            GraphNode NodeV = CreateNode("V", 5, 0.5, 2);
            GraphNode NodeW = CreateNode("W", 5, 0.5, 3);
            GraphNode NodeX = CreateNode("X", 5, 0.5, 4);
            GraphNode NodeY = CreateNode("Y", 5, 0.5, 5);

            // S P A G H E T 
            CreateConnection(NodeA, NodeF);
            CreateConnection(NodeA, NodeB);
            CreateConnection(NodeB, NodeG);
            CreateConnection(NodeB, NodeC);
            CreateConnection(NodeC, NodeD);
            CreateConnection(NodeC, NodeH);
            CreateConnection(NodeD, NodeI);
            CreateConnection(NodeD, NodeE);
            CreateConnection(NodeE, NodeJ);
            // S P A G H E T 
            CreateConnection(NodeF, NodeK);
            CreateConnection(NodeF, NodeG);
            CreateConnection(NodeG, NodeL);
            CreateConnection(NodeG, NodeH);
            CreateConnection(NodeH, NodeM);
            CreateConnection(NodeH, NodeI);
            CreateConnection(NodeI, NodeN);
            CreateConnection(NodeI, NodeJ);
            CreateConnection(NodeJ, NodeO);
            // S P A G H E T 
            CreateConnection(NodeK, NodeP);
            CreateConnection(NodeK, NodeL);
            CreateConnection(NodeL, NodeQ);
            CreateConnection(NodeL, NodeM);
            CreateConnection(NodeM, NodeR);
            CreateConnection(NodeM, NodeN);
            CreateConnection(NodeN, NodeS);
            CreateConnection(NodeN, NodeO);
            CreateConnection(NodeO, NodeI);
            // S P A G H E T 
            CreateConnection(NodeP, NodeU);
            CreateConnection(NodeP, NodeQ);
            CreateConnection(NodeQ, NodeV);
            CreateConnection(NodeQ, NodeR);
            CreateConnection(NodeR, NodeW);
            CreateConnection(NodeR, NodeS);
            CreateConnection(NodeS, NodeX);
            CreateConnection(NodeS, NodeI);
            CreateConnection(NodeT, NodeY);
            // S P A G H E T 
            CreateConnection(NodeU, NodeV);
            CreateConnection(NodeV, NodeW);
            CreateConnection(NodeW, NodeX);
            CreateConnection(NodeX, NodeY);

            Graph graph = new Graph(allthenodes);
            route1 = graph.FindShortestPath(NodeA, NodeU);
            route2 = graph.FindShortestPath(NodeA, NodeJ);
            //route2 = graph.FindShortestPath(NodeK, NodeJ);

            //List<GraphNode > nodelist = new List<GraphNode> { NodeC, NodeD, NodeE, NodeF, NodeG };
            //List<GraphNode > nodelist2 = new List<GraphNode> { NodeA, NodeB, NodeC, NodeD, NodeE };

            v.Rotate(0, -90 * (Math.PI / 180), 0);
            r2.Rotate(0, -90 * (Math.PI / 180), 0);

            vectorlist1 = ToVector(route1);
            vectorlist2 = ToVector(route2);
            r.GiveDestination(vectorlist1);
            r2.GiveDestination(vectorlist2);

            v.GiveDestination(5, 2, 0);
            d.Rotate(0, 180 * (Math.PI / 180), 0);
            d2.Rotate(0, 180 * (Math.PI / 180), 0);


        }
        private List<Vector> ToVector(List<GraphNode> nodes) {
            List<Vector> vlist = new List<Vector>();
            foreach (GraphNode node in nodes)
            {
                Vector v = new Vector(node.xD, node.yD, node.zD);
                vlist.Add(v);
            }
            return vlist;
        }

        private void CreateConnection(GraphNode start, GraphNode end)
        {
            Connection c = new Connection(start, end);
            c.GetLength();
            start.AddConnection(c);
            end.AddConnection(c);
        }
        private GraphNode CreateNode(string name, double x, double y, double z)
        {
            GraphNode n = new GraphNode(name, x, y, z);
            allthenodes.Add(n);
            return n;
        }

        private Dock CreateDock(double x, double y, double z)
        {
            Dock d = new Dock(x, y, z, 0, 0, 0);
            worldObjects.Add(d);
            return d;
        }
        private Stellage CreateStellage(double x, double y, double z)
        {
            Stellage s = new Stellage(x, y, z, 0, 0, 0);
            worldObjects.Add(s);
            return s;
        }

        private Vrachtwagen CreateVrachtwagen(double x, double y, double z)
        {
            Vrachtwagen v = new Vrachtwagen(x, y, z, 0, 0, 0);
            worldObjects.Add(v);
            return v;
        }

        private Robot CreateRobot(double x, double y, double z)
        {
            Robot r = new Robot(x, y, z, 0, 0, 0);
            worldObjects.Add(r);
            return r;
        }

        public IDisposable Subscribe(IObserver<Command> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);

                SendCreationCommandsToObserver(observer);
            }
            return new Unsubscriber<Command>(observers, observer);
        }

        private void SendCommandToObservers(Command c)
        {
            for (int i = 0; i < this.observers.Count; i++)
            {
                this.observers[i].OnNext(c);
            }
        }

        private void SendCreationCommandsToObserver(IObserver<Command> obs)
        {
            foreach (C3Dmodel m3d in worldObjects)
            {
                obs.OnNext(new UpdateModel3DCommand(m3d));
            }
        }
        

        public bool Update(int tick)
        {
            for (int i = 0; i < worldObjects.Count; i++)
            {
                C3Dmodel u = worldObjects[i];

                if (u is IUpdatable)
                {
                    bool needsCommand = ((IUpdatable)u).Update(tick);

                    if (needsCommand)
                    {
                        SendCommandToObservers(new UpdateModel3DCommand(u));
                    }
                }
            }

            return true;
        }
    }

    internal class Unsubscriber<Command> : IDisposable
    {
        private List<IObserver<Command>> _observers;
        private IObserver<Command> _observer;

        internal Unsubscriber(List<IObserver<Command>> observers, IObserver<Command> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}