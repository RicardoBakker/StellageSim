using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models 
{
    public class Vrachtwagen : C3Dmodel
    {
        public Vrachtwagen(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {
            this.type = "vrachtwagen";
            this.guid = Guid.NewGuid();
        }
    }
}
