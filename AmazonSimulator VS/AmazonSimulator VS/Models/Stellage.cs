using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Stellage : C3Dmodel, IUpdatable
    {
        public Stellage(double x, double y, double z, double rotationX, double rotationY, double rotationZ) : base(x, y, z, rotationX, rotationY, rotationZ)
        {
            this.type = "stellage";
            this.guid = Guid.NewGuid();
        }

        public void GetPoint(List<GraphNode> nodes, double x, double y, double z)
        {
            
        }

        public void SetPoint(List<GraphNode> nodes, double x, double y, double z)
        {

        }

        public void GetUp(double x, double y, double z)
        {

        }

        public void Hide()
        {

        }
    
        public override bool Update(int tick)
        {
            return base.Update(tick);
        }
    }
}
