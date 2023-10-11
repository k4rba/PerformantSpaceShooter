using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems {
    
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnSpawnerSystem : ISystem{
        [BurstCompile]
        public void OnCreate(ref SystemState state) {
            state.RequireForUpdate<PlanetProperties>();

        }
        [BurstCompile]
        public void OnDestroy(ref SystemState state) {

        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            state.Enabled = false;
            var planetEntity = SystemAPI.GetSingletonEntity<PlanetProperties>();
            var planet = SystemAPI.GetAspect<PlanetAspect>(planetEntity);

            var ecb = new EntityCommandBuffer(Allocator.Temp);
            
            var spawnerOffset = new float3(0f, -2f, 0f);
            
            var builder = new BlobBuilder(Allocator.Temp);
            ref var spawnPoints = ref builder.ConstructRoot<AlienSpawnPointsBlob>();
            var arrayBuilder = builder.Allocate(ref spawnPoints.Value, planet.NumberSpawnersToSpawn);
            
            for (var i = 0; i < planet.NumberSpawnersToSpawn; i++) {
                var newSpawner = ecb.Instantiate(planet.SpawnerPrefab);
                var newSpawnerTransform = planet.GetRandomSpawnerTransform();
                ecb.SetComponent(newSpawner, new LocalTransform {
                    Position = newSpawnerTransform.Position,
                    Scale = newSpawnerTransform.Scale,
                    Rotation = newSpawnerTransform.Rotation
                });
                var newAlienSpawnPoint = newSpawnerTransform.Position + spawnerOffset;
                arrayBuilder[i] = newAlienSpawnPoint;
            }

            var blobAsset = builder.CreateBlobAssetReference<AlienSpawnPointsBlob>(Allocator.Persistent);
            ecb.SetComponent(planetEntity, new AlienSpawnPoints{Value =  blobAsset});
            builder.Dispose();

            ecb.Playback(state.EntityManager);
        }
    }
}