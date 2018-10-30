using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models 
{
    public class Vrachtwagen : C3Dmodel
    {
        public List<Vector> _DestinationList;
        public List<Vector> ExitList;
        public Vector _Destination;
        public Vrachtwagen(double x, double y, double z, double rotationX, double rotationY, double rotationZ, List<Vector> EList) : base(x, y, z, rotationX, rotationY, rotationZ)
        {
            this.type = "vrachtwagen";
            this.guid = Guid.NewGuid();
            ExitList = EList;
            step = 0.004;
            

        }

        //geef bestemming
        public void GiveDestination(/*double x1, double y1, double z1, */List<Vector> graphNodes)
        {
            if (graphNodes.Count > 0)
            {
                _DestinationList = graphNodes;
                _Destination = graphNodes[0];
                _xDirection = _Destination.x - x;
                _yDirection = _Destination.y - y;
                _zDirection = _Destination.z - z;
                _xDestination = _Destination.x;
                _yDestination = _Destination.y;
                _zDestination = _Destination.z;

                //var rxy = Math.Sqrt(Math.Pow(_xDirection, 2) + Math.Pow(_yDirection, 2));
                //var lambda = Math.Atan(_yDirection / _xDirection);
                //var phi = Math.Atan(_zDirection / rxy);
                ////if (_xDirection < 0) { phi = phi + 180; Rotate(0,phi, 0); }
                //if (_zDirection < 0) { lambda = -1 * lambda; Rotate(0,lambda,0); }
                _DestinationList.RemoveAt(0);

            }
        }

        public override bool Update(int tick)
        {
            //bewegen
            if ((Math.Round(this.xDestination, 2) != Math.Round(x, 2)) || (Math.Round(yDestination, 2) != Math.Round(y, 2)) || (Math.Round(zDestination, 1) != Math.Round(z, 1)))
            {
                Move(x + step * xDirection, y + step * yDirection, z + step * zDirection);
            }
            else 
            {
                this.GiveDestination(_DestinationList);
            }
            return base.Update(tick);
        }
    }
}
