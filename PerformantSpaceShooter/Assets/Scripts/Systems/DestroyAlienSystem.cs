using Aspects;
using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Systems {

    [BurstCompile]
    public partial struct DestroyAlienSystem : ISystem {
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            SystemAPI.TryGetSingletonEntity<PlanetProperties>(out Entity planetSingleton);
            var planet = SystemAPI.GetAspect<PlanetAspect>(planetSingleton);
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach (var enemyPosition in SystemAPI.Query<RefRW<AlienProperties.AlienPosition>>()) {
                if (enemyPosition.ValueRO.Value.y < -80f) {
                    ecb.DestroyEntity(enemyPosition.ValueRO.AssosiatedEntity);
                    planet.AlienAmount--;
                }
            }
        
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
        }
    }