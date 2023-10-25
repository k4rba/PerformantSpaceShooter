using Unity.Entities;
using Unity.Mathematics;


namespace ComponentsAndTags {
    public struct PlanetProperties : IComponentData {
        public float2 FieldDimensions;
        public int NumberOfSpawnersToSpawn;
        public Entity SpawnerPrefab;
        public Entity AlienPrefab;
        public float AlienSpawnRate;
        public int NumOfAliens;
    }

    public struct AlienSpawnTimer : IComponentData {
        public float Value;
    }

    public struct AmountOfAliens : IComponentData {
        public int Value;
    }

    public struct PlanetTag : IComponentData {
    }
}