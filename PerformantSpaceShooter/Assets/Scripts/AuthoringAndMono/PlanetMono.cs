using ComponentsAndTags;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace AuthoringAndMono {
    public class PlanetMono : MonoBehaviour {
        public float2 FieldDimensions;
        public int NumberSpawnersToSpawn;
        public GameObject SpawnerPrefab;
        public uint RandomSeed;
    }

    public class PlanetBaker : Baker<PlanetMono> {
        public override void Bake(PlanetMono authoring) {
            AddComponent(new PlanetProperties {
                FieldDimensions =  authoring.FieldDimensions,
                NumberOfSpawnersToSpawn = authoring.NumberSpawnersToSpawn,
                SpawnerPrefab = GetEntity(authoring.SpawnerPrefab)
            });
            
            AddComponent(new PlanetRandom {
                Value =  Random.CreateFromIndex(authoring.RandomSeed)
            });
        }
    }
}