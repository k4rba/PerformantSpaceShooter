using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Aspects {
    public readonly partial struct AlienMoveAspect : IAspect {
        public readonly Entity Entity;

        private readonly RefRW<AlienProperties.AlienPosition> _enemyPos;
        private readonly RefRW<LocalTransform> _transform;
        private readonly RefRW<AlienProperties.Timer> _walkTimer;
        private readonly RefRW<AlienProperties.Walk> _walkProperties;
        private readonly RefRW<AlienProperties.AlienHeading> _heading;

        private float3 AlienPosition => _enemyPos.ValueRO.Value;
        private float WalkSpeed => _walkProperties.ValueRO.WalkSpeed;
        private float WalkAmplitude => _walkProperties.ValueRO.WalkAmplitude;
        private float WalkFrequency => _walkProperties.ValueRO.WalkFrequency;
        private float Heading => _heading.ValueRO.Value;


        private float WalkTimer {
            get => _walkTimer.ValueRO.Value;
            set => _walkTimer.ValueRW.Value = value;
        }

        public void Move(float deltaTime) {
            WalkTimer += deltaTime;
            _transform.ValueRW.Position.y += _transform.ValueRO.Position.y * WalkSpeed * deltaTime;
            _enemyPos.ValueRW.Value = _transform.ValueRO.Position;
        }
    }
}