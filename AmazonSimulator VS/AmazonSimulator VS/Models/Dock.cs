using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Dock : C3Dmodel, IUpdatable
    {
        public Dock(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {
            this.type = "dock";
            this.guid = Guid.NewGuid();
        }
    }
}
