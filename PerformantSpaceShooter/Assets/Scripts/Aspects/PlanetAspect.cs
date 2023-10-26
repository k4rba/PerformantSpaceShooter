using Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Utilities;

namespace Aspects {
    public readonly partial struct PlanetAspect : IAspect {
        public readonly Entity Entity;

        private readonly RefRO<LocalTransform> _localTransform;

        private readonly RefRO<PlanetProperties> _planetProperties;

        private readonly RefRW<AlienSpawnPoints> _alienSpawnPoints;

        private readonly RefRW<AlienSpawnTimer> _alienSpawnTimer;

        private readonly RefRW<AmountOfAliens> _amntOfAliens;

        private readonly RefRW<RandomValue> _randValue;

        public int NumberSpawnersToSpawn => _planetProperties.ValueRO.NumberOfSpawnersToSpawn;


        public Entity SpawnerPrefab => _planetProperties.ValueRO.SpawnerPrefab;


        public BlobArray<float3> AlienSpawnPoints {
            get => _alienSpawnPoints.ValueRO.Value.Value.Value;
            set => _alienSpawnPoints.ValueRW.Value.Value.Value = value;
        }

        public int AlienAmount {
            get => _amntOfAliens.ValueRO.Value;
            set => _amntOfAliens.ValueRW.Value = value;
        }

        public float AlienSpawnTimer {
            get => _alienSpawnTimer.ValueRO.Value;
            set => _alienSpawnTimer.ValueRW.Value = value;
        }

        public bool TimeToSpawnAlien => AlienSpawnTimer <= 0f;

        public float AlienSpawnRate => _planetProperties.ValueRO.AlienSpawnRate;

        public Entity AlienPrefab => _planetProperties.ValueRO.AlienPrefab;

        public LocalTransform GetRandomAlienSpawnPoint() {
            float minX = 0;
            float maxX = 20;

            var xVal = _randValue.ValueRW.Value.NextFloat(minX, maxX);

            float3 SpawnPos = new float3(xVal, 25, 0);
            LocalTransform transform = new LocalTransform();
            transform.Position = SpawnPos;
            transform.Rotation = quaternion.identity;
            transform.Scale = 1.0f;

            return transform;
        }
    }
}