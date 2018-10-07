using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models 
{
    public class Vrachtwagen : C3Dmodel
    {
        int count;

        public Vrachtwagen(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {
            this.type = "vrachtwagen";
            this.guid = Guid.NewGuid();
        }

        public void GiveDestination(double x1, double y1, double z1)
        {
            _xDirection = x1 - x;
            _yDirection = y1 - y;
            _zDirection = z1 - z;
            _xDestination = x1;
            _yDestination = y1;
            _zDestination = z1;
        }

        public void SpawnRobots()
        {
            for (int i = 0; i < 2; i++)
            {
                count++;
            }
        }

        public override bool Update(int tick)
        {
            //aankomen
            if (Math.Round(xDestination, 2) != Math.Round(x, 2))
            {
                Move(x + step * xDirection, y , z );
            }
            if (Math.Round(yDestination*2, 2) <= Math.Round(y, 2)) 
            {
                Move(x , y + step * yDirection*2, z);
            }
            if (Math.Round(zDestination, 2) != Math.Round(z, 2))
            {
                Move(x , y, z + step * zDirection);
            }

            return base.Update(tick);
        }
    }
}
