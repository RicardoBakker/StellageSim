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

            //Vector v1 = CreateVector();
            //Vector v2 = CreateVector();
            //Vector v3 = CreateVector();
            //Vector v4 = CreateVector();
            //Vector v5 = CreateVector();
            //Vector v6 = CreateVector();
            //Vector v7 = CreateVector();
            //Vector v8 = CreateVector();
            //Vector v9 = CreateVector();
            //Vector v0 = CreateVector();



            //for test
            int a = 4;
            int b = 0;
            Island i = CreateIsland(0, -28, 0);
            Robot r = CreateRobot(-1 * a, 0.5 * b, -5 * a);
            Robot r2 = CreateRobot(-1 * a, 0.5 * b, -4 * a);
            
            Dock d = CreateDock(-2, 1.2, -5);
            Dock d2 = CreateDock(12, 1.2, -5);
            Stellage s = CreateStellage(10, 0.2, 10);
            Stellage s2 = CreateStellage(1, 0.2, 10);
            Stellage s3 = CreateStellage(10, 0.2, 5);
            Stellage s4 = CreateStellage(6, 0.2, 8);
            Plant p = CreatePlant(10, 10, 18);
            Plant p2 = CreatePlant(2, 0.3, -4);
            Plant p3 = CreatePlant(4, 0.3, 15);
            Plant p4 = CreatePlant(12, 0.3, 16);
            Plant p5 = CreatePlant(6, 0.3, -2);
            Plant p6 = CreatePlant(10, 0.3, -6);
            Tree t = CreateTree(-6, 0, 8);

            //v.Rotate(0, -90 * (Math.PI / 180), 0);

            List<GraphNode> route1 = new List<GraphNode>();
            List<GraphNode> route2 = new List<GraphNode>();
            List<Vector> vectorlist1 = new List<Vector>();
            List<Vector> vectorlist2 = new List<Vector>();
            List<Vector> vectorlist3 = new List<Vector>{CreateVector(35, -25, -7) ,CreateVector(25, -15, -7),CreateVector(26, -10, -0),CreateVector(25, 0, -0),CreateVector(20, 10, 2),CreateVector(15, 0, -2) };
            List<Vector> vectorlist4 = new List<Vector>();
            List<Vector> Exitlist = new List<Vector>{CreateVector(15, 0, -2), CreateVector(15, 4, -2), CreateVector(5, 4, -2), CreateVector(-5, 0, -2), CreateVector(-5, -7, 0) };
           Vrachtwagen v = CreateVrachtwagen(35, -25, -7,Exitlist);
            //vectorlist3.Add(CreateVector(5, -0, -0));
            //vectorlist3.Add(CreateVector(15, -0, -3));
            //vectorlist3.Add(CreateVector(10, 0, 0));
            //vectorlist3.Add(CreateVector(5, 0, -0));


            // S P A G H E T 
            GraphNode NodeA = CreateNode("A", 1 * a, 0.5*b, 1 * a);
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
            route2 = graph.FindShortestPath(NodeA, NodeV);
            //route2 = graph.FindShortestPath(NodeK, NodeJ);

            //List<GraphNode > nodelist = new List<GraphNode> { NodeC, NodeD, NodeE, NodeF, NodeG };
            //List<GraphNode > nodelist2 = new List<GraphNode> { NodeA, NodeB, NodeC, NodeD, NodeE };

            //v.Rotate(0, -90 * (Math.PI / 180), 0);
            r2.Rotate(0, -90 * (Math.PI / 180), 0);
            p.Move(10,10,10);
            vectorlist1 = ToVector(route1);
            vectorlist2 = ToVector(route2);
            r.GiveDestination(vectorlist1);
            r2.GiveDestination(vectorlist2);

            v.GiveDestination(vectorlist3);
            d.Rotate(0, 180 * (Math.PI / 180), 0);
            d2.Rotate(0, 180 * (Math.PI / 180), 0);
            i.Rotate(0, 130 * (Math.PI / 180), 0);
        }
        private Vector CreateVector(double x, double y, double z)
        {
            return new Vector(x,y,z);
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
        private GraphNode CreateNode(string name, double x, double y, double z)
        {
            GraphNode n = new GraphNode(name, x, y, z);
            allthenodes.Add(n);
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

        private Stellage CreateStellage(double x, double y, double z)
        {
            Stellage s = new Stellage(x, y, z, 0, 0, 0);
            worldObjects.Add(s);
            return s;
        }

        private Vrachtwagen CreateVrachtwagen(double x, double y, double z, List<Vector> exit)
        {
            Vrachtwagen v = new Vrachtwagen(x, y, z, 0, 0, 0, exit);
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