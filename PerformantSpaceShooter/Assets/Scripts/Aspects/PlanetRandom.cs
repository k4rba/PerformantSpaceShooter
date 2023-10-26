using Unity.Entities;
using Unity.Mathematics;

namespace Aspects {
    public struct PlanetRandom : IComponentData {
        public Random Value;
    }
}