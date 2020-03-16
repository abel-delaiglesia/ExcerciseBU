using ExcerciseCubeEntitys.Domain.Entities;
using ExcerciseCubes.Domain.Entities;

namespace ExcerciseCubes.Domain.Core
{
    public class CubeService 
    {
    
            private PointEntity center;
            private double edgeLength;

            public  CubeService Cube()
            {
                return new CubeService();
            }

            public CubeService CenteredAt(double x, double y, double z)
            {
                center = new PointEntity(x, y, z);
                return this;
            }

            public CubeService WithEdgeLength(double length)
            {
                edgeLength = length;
                return this;
            }

            public CubeEntity Build()
            {
                return new CubeEntity(center, edgeLength);
            }
        }

  
}
