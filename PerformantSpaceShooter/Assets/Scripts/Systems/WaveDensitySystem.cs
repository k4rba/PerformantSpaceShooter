// using Components;
// using Unity.Burst;
// using Unity.Entities;
// using UnityEngine;
//
//
// namespace Systems{
//     [BurstCompile]
//     public partial struct WaveDensitySystem : ISystem {
//         private EntityManager _entityManager;
//         private Entity _planetEntity;
//         private float timer;
//         private float interval;
//
//         [BurstCompile]
//         public void OnCreate(ref SystemState state) {
//             SystemAPI.TryGetSingletonEntity<PlanetTag>(out Entity planetSingleton);
//             _planetEntity = planetSingleton;
//             _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
//             timer = 0f;
//             interval = 5f;
//         }
//
//         [BurstCompile]
//         public void OnUpdate(ref SystemState state) {
//             timer += SystemAPI.Time.DeltaTime;
//
//             if (timer >= interval) {
//                 var alienSpawnRate = _entityManager.GetComponentData<AlienSpawnRate>(_planetEntity);
//                     alienSpawnRate.Value -= 0.1f;
//                     _entityManager.SetComponentData(_planetEntity, alienSpawnRate);
//                     timer = 0f;
//             }
//             
//         }
//     }
// }