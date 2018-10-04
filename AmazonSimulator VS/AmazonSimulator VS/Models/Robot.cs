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

        //Constructor
        public Robot(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {

            this.type = "robot";
            this.guid = Guid.NewGuid();
        }

        //geef bestemming
        public void GiveDestination(/*double x1, double y1, double z1, */List<Vector> graphNodes)
        {
           // xDirection = x1 - x;
           // yDirection = y1 - y;
           // zDirection = z1 - z;
           // xDestination = x1;
           // yDestination = y1;
           //Destination = z1;
            if (graphNodes.Count > 0)
            {
                _DestinationList = graphNodes;
                _Destination = graphNodes[0];
               _xDirection = _Destination.x - x;
              _yDirection = _Destination.y - y;
               _zDirection = _Destination.z- z;
               _xDestination = _Destination.x;
               _yDestination = _Destination.y;
                _zDestination = _Destination.z;
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