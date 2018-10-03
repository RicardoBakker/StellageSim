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

        //bestemming
        public Robot(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {
            DestinationList = new List<GraphNode<String>>();
            this.type = "robot";
            this.guid = Guid.NewGuid();
        }

        //geef bestemming
        public void GiveDestination(/*double x1, double y1, double z1, */List<GraphNode<String>> nodes)
        {
            //xDirection = x1 - x;
            //yDirection = y1 - y;
            //zDirection = z1 - z;
            //xDestination = x1;
            //yDestination = y1;
            //zDestination = z1;
            DestinationList.AddRange(nodes);
            Destination = DestinationList[0];
            xDirection = Destination.xD - x;
            yDirection = Destination.yD - y;
            zDirection = Destination.zD - z;
            xDestination = Destination.xD;
            yDestination = Destination.yD;
            zDestination = Destination.zD;
        }

        public override bool Update(int tick)
        {
            //bewegen
            if ((Math.Round(xDestination, 2) != Math.Round(x, 2)) || (Math.Round(yDestination, 2) != Math.Round(y, 2)) || (Math.Round(zDestination, 1) != Math.Round(z, 1)))
            {
                Destination = DestinationList.First();
                Move(x + step * xDirection, y + step * yDirection, z + step * zDirection);
            }
            else if (needsUpdate == false)
            {
                try
                {
                    DestinationList.RemoveAt(0);
                    GiveDestination(DestinationList);
                    
                }
                catch (Exception)
                {
                    return base.Update(tick);
                }

            }
            return base.Update(tick);
        }
    }
}