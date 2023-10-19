using Unity.Entities;

namespace ComponentsAndTags {
    public readonly partial struct PlayerMoveAspect : IAspect {
        public readonly Entity Entity;

        private readonly RefRW<PlayerProperties.Move> _MoveProperties;

        private float moveSpeed => _MoveProperties.ValueRO.MoveSpeed;

    }
}