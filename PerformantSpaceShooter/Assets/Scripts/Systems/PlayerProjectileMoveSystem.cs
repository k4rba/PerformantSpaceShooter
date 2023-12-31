﻿using Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Systems {
    [BurstCompile]
    public partial struct PlayerProjectileMoveSystem : ISystem {
        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            var deltaTime = SystemAPI.Time.DeltaTime;
    
            foreach (var (transform, moveSpeed, projPosition) in SystemAPI
                         .Query<RefRW<LocalTransform>, PlayerProjectileMoveSpeed, RefRW<ProjectilePosition>>()) {
                transform.ValueRW.Position.y += moveSpeed.Value * deltaTime;
                projPosition.ValueRW.Value = transform.ValueRO.Position;
            }
        }
    }
}