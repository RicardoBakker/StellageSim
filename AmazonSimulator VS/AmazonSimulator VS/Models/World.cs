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
            #region [Variables]
            int a = 2;
            int b = 0;
            #endregion

            #region [Lists]
            List<GraphNode> route1 = new List<GraphNode>();
            List<GraphNode> route2 = new List<GraphNode>();
            List<Vector> vectorlist1 = new List<Vector>();
            List<Vector> vectorlist2 = new List<Vector>();
            #endregion

            #region [Create Objects]
            Island i = CreateIsland(5, -25, 0);
            Robot r = CreateRobot(1 * a, 0.5 * b, 1 * a);
            Robot r2 = CreateRobot(1 * a, 0.5 * b, 4 * a);
            Vrachtwagen v = CreateVrachtwagen(30, 10, -3.5);
            Dock d = CreateDock(-2, 1.2, -5);
            Dock d2 = CreateDock(12, 1.2, -5);
            Plant p = CreatePlant(10, 0.3, 18);
            Plant p2 = CreatePlant(2, 0.3, -12);
            Plant p3 = CreatePlant(4, 0.3, 15);
            Plant p4 = CreatePlant(12, 0.3, 16);
            Plant p5 = CreatePlant(6, 0.3, -12);
            Plant p6 = CreatePlant(10, 0.3, -16);
            Tree t = CreateTree(-6, 0, 8);
            #endregion

            #region [Rotate Objects]
            d.Rotate(0, 180 * (Math.PI / 180), 0);
            d2.Rotate(0, 180 * (Math.PI / 180), 0);
            r.Rotate(0, -90 * (Math.PI / 180), 0);
            r2.Rotate(0, -90 * (Math.PI / 180), 0);
            v.Rotate(0, -90 * (Math.PI / 180), 0);
            #endregion

            #region [Create Nodes]
            GraphNode NodeA = CreateNode("A", 1 * a, 0.5 * b, 1 * a);
            GraphNode NodeB = CreateNode("B", 1 * a, 0.5 * b, 2 * a);
            GraphNode NodeC = CreateNode("C", 1 * a, 0.5 * b, 3 * a);
            GraphNode NodeD = CreateNode("D", 1 * a, 0.5 * b, 4 * a);
            GraphNode NodeE = CreateNode("E", 1 * a, 0.5 * b, 5 * a);
            GraphNode NodeF = CreateNode("F", 2 * a, 0.5 * b, 1 * a);
            GraphNode NodeG = CreateNode("G", 2 * a, 0.5 * b, 2 * a);
            GraphNode NodeH = CreateNode("H", 2 * a, 0.5 * b, 3 * a);
            GraphNode NodeI = CreateNode("I", 2 * a, 0.5 * b, 4 * a);
            GraphNode NodeJ = CreateNode("J", 2 * a, 0.5 * b, 5 * a);
            GraphNode NodeK = CreateNode("K", 3 * a, 0.5 * b, 1 * a);
            GraphNode NodeL = CreateNode("L", 3 * a, 0.5 * b, 2 * a);
            GraphNode NodeM = CreateNode("M", 3 * a, 0.5 * b, 3 * a);
            GraphNode NodeN = CreateNode("N", 3 * a, 0.5 * b, 4 * a);
            GraphNode NodeO = CreateNode("O", 3 * a, 0.5 * b, 5 * a);
            GraphNode NodeP = CreateNode("P", 4 * a, 0.5 * b, 1 * a);
            GraphNode NodeQ = CreateNode("Q", 4 * a, 0.5 * b, 2 * a);
            GraphNode NodeR = CreateNode("R", 4 * a, 0.5 * b, 3 * a);
            GraphNode NodeS = CreateNode("S", 4 * a, 0.5 * b, 4 * a);
            GraphNode NodeT = CreateNode("T", 4 * a, 0.5 * b, 5 * a);
            GraphNode NodeU = CreateNode("U", 5 * a, 0.5 * b, 1 * a);
            GraphNode NodeV = CreateNode("V", 5 * a, 0.5 * b, 2 * a);
            GraphNode NodeW = CreateNode("W", 5 * a, 0.5 * b, 3 * a);
            GraphNode NodeX = CreateNode("X", 5 * a, 0.5 * b, 4 * a);
            GraphNode NodeY = CreateNode("Y", 5 * a, 0.5 * b, 5 * a);
            #endregion

            #region [Connect Nodes]
            CreateConnection(NodeA, NodeF);
            CreateConnection(NodeA, NodeB);
            CreateConnection(NodeB, NodeG);
            CreateConnection(NodeB, NodeC);
            CreateConnection(NodeC, NodeD);
            CreateConnection(NodeC, NodeH);
            CreateConnection(NodeD, NodeI);
            CreateConnection(NodeD, NodeE);
            CreateConnection(NodeE, NodeJ);      
            CreateConnection(NodeF, NodeK);
            CreateConnection(NodeF, NodeG);
            CreateConnection(NodeG, NodeL);
            CreateConnection(NodeG, NodeH);
            CreateConnection(NodeH, NodeM);
            CreateConnection(NodeH, NodeI);
            CreateConnection(NodeI, NodeN);
            CreateConnection(NodeI, NodeJ);
            CreateConnection(NodeJ, NodeO);
            CreateConnection(NodeK, NodeP);
            CreateConnection(NodeK, NodeL);
            CreateConnection(NodeL, NodeQ);
            CreateConnection(NodeL, NodeM);
            CreateConnection(NodeM, NodeR);
            CreateConnection(NodeM, NodeN);
            CreateConnection(NodeN, NodeS);
            CreateConnection(NodeN, NodeO);
            CreateConnection(NodeO, NodeI);
            CreateConnection(NodeP, NodeU);
            CreateConnection(NodeP, NodeQ);
            CreateConnection(NodeQ, NodeV);
            CreateConnection(NodeQ, NodeR);
            CreateConnection(NodeR, NodeW);
            CreateConnection(NodeR, NodeS);
            CreateConnection(NodeS, NodeX);
            CreateConnection(NodeS, NodeI);
            CreateConnection(NodeT, NodeY);
            CreateConnection(NodeU, NodeV);
            CreateConnection(NodeV, NodeW);
            CreateConnection(NodeW, NodeX);
            CreateConnection(NodeX, NodeY);
            #endregion

            Graph graph = new Graph(allthenodes);
            route1 = graph.FindShortestPath(NodeA, NodeU);
            route2 = graph.FindShortestPath(NodeD, NodeV);

            vectorlist1 = ToVector(route1);
            vectorlist2 = ToVector(route2);

            r.GiveDestination(vectorlist1);
            r2.GiveDestination(vectorlist2);
            v.GiveDestination(5, 2, 0);
        }
        private List<Vector> ToVector(List<GraphNode> nodes)
        {
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

        private Stellage CreateStellage(double x, double y, double z)
        {
            Stellage s = new Stellage(x, y, z, 0, 0, 0);
            worldObjects.Add(s);
            return s;
        }

        private GraphNode CreateNode(string name, double x, double y, double z)
        {
            GraphNode n = new GraphNode(name, x, y, z);
            allthenodes.Add(n);
            foreach (GraphNode node in allthenodes)
            {
                CreateStellage(x, y, z);
            }
            return n;
        }

        private Island CreateIsland(double x, double y, double z)
        {
            Island i = new Island(x, y, z, 0, 0, 0);
            worldObjects.Add(i);
            return i;
        }
        
        private Tree CreateTree(double x, double y, double z)
        {
            Tree t = new Tree(x, y, z, 0, 0, 0);
            worldObjects.Add(t);
            return t;
        }

        private Plant CreatePlant(double x, double y, double z)
        {
            Plant p = new Plant(x, y, z, 0, 0, 0);
            worldObjects.Add(p);
            return p;
        }

        private Dock CreateDock(double x, double y, double z)
        {
            Dock d = new Dock(x, y, z, 0, 0, 0);
            worldObjects.Add(d);
            return d;
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