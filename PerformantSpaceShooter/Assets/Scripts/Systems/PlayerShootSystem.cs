using AuthoringAndMono;
using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace Systems {
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct PlayerShootSystem : ISystem {
        public void OnUpdate(ref SystemState state) {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach (var (projectilePrefab, transform) in
                     SystemAPI.Query<PlayerProperties.ProjectilePrefab, LocalTransform>()
                         .WithAll<PlayerProperties.FireProjectileTag>()) {
                var newProjectile = ecb.Instantiate(projectilePrefab.Value);

                var projectileTransform =
                    LocalTransform.FromPositionRotationScale(transform.Position, transform.Rotation, 0.5f);
                
                ecb.SetComponent(newProjectile, projectileTransform);
            }
            
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}