using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Island : C3Dmodel
    {
        //Constructor
        public Island(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {

            this.type = "island";
            this.guid = Guid.NewGuid();
        }
    }
}
