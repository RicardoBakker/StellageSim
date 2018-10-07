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
        protected double _xDirection;
        protected double _yDirection;
        protected double _zDirection;
        protected double _xDestination;
        protected double _yDestination;
        protected double _zDestination;
        protected double step = 0.002;

        public bool needsUpdate { set; get; }
        public string type { set; get; }
        public Guid guid { set; get; }
        public double x { get { return _x; } }
        public double y { get { return _y; } }
        public double z { get { return _z; } }
        public double xDirection { get { return _xDirection; } }
        public double yDirection { get { return _yDirection; } }
        public double zDirection { get { return _zDirection; } }
        public double xDestination { get { return _xDestination; } }
        public double yDestination { get { return _yDestination; } }
        public double zDestination { get { return _zDestination; } }
        public double rotationX { get { return _rX; } }
        public double rotationY { get { return _rY; } }
        public double rotationZ { get { return _rZ; } }

        public List<Vector> vectorList { get; set; }
        public Vector vectorDestination { get; set; }

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