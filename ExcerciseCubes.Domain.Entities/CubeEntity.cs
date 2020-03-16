using ExcerciseCubes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseCubeEntitys.Domain.Entities
{
    public class CubeEntity
    {
        public EdgeEntity width { get; set; }
        public EdgeEntity height { get; set; }
        public EdgeEntity depth { get; set; }

        public CubeEntity(PointEntity center, double EdgeLength)
        {
            width = new EdgeEntity(center.X, EdgeLength);
            height = new EdgeEntity(center.Y, EdgeLength);
            depth = new EdgeEntity(center.Z, EdgeLength);
        }

        public double IntersectionVolumeWith(CubeEntity CubeEntity) =>
                width.Overlap(CubeEntity.width)
                * height.Overlap(CubeEntity.height)
                * depth.Overlap(CubeEntity.depth);

        public bool CollidesWith(CubeEntity CubeEntity) =>
                width.Collides(CubeEntity.width)
                || height.Collides(CubeEntity.height)
                || depth.Collides(CubeEntity.depth);
    }
}
   
