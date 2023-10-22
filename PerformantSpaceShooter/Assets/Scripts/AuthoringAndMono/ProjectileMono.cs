using ComponentsAndTags;
using Unity.Entities;
using UnityEngine;

namespace AuthoringAndMono {
    public class ProjectileMono : MonoBehaviour {

        public float ProjectileMoveSpeed;

        public class ProjectileMoveSpeedBaker : Baker<ProjectileMono> {
            public override void Bake(ProjectileMono authoring) {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new PlayerProjectileMoveSpeed{Value = authoring.ProjectileMoveSpeed});
                AddComponent(entity, new ProjectilePosition{AssociatedEntity = entity});
                AddComponent(entity, new ProjectileTag());
                AddComponent(entity, new PlayerProperties.ProjectilePrefab());
            }
        }
    }
}