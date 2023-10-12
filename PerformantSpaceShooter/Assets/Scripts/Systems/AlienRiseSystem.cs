using ComponentsAndTags;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Systems {
    [BurstCompile]
    [UpdateAfter(typeof(AlienInstantiateSystem))]
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct AlienRiseSystem : ISystem {
        [BurstCompile]
        public void OnCreate(ref SystemState state) {
            
        }
        [BurstCompile]
        public void OnDestroy(ref SystemState state) {
            
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            var deltaTime = SystemAPI.Time.DeltaTime;
            var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
            new AlienRiseJob {
                DeltaTime = deltaTime,
                ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter()
            }.ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct AlienRiseJob : IJobEntity {
        public float DeltaTime;
        public EntityCommandBuffer.ParallelWriter ecb;
        [BurstCompile]
        private void Execute(AlienRiseAspect alien, [EntityIndexInQuery]int sortKey) {
            alien.Rise(DeltaTime);

            if (!alien.IsAboveGround) return;
            ecb.RemoveComponent<AlienProperties.RiseRate>(sortKey, alien.Entity);
            ecb.SetComponentEnabled<AlienProperties.Walk>(sortKey, alien.Entity, true);
        }
    }
}