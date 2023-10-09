using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Rendering;

namespace ComponentsAndTags {
    public readonly partial struct PlanetAspect : IAspect {
        public readonly Entity Entity;

        private readonly RefRO<LocalTransform> _localTransform;

        private readonly RefRO<PlanetProperties> _planetProperties;

        private readonly RefRW<PlanetRandom> _planetRandom;

        public int NumberSpawnersToSpawn => _planetProperties.ValueRO.NumberOfSpawnersToSpawn;

        public Entity SpawnerPrefab => _planetProperties.ValueRO.SpawnerPrefab;

        public LocalTransform GetRandomSpawnerTransform() {
            return new LocalTransform {
                Position = GetRandomPosition(),
                Rotation = GetRandomRotation,
                Scale = GetRandomScale(0.75f)
            };
        }

        private float3 GetRandomPosition() {
            
            float3 randomPosition;
            do {
            randomPosition = _planetRandom.ValueRW.Value.NextFloat3(MinCorner, MaxCorner);

            } while (math.distancesq(_localTransform.ValueRO.Position, randomPosition) <= SPACESHIP_SAFETY_RADIUS_SQ);
            return randomPosition;
        }

        private float3 MinCorner => _localTransform.ValueRO.Position - HalfDimensions;
        private float3 MaxCorner => _localTransform.ValueRO.Position + HalfDimensions;
        private float3 HalfDimensions => new() {
            x = _planetProperties.ValueRO.FieldDimensions.x * 0.5f,
            y = 0f,
            z = _planetProperties.ValueRO.FieldDimensions.y * 0.5f
        };

        private const float SPACESHIP_SAFETY_RADIUS_SQ = 5f;
        
        private quaternion GetRandomRotation => quaternion.RotateY(_planetRandom.ValueRW.Value.NextFloat(-0.25f, 0.25f));
        private float GetRandomScale(float min) => _planetRandom.ValueRW.Value.NextFloat(min, 1f);
    }
}