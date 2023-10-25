using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.Rendering;

namespace Systems {
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial struct DestroyAlienSystem : ISystem {
        public void OnCreate(ref SystemState state) {

        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            var planetEntity = SystemAPI.GetSingletonEntity<PlanetProperties>();
            var planet = SystemAPI.GetAspect<PlanetAspect>(planetEntity);
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