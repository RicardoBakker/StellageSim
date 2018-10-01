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

        public World()
        {
            Dock d = CreateDock(-2, 1.2, -5);
            Dock d2 = CreateDock(12, 1.2, -5);
            Robot r = CreateRobot(-2, 0.5, -5);
            Robot r2 = CreateRobot(-2, 0.5, -5);
            Robot r3 = CreateRobot(12, 0.5, -5);
            Robot r4 = CreateRobot(12, 0.5, -5);
            Stellage s = CreateStellage(10, 0.2, 10);
            Stellage s2 = CreateStellage(1, 0.2, 10);
            Stellage s3 = CreateStellage(10, 0.2, 5);
            Stellage s4 = CreateStellage(6, 0.2, 8);
            Vrachtwagen v = CreateVrachtwagen(30, 10, -3.5);

            d.Rotate(0, 180 * (Math.PI / 180), 0);
            d2.Rotate(0, 180 * (Math.PI / 180), 0);
            v.Rotate(0, -90 * (Math.PI / 180), 0);
            v.Rotate(0, -90*(Math.PI / 180), 0);
            r.Rotate(0, -90 * (Math.PI / 180), 0);
            r2.Rotate(0, -90 * (Math.PI / 180), 0);
            r3.Rotate(0, -90 * (Math.PI / 180), 0);
            r4.Rotate(0, -90 * (Math.PI / 180), 0);

            v.GiveDestination(6, 0, 0);
            r.GiveDestination(10, 0.5, 10);
            r2.GiveDestination(1, 0.5, 10);
            r3.GiveDestination(10, 0.5, 5);
            r4.GiveDestination(6, 0.5, 8);
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