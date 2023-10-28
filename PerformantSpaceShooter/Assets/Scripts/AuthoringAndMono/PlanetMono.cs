using Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace AuthoringAndMono {
    public class PlanetMono : MonoBehaviour {
        public float2 FieldDimensions;
        public int NumberSpawnersToSpawn;
        public GameObject SpawnerPrefab;
        public GameObject AlienPrefab;
        public uint RandomSeed;
    }

    public class PlanetBaker : Baker<PlanetMono> {
        public override void Bake(PlanetMono authoring) {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new PlanetProperties {
                FieldDimensions =  authoring.FieldDimensions,
                NumberOfSpawnersToSpawn = authoring.NumberSpawnersToSpawn,
                SpawnerPrefab = GetEntity(authoring.SpawnerPrefab, TransformUsageFlags.Dynamic),
                AlienPrefab = GetEntity(authoring.AlienPrefab, TransformUsageFlags.Dynamic),
            });
            AddComponent(entity, new PlanetTag());
            AddComponent(entity, new RandomValue() {
                Value =  Random.CreateFromIndex(authoring.RandomSeed)
            });
            AddComponent<AlienSpawnTimer>(entity);
            AddComponent(entity, new AmountOfAliens{Value = 0});
            AddComponent(entity, new AlienSpawnRate{Value = 1});
            AddComponent(entity, new EnemySpawnTimerProperties {
                timer = 0f,
                interval = 2.5f
            });
        }
    }
}