using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace Systems {
    public partial struct PlayerProjectileMoveSystem : ISystem {
        public void OnUpdate(ref SystemState state) {
            var deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var(transform, moveSpeed) in SystemAPI.Query<RefRW<LocalTransform>, PlayerProjectileMoveSpeed>()) {
                transform.ValueRW.Position.y += moveSpeed.Value * deltaTime;
            }
        }
    }
}