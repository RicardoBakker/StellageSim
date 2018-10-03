using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public abstract class C3Dmodel : IUpdatable
    {
        protected double _x = 0;
        protected double _y = 0;
        protected double _z = 0;
        protected double _rX = 0;
        protected double _rY = 0;
        protected double _rZ = 0;

        protected double step = 0.002;
        public double xDirection { set; get; }
        public double yDirection { set; get; }
        public double zDirection { set; get; }
        public double xDestination { set; get; }
        public double yDestination { set; get; }
        public double zDestination { set; get; }

        public bool needsUpdate { set; get; }
        public string type { set; get; }
        public Guid guid { set; get; }
        public double x { get { return _x; } }
        public double y { get { return _y; } }
        public double z { get { return _z; } }
        public double rotationX { get { return _rX; } }
        public double rotationY { get { return _rY; } }
        public double rotationZ { get { return _rZ; } }
        public List<GraphNode<String>> DestinationList { get; set; }
        public GraphNode<String> Destination { get; set; }

        public C3Dmodel(double x, double y, double z, double rotationX, double rotationY, double rotationZ)
        {
            this._x = x;
            this._y = y;
            this._z = z;
            this._rX = rotationX;
            this._rY = rotationY;
            this._rZ = rotationZ;
            this.needsUpdate = true;
        }
        public virtual bool Update(int tick)
        {
            
            if (needsUpdate)
            {
                needsUpdate = false;
                return true;
            }
            return false;
        }
        public virtual void Move(double x, double y, double z)
        {
            this._x = x;
            this._y = y;
            this._z = z;

            needsUpdate = true;
        }

        public virtual void Rotate(double rotationX, double rotationY, double rotationZ)
        {
            this._rX = rotationX;
            this._rY = rotationY;
            this._rZ = rotationZ;

            needsUpdate = true;
        }
    }
}
