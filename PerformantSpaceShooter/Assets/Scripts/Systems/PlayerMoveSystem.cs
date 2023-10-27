using Aspects;
using Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.VisualScripting;

namespace Systems {
    [BurstCompile]
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct PlayerMoveSystem : ISystem {
        public void OnUpdate(ref SystemState state) {
            var deltaTime = SystemAPI.Time.DeltaTime;
            new PlayerMoveJob {
                DeltaTime = deltaTime
            }.Schedule();
            //todo: run ?
        }
    
        [BurstCompile]
        public partial struct PlayerMoveJob : IJobEntity {
            public float DeltaTime;
    
            [BurstCompile]
            private void Execute(ref LocalTransform transform, in PlayerProperties.PlayerMoveInputValue moveInput,
                PlayerProperties.Move moveSpeed) {
                transform.Position.xz += moveInput.Value * moveSpeed.MoveSpeed * DeltaTime;
                if (math.lengthsq(moveInput.Value) > float.Epsilon) {
                    var forward = new float3(moveInput.Value.x, 0, 0);
                }
    
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