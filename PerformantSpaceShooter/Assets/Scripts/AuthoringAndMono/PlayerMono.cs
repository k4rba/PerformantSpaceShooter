using ComponentsAndTags;
using Unity.Entities;
using UnityEngine;

namespace AuthoringAndMono {
    public class PlayerMono : MonoBehaviour {
        public float PlayerMoveSpeed;
        public GameObject ProjectilePrefab;
    }

    public class PlayerBaker : Baker<PlayerMono> {
        public override void Bake(PlayerMono authoring) {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new PlayerProperties.PlayerTag());
            AddComponent(entity, new PlayerProperties.Move{MoveSpeed = authoring.PlayerMoveSpeed});
            AddComponent(entity, new PlayerProperties.PlayerMoveInputValue());
            AddComponent(entity, new PlayerProperties.FireProjectileTag());
            AddComponent(entity, new PlayerProperties.ProjectilePrefab{Value = GetEntity(authoring.ProjectilePrefab, TransformUsageFlags.Dynamic)});
        }
    }
}