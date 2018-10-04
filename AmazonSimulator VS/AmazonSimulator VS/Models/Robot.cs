using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
<<<<<<< HEAD

namespace Models {
    public class Robot : C3Dmodel ,IUpdatable {

        public Robot(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x,y,z,rotationX,rotationY,rotationZ) {
            this.type = "robot";
            this.needsUpdate = true;
=======
using System.Collections;
using System.Windows;
using System.Numerics;

namespace Models
{
    public class Robot : C3Dmodel, IUpdatable
    {

        //bestemming
        public Robot(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {

            this.type = "robot";
            this.guid = Guid.NewGuid();
        }

        //geef bestemming
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
>>>>>>> fabian
        }
    }
}