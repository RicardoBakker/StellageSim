using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Stellage : C3Dmodel, IUpdatable
    {
        public double newX, newY, newZ;

        public Stellage(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {
            x = newX;
            y = newY;
            z = newZ;
            this.type = "stellage";
            this.guid = Guid.NewGuid();
        }
        //public void GiveCoordinates(List<GraphNode> Nodes)
        //{
        //    foreach (var node in Nodes)
        //    {
        //        newX = _x;
        //        newY = _y;
        //        newZ = _z;
        //    }
        //}

        public override bool Update(int tick)
        {
            return base.Update(tick);
        }
    }
}