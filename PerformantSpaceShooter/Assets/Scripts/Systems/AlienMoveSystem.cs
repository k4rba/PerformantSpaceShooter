using Aspects;
using Unity.Burst;
using Unity.Entities;

namespace Systems {
    [BurstCompile]
    public partial struct AlienWalkSystem : ISystem {
    
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
        private void Execute(AlienMoveAspect alien) {
            alien.Move(DeltaTime);
        }
    }
}