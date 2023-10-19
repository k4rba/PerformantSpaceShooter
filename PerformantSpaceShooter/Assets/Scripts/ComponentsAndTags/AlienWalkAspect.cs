using Unity.Entities;
using Unity.Transforms;

namespace ComponentsAndTags {
    public readonly partial struct AlienWalkAspect : IAspect {
        public readonly Entity Entity;

        private readonly RefRW<LocalTransform> _transform;
        private readonly RefRW<AlienProperties.Timer> _walkTimer;
        private readonly RefRW<AlienProperties.Walk> _walkProperties;
        private readonly RefRW<AlienProperties.AlienHeading> _heading;

        private float WalkSpeed => _walkProperties.ValueRO.WalkSpeed;
        private float WalkAmplitude => _walkProperties.ValueRO.WalkAmplitude;
        private float WalkFrequency => _walkProperties.ValueRO.WalkFrequency;
        private float Heading => _heading.ValueRO.Value;


        private float WalkTimer {
            get => _walkTimer.ValueRO.Value;
            set => _walkTimer.ValueRW.Value = value;
        }

        public void Walk(float deltaTime) {
            WalkTimer += deltaTime;
            _transform.ValueRW.Position.y += _transform.ValueRO.Position.y * WalkSpeed * deltaTime;
        }
    }
}