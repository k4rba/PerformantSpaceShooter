using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags {
    public struct PlayerProjectileMoveSpeed : IComponentData {
        public float Value;
    }

    public struct ProjectilePosition : IComponentData {
        public float3 Value;
        public Entity AssociatedEntity;
    }
    
    public struct ProjectileTag : IComponentData{}
}