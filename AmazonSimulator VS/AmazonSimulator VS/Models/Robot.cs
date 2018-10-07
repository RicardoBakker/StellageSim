using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Collections;
using System.Windows;
using System.Numerics;

namespace Models
{
    public class Robot : C3Dmodel, IUpdatable
    {
        public List<Vector> _DestinationList;
        public Vector _Destination;
        public int i;

        //Constructor
        public Robot(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {

            this.type = "robot";
            this.guid = Guid.NewGuid();
        }

        //geef bestemming
        public void GiveDestination(List<Vector> graphNodes)
        {
            if (graphNodes.Count > i)
            {
                _DestinationList = graphNodes;
                _Destination = graphNodes[i];
                _xDirection = _Destination.x - x;
                _yDirection = _Destination.y - y;
                _zDirection = _Destination.z - z;
                _xDestination = _Destination.x;
                _yDestination = _Destination.y;
                _zDestination = _Destination.z;
                if (Math.Round(xDirection, 0) > 0)
                {
                    Rotate(0, 0, 0);
                }
                else if (Math.Round(zDirection, 0) > 0)
                {
                    Rotate(0, -Math.PI / 2, 0);
                }
                else if (Math.Round(zDirection, 0) < 0)
                {
                    Rotate(0, Math.PI / 2, 0);
                }
                else if (Math.Round(xDirection, 0) < 0)
                {
                    Rotate(0, Math.PI, 0);
                }
                _DestinationList.RemoveAt(i);
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