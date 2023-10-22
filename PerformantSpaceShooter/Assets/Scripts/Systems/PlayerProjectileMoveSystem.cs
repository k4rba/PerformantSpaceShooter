using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using Utilities;

namespace Systems {
    public partial struct PlayerProjectileMoveSystem : ISystem {
        public void OnUpdate(ref SystemState state) {
            var deltaTime = SystemAPI.Time.DeltaTime;
            
            foreach (var(transform, moveSpeed, projPosition) in SystemAPI.Query<RefRW<LocalTransform>, PlayerProjectileMoveSpeed, RefRW<ProjectilePosition>>() ) {
                transform.ValueRW.Position.y += moveSpeed.Value * deltaTime;
                projPosition.ValueRW.Value = transform.ValueRO.Position;

            }
        }
    }
}