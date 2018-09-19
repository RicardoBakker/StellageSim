using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models {
    public class Robot : C3Dmodel ,IUpdatable {

        //bestemming
        

        public Robot(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x,y,z,rotationX,rotationY,rotationZ) {
            
            this.type = "robot";
            this.guid = Guid.NewGuid();
        }

        //geef bestemming

        public override bool Update(int tick)
        {
            //bewegen

            return base.Update(tick);
        }
    }
}