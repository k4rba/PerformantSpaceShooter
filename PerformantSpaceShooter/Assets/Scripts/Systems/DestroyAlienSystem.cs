using ComponentsAndTags;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Systems {
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial struct DestroyAlienSystem : ISystem {
        public void OnUpdate(ref SystemState state) {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach (var enemyPosition in SystemAPI.Query<RefRW<AlienProperties.AlienPosition>>()) {
                if (enemyPosition.ValueRO.Value.y < -40f) {
                    ecb.DestroyEntity(enemyPosition.ValueRO.AssosiatedEntity);
                }
            }

            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}