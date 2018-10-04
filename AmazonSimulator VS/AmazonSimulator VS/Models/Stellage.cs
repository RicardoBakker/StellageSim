using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Stellage : C3Dmodel
{
        public Stellage(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
<<<<<<< HEAD
        {
            this.type = "stellage";
            this.needsUpdate = true;
=======
        {
            this.type = "stellage";
            this.needsUpdate = true;
>>>>>>> fabian
        }
    }
}
