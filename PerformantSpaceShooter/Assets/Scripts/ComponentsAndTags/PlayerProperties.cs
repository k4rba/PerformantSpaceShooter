using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags {
    public static class PlayerProperties {
        public struct Move : IComponentData {
            public float MoveSpeed;
        }

        public struct PlayerMoveInputValue : IComponentData {
            public float2 Value;
        }

        public struct PlayerTag : IComponentData {
        }
        
        public struct FireProjectileTag : IComponentData, IEnableableComponent {
        }

        public struct ProjectilePrefab : IComponentData {
            public Entity Value;
        }
    }
}