﻿using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ComponentsAndTags {
    public readonly partial struct AlienRiseAspect : IAspect {
        public readonly Entity Entity;

        private readonly RefRW<LocalTransform> _transformAspect;
        private readonly RefRO<AlienProperties.RiseRate> _alienRiseRate;

        public bool IsAboveGround => _transformAspect.ValueRO.Position.y <= 5f;
        
        public void Rise(float deltaTime) {
            if (_transformAspect.ValueRO.Position.y <= 5) {
            _transformAspect.ValueRW.Position += math.down() * _alienRiseRate.ValueRO.Value * deltaTime;
            }
        }
    }
}