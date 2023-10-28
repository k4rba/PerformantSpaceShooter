using Aspects;
using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Systems {
    [BurstCompile]
    public partial struct CollisionSystem : ISystem {
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach (var projPosition in SystemAPI.Query<RefRW<ProjectilePosition>>()) {
                foreach (var enemyPosition in SystemAPI.Query<RefRW<AlienProperties.AlienPosition>>()) {
                    float distance = math.distance(projPosition.ValueRO.Value, enemyPosition.ValueRO.Value);
                    if (distance < 2f) {
                        ecb.DestroyEntity(projPosition.ValueRO.AssociatedEntity);
                        ecb.DestroyEntity(enemyPosition.ValueRO.AssosiatedEntity);
                    }
                }
            }
            
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}