using AuthoringAndMono;
using Aspects;
using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace Systems {
    [BurstCompile]
    public partial struct PlayerShootSystem : ISystem {
        [BurstCompile]
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

            //todo: job
            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}