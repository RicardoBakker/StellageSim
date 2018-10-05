using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Tree : C3Dmodel
{
        //Constructor
        public Tree(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {

            this.type = "tree";
            this.guid = Guid.NewGuid();
        }
    }
}
