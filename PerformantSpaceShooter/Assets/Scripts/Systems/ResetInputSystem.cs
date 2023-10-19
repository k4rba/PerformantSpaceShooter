using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Systems {
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
    [UpdateAfter(typeof(EndSimulationEntityCommandBufferSystem))]
    public partial struct ResetInputSystem : ISystem{
        public void OnUpdate(ref SystemState state) {
            var ecb = new EntityCommandBuffer(Allocator.Temp);

            foreach (var (tag, entity) in SystemAPI.Query<PlayerProperties.FireProjectileTag>().WithEntityAccess()) {
                ecb.SetComponentEnabled<PlayerProperties.FireProjectileTag>(entity, false);
                
            }
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}