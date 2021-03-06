using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;

namespace Models
{
    public class World : IObservable<Command>, IUpdatable
    {
        private List<C3Dmodel> worldObjects = new List<C3Dmodel>();
        //private List<Vrachtwagen> vwlist = new List<Vrachtwagen>();
        private List<IObserver<Command>> observers = new List<IObserver<Command>>();

        public World()
        {
            Robot r = CreateRobot(1, 0.5, 10);
            Robot r2 = CreateRobot(1, 0.5, 1);
            Vrachtwagen v = CreateVrachtwagen(30, 10, -3.5);
            //Dock d = CreateDock(0, 0, 0);
            v.Rotate(0, -90 * (Math.PI / 180), 0);
            //r2.Move(10, 0, 13);
            GraphNode<String> NodeA = new GraphNode<String>("A", 0, 0.5, 5);
            GraphNode<String> NodeB = new GraphNode<String>("B", 5, 0.5, 5);
            GraphNode<String> NodeC = new GraphNode<String>("C", 5, 0.5, 10);
            GraphNode<String> NodeD = new GraphNode<String>("D", 10, 0.5, 10);
            GraphNode<String> NodeE = new GraphNode<String>("E", 10, 0.5, 5);
            GraphNode<String> NodeF = new GraphNode<String>("F", 15, 0.5, 5);
            GraphNode<String> NodeG = new GraphNode<String>("G", 15, 0.5, 15);

            List<GraphNode<String>> nodelist = new List<GraphNode<String>> { NodeC, NodeD, NodeE, NodeF, NodeG};
            List<GraphNode<String>> nodelist2 = new List<GraphNode<String>> { NodeA, NodeB, NodeC, NodeD, NodeE};
            v.Rotate(0, -90*(Math.PI / 180), 0);
            r2.Rotate(0, -90 * (Math.PI / 180), 0);
            r.GiveDestination(nodelist);
            r2.GiveDestination(nodelist2);

            v.GiveDestination(5, 0, 0);
           
            
        }
        private Dock CreateDock(double x, double y, double z)
        {
            Dock d= new Dock(x, y, z, 0, 0, 0);
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