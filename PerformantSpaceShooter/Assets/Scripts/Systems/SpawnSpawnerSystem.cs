using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
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
            
            for (var i = 0; i < planet.NumberSpawnersToSpawn; i++) {
                var newSpawner = ecb.Instantiate(planet.SpawnerPrefab);
                var newSpawnerTransform = planet.GetRandomSpawnerTransform();
                ecb.SetComponent(newSpawner, new LocalTransform {
                    Position = newSpawnerTransform.Position,
                    Scale = newSpawnerTransform.Scale,
                    Rotation = newSpawnerTransform.Rotation
                });
            }
            ecb.Playback(state.EntityManager);
        }
    }
}