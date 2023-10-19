using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Utilities;

namespace ComponentsAndTags {
    public readonly partial struct PlanetAspect : IAspect {
        public readonly Entity Entity;

        private readonly RefRO<LocalTransform> _localTransform;

        private readonly RefRO<PlanetProperties> _planetProperties;

        private readonly RefRW<PlanetRandom> _planetRandom;

        private readonly RefRW<AlienSpawnPoints> _alienSpawnPoints;

        private readonly RefRW<AlienSpawnTimer> _alienSpawnTimer;

        public int NumberSpawnersToSpawn => _planetProperties.ValueRO.NumberOfSpawnersToSpawn;

        public Entity SpawnerPrefab => _planetProperties.ValueRO.SpawnerPrefab;


        public BlobArray<float3> AlienSpawnPoints {
            get => _alienSpawnPoints.ValueRO.Value.Value.Value;
            set => _alienSpawnPoints.ValueRW.Value.Value.Value = value;
        }

        public bool AlienSpawnPointsInitialized() {
            return _alienSpawnPoints.ValueRO.Value.IsCreated && AlienSpawnPointCount > 0;
        }

        private int AlienSpawnPointCount => _alienSpawnPoints.ValueRO.Value.Value.Value.Length;

        public LocalTransform GetRandomSpawnerTransform() {
            return new LocalTransform {
                Position = GetRandomPosition(),
                Rotation = GetRandomRotation,
                Scale = GetRandomScale(0.75f)
            };
        }

        private float3 GetRandomPosition() {
            
            float3 randomPosition;
            randomPosition = _planetRandom.ValueRW.Value.NextFloat3(MinX, MaxX);
            return randomPosition;
        }

        private float3 MinX => _localTransform.ValueRO.Position.x - HalfDimensions;
        private float3 MaxX => _localTransform.ValueRO.Position.x + HalfDimensions;
        private float3 HalfDimensions => new() {
            x = _planetProperties.ValueRO.FieldDimensions.x,
            y = 0f,
            z = 0f
        };
        
        
        private quaternion GetRandomRotation => quaternion.RotateY(_planetRandom.ValueRW.Value.NextFloat(-0.25f, 0.25f));
        private float GetRandomScale(float min) => _planetRandom.ValueRW.Value.NextFloat(min, 1f);

        public float AlienSpawnTimer {
            get => _alienSpawnTimer.ValueRO.Value;
            set => _alienSpawnTimer.ValueRW.Value = value;
        }

        public bool TimeToSpawnAlien => AlienSpawnTimer <= 0f;

        public float AlienSpawnRate => _planetProperties.ValueRO.AlienSpawnRate;

        public Entity AlienPrefab => _planetProperties.ValueRO.AlienPrefab;

        public LocalTransform GetAlienSpawnPoint() {
            var position = GetRandomAlienSpawnPoint();
            return new LocalTransform {
                Position = position,
                Rotation = quaternion.identity,
                Scale = 1f
            };
        }

        private float3 GetAlienSpawnPoint(int i) => _alienSpawnPoints.ValueRO.Value.Value.Value[i];

        private float3 GetRandomAlienSpawnPoint() {
            return GetAlienSpawnPoint(_planetRandom.ValueRW.Value.NextInt(AlienSpawnPointCount));
        }
    }
}