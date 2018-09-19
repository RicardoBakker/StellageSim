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

        public void GiveDestination(double x1, double y1, double z1)
        {
            xDirection = x1 - x;
            yDirection = y1 - y;
            zDirection = z1 - z;
            xDestination = x1;
            yDestination = y1;
            zDestination = z1;
        }

        public override bool Update(int tick)
        {
            //aankomen
            if ((Math.Round(xDestination, 2) != Math.Round(x, 2)) || (Math.Round(yDestination, 2) != Math.Round(y, 2)) || (Math.Round(zDestination, 2) != Math.Round(z, 2)))
            {
                Move(x + step * xDirection, y + step * yDirection, z + step * zDirection);
            }

            return base.Update(tick);
        }
    }
}
