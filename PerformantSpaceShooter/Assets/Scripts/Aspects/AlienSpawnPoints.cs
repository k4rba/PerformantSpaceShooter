using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Aspects {
    public struct AlienSpawnPoints : IComponentData {
        public BlobAssetReference<AlienSpawnPointsBlob> Value;
    }

    public struct AlienSpawnPointsBlob {
        public BlobArray<float3> Value;
    }
}