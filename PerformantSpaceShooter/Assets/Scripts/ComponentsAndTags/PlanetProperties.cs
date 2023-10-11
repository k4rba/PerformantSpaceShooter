using Unity.Entities;
using Unity.Mathematics;


namespace ComponentsAndTags {
    public struct PlanetProperties : IComponentData {
        public float2 FieldDimensions;
        public int NumberOfSpawnersToSpawn;
        public Entity SpawnerPrefab;
        public Entity AlienPrefab;
        public float AlienSpawnRate;
    }

    public struct AlienSpawnTimer : IComponentData {
        public float Value;
    }
}