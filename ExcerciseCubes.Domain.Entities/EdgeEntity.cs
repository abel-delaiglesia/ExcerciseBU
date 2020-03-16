using System;

namespace ExcerciseCubes.Domain.Entities
{
    public class EdgeEntity
    {
        public double start { set; get; }
        public double end { set; get; }
        public EdgeEntity(double center, double length)
        {
            start = center - length / 2.0;
            end = center + length / 2.0;
        }

        public double Overlap(EdgeEntity edge) =>
            Math.Max(0, Difference(edge));

        public bool Collides(EdgeEntity edge) =>
            Difference(edge) >= 0;

        private double Difference(EdgeEntity edge) =>
            Math.Min(end, edge.end) - Math.Max(start, edge.start);
    }    
}
