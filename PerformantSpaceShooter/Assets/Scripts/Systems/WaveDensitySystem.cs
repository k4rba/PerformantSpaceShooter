using Aspects;
using Components;
using Unity.Burst;
using Unity.Entities;

namespace Systems{
    [BurstCompile]
    public partial struct WaveDensitySystem : ISystem {
        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            
            
                SystemAPI.TryGetSingletonEntity<PlanetTag>(out Entity planetEntity);
                var _planetEntity = planetEntity;
                var planetAspect = SystemAPI.GetAspect<PlanetAspect>(_planetEntity);
                planetAspect.EnemySpawnTimer += SystemAPI.Time.DeltaTime;
                
                if (planetAspect.EnemySpawnTimer  >= planetAspect.EnemySpawnInterval) {
                planetAspect.AlienSpawnRate *= 0.8f;
                planetAspect.EnemySpawnTimer  = 0f;
            }
        }
    }
}