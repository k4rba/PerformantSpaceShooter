using Aspects;
using Unity.Burst;
using Unity.Entities;

namespace Systems {
    [BurstCompile]
    public partial struct AlienInstantiateSystem : ISystem {
        [BurstCompile]
        public void OnCreate(ref SystemState state) {
          state.RequireForUpdate<BeginInitializationEntityCommandBufferSystem.Singleton>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            state.CompleteDependency();
            var deltaTime = SystemAPI.Time.DeltaTime;
            var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();
            new SpawnAlienJob() {
                DeltaTime = deltaTime,
                ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter()
            }.ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct SpawnAlienJob : IJobEntity {
        public float DeltaTime;
        public EntityCommandBuffer.ParallelWriter ecb;
    
        [BurstCompile]
        private void Execute(PlanetAspect planet, [EntityIndexInQuery] int sortKey) {
            planet.AlienSpawnTimer -= DeltaTime;
            if (!planet.TimeToSpawnAlien) return;
    
            planet.AlienAmount++;
            
            planet.AlienSpawnTimer = planet.AlienSpawnRate;
            var newAlien = ecb.Instantiate(sortKey, planet.AlienPrefab);
    
            var newAlienTransform = planet.GetRandomAlienSpawnPoint();
            ecb.SetComponent(sortKey, newAlien, newAlienTransform);
        }
    }
}