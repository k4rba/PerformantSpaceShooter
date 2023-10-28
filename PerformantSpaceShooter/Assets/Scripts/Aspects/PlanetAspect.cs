using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Aspects {
    public readonly partial struct PlanetAspect : IAspect {
        public readonly Entity Entity;

        private readonly RefRO<PlanetProperties> _planetProperties;

        private readonly RefRW<AlienSpawnTimer> _alienSpawnTimer;

        private readonly RefRW<AmountOfAliens> _amntOfAliens;

        private readonly RefRW<RandomValue> _randValue;

        private readonly RefRW<AlienSpawnRate> _alienSpawnRate;

        public int AlienAmount {
            get => _amntOfAliens.ValueRO.Value;
            set => _amntOfAliens.ValueRW.Value = value;
        }

        public float AlienSpawnTimer {
            get => _alienSpawnTimer.ValueRO.Value;
            set => _alienSpawnTimer.ValueRW.Value = value;
        }

        public bool TimeToSpawnAlien => AlienSpawnTimer <= 0f;

        public float AlienSpawnRate {
            get => _alienSpawnRate.ValueRO.Value;
            set => _alienSpawnRate.ValueRW.Value = value;
        }

        public Entity AlienPrefab => _planetProperties.ValueRO.AlienPrefab;

        public LocalTransform GetRandomAlienSpawnPoint() {
            float minX = -25;
            float maxX = 25;

            var xVal = _randValue.ValueRW.Value.NextFloat(minX, maxX);

            float3 SpawnPos = new float3(xVal, -1, 0);
            LocalTransform transform = new LocalTransform();
            transform.Position = SpawnPos;
            transform.Rotation = quaternion.identity;
            transform.Scale = 1.0f;

            return transform;
        }
    }
}