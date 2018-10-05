using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Vector
{
        protected double _x = 0;
        protected double _y = 0;
        protected double _z = 0;
        public Guid guid { set; get; }
        public double x { get { return _x; } }
        public double y { get { return _y; } }
        public double z { get { return _z; } }
        public Vector(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
            this.guid = Guid.NewGuid();
        }
    }
}
