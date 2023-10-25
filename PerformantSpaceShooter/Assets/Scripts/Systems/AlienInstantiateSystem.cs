using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Systems {
    
    
    [BurstCompile]
    public partial struct AlienInstantiateSystem : ISystem {
        [BurstCompile]
        public void OnCreate(ref SystemState state) {
            
        }
        
        [BurstCompile]
        public void OnDestroy(ref SystemState state) {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            var deltaTime = SystemAPI.Time.DeltaTime;
            var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();
            new SpawnAlienJob() {
                DeltaTime = deltaTime,
                ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)
            }.Run();
        }
    }
    
    [BurstCompile]
    public partial struct SpawnAlienJob : IJobEntity {
        public float DeltaTime;
        public EntityCommandBuffer ecb;

        private void Execute(PlanetAspect planet) {
            planet.AlienSpawnTimer -= DeltaTime;
            if (!planet.TimeToSpawnAlien) return;
            if (!planet.AlienSpawnPointsInitialized()) return;

            planet.AlienAmount++;
            
            planet.AlienSpawnTimer = planet.AlienSpawnRate;
            var newAlien = ecb.Instantiate(planet.AlienPrefab);

            var newAlienTransform = planet.GetAlienSpawnPoint();
            ecb.SetComponent(newAlien, newAlienTransform);
        }
    }
}