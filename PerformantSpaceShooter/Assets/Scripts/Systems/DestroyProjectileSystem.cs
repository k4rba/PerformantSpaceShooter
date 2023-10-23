using ComponentsAndTags;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Systems {
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial struct DestroyProjectileSystem : ISystem {
        public void OnUpdate(ref SystemState state) {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach (var projPosition in SystemAPI.Query<RefRW<ProjectilePosition>>()) {
                if (projPosition.ValueRO.Value.y > 0f) {
                    ecb.DestroyEntity(projPosition.ValueRO.AssociatedEntity);
                }
            }

            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}