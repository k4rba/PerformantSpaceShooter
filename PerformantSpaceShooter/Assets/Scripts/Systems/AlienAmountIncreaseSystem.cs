using ComponentsAndTags;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace Systems {
    public partial struct AlienAmountIncreaseSystem : ISystem {
        public void OnUpdate(ref SystemState state) {
            float currentTime = 0;
            float currentSpawnTime = 0.2f;
            float deltaTime = SystemAPI.Time.DeltaTime;
            var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();

            new IncreaseDifficulty() {
                DeltaTime = deltaTime,
                ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)
            }.Run();

        }
        
        public partial struct IncreaseDifficulty : IJobEntity {
            public float DeltaTime;
            public EntityCommandBuffer ecb;
        
            private void Execute(PlanetAspect planet) {
                planet.AlienSpawnTimer -= DeltaTime;
                planet.AlienSpawnTimer = planet.AlienSpawnRate;
            }
        }
    }
}