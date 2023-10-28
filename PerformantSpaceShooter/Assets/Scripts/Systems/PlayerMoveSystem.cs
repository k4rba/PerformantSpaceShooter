using Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems {
    [BurstCompile]
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct PlayerMoveSystem : ISystem {
        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            state.CompleteDependency();
            var deltaTime = SystemAPI.Time.DeltaTime;
            new PlayerMoveJob {
                DeltaTime = deltaTime
            }.Schedule();
        }
    
        [BurstCompile]
        public partial struct PlayerMoveJob : IJobEntity {
            public float DeltaTime;
    
            [BurstCompile]
            private void Execute(ref LocalTransform transform, in PlayerProperties.PlayerMoveInputValue moveInput,
                PlayerProperties.Move moveSpeed) {
                transform.Position.xz += moveInput.Value * moveSpeed.MoveSpeed * DeltaTime;
    
                if (transform.Position.x < -25) {
                    transform.Position.x = -25;
                }
                if (transform.Position.x > 25) {
                    transform.Position.x = 25;
                }
            }
            
        }
    }
}