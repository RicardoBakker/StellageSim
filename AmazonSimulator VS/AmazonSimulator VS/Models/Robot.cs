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

            this.type = "robot";
            this.guid = Guid.NewGuid();
        }

        //geef bestemming
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
            //bewegen
            if ((Math.Round(xDestination, 2) != Math.Round(x, 2)) || (Math.Round(yDestination, 2) != Math.Round(y, 2)) || (Math.Round(zDestination, 1) != Math.Round(z, 1)))
            {
                Move(x + step * xDirection, y + step * yDirection, z + step * zDirection);
            }

            return base.Update(tick);
        }
    }
}