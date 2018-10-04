using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Plant : C3Dmodel
    {
        public Plant(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {
            this.type = "plant";
            this.guid = Guid.NewGuid();
        }
    }
}
