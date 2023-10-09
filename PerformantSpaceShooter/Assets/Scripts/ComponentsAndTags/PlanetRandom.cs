using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags {
    public struct PlanetRandom : IComponentData {
        public Random Value;
    }
}