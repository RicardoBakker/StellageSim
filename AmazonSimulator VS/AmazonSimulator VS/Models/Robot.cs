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
<<<<<<< HEAD

        //bestemming
        public Robot(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {

=======
        //bestemming
        public Robot(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {
>>>>>>> ricardo
            this.type = "robot";
            this.guid = Guid.NewGuid();
        }

        //geef bestemming
<<<<<<< HEAD
        public List<GraphNode<String>> GiveDestination(/*double x1, double y1, double z1, */List<GraphNode<String>> nodes)
        {
            //xDirection = x1 - x;
            //yDirection = y1 - y;
            //zDirection = z1 - z;
            //xDestination = x1;
            //yDestination = y1;
            //zDestination = z1;
            if (nodes.Count > 0)
            {
                _DestinationList = nodes;
                _Destination = nodes[0];
                _DestinationList.RemoveAt(0);
                _xDirection = Destination.xD - x;
                _yDirection = Destination.yD - y;
                _zDirection = Destination.zD - z;
                _xDestination = Destination.xD;
                _yDestination = Destination.yD;
                _zDestination = Destination.zD;
            }
            return nodes;
=======
        public void GiveDestination(double x1, double y1, double z1)
        {
            xDirection = x1 - x;
            yDirection = y1 - y;
            zDirection = z1 - z;
            xDestination = x1;
            yDestination = y1;
            zDestination = z1;
>>>>>>> ricardo
        }

        public override bool Update(int tick)
        {
            //bewegen
<<<<<<< HEAD
            if ((Math.Round(this.xDestination, 2) != Math.Round(x, 2)) || (Math.Round(yDestination, 2) != Math.Round(y, 2)) || (Math.Round(zDestination, 1) != Math.Round(z, 1)))
            {
                Move(x + step * xDirection, y + step * yDirection, z + step * zDirection);
            }
            else
            {
              this.GiveDestination(_DestinationList);
            }
            
=======
            if ((Math.Round(xDestination, 2) != Math.Round(x, 2)) || (Math.Round(yDestination, 2) != Math.Round(y, 2)) || (Math.Round(zDestination, 1) != Math.Round(z, 1)))
            {
                Move(x + step * xDirection, y + step * yDirection, z + step * zDirection);
            }

>>>>>>> ricardo
            return base.Update(tick);
        }
    }
}