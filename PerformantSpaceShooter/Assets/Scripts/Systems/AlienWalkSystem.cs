using ComponentsAndTags;
using Unity.Burst;
using Unity.Entities;
using Unity.Scenes;
using Unity.Transforms;

namespace Systems {
    [BurstCompile]
    [UpdateAfter(typeof(AlienRiseSystem))]
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct AlienWalkSystem : ISystem {
        
        [BurstCompile]
        public void OnCreate(ref SystemState state) {
            
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state) {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            var deltaTime = SystemAPI.Time.DeltaTime;
            new AlienWalkJob {
                DeltaTime = deltaTime
            }.ScheduleParallel();
        }
    }

    [BurstCompile]
    public partial struct AlienWalkJob : IJobEntity {
        public float DeltaTime;
        

        [BurstCompile]
        private void Execute(AlienWalkAspect alien) {
            
            alien.Walk(DeltaTime);
        }
    }
}