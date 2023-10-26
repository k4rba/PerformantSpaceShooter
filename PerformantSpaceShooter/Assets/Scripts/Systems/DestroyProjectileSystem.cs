using Aspects;
using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Systems {
    [BurstCompile]
    public partial struct DestroyProjectileSystem : ISystem {
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach (var projPosition in SystemAPI.Query<RefRW<ProjectilePosition>>()) {
                if (projPosition.ValueRO.Value.y > 20f) {
                    ecb.DestroyEntity(projPosition.ValueRO.AssociatedEntity);
                }
            }

            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}