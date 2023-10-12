using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Systems {
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct InitializeAlienSystem : ISystem {
        
        [BurstCompile]
        public void OnCreate(ref SystemState state) {
            
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state) {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach (var alien in SystemAPI.Query<AlienWalkAspect>().WithAll<AlienProperties.NewAlienTag>()) {
                ecb.RemoveComponent<AlienProperties.NewAlienTag>(alien.Entity);
                ecb.SetComponentEnabled<AlienProperties.Walk>(alien.Entity, false);
            }
            
            ecb.Playback(state.EntityManager);
        }
    }
}