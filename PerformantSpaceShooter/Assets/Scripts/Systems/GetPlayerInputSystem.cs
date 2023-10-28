using Components;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems {
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    [BurstCompile]
    public partial class GetPlayerInputSystem : SystemBase {
        private PlayerInputActionMap _movementActions;
        private Entity _playerEntity;
    
        [BurstCompile]
        protected override void OnCreate() {
            RequireForUpdate<PlayerProperties.PlayerTag>();
            RequireForUpdate<PlayerProperties.PlayerMoveInputValue>();
            _movementActions = new PlayerInputActionMap();
        }
    
        [BurstCompile]
        protected override void OnStartRunning() {
            _movementActions.Enable();
            _movementActions.PlayerInputMap.PlayerShootInput.performed += OnPlayerShoot;
            var _playerSingleton = SystemAPI.TryGetSingletonEntity<PlayerProperties.PlayerTag>(out Entity playerSingleton);
            _playerEntity = playerSingleton;
        }
        
        [BurstCompile]
        protected override void OnUpdate() {
            var curMoveInput = _movementActions.PlayerInputMap.PlayerMoveInput.ReadValue<Vector2>();
            SystemAPI.SetSingleton(new PlayerProperties.PlayerMoveInputValue{Value = curMoveInput});
        }
    
        [BurstCompile]
        protected override void OnStopRunning() {
            _movementActions.PlayerInputMap.PlayerShootInput.performed -= OnPlayerShoot;
            _movementActions.Disable();
            _playerEntity = Entity.Null;
        }
    
        [BurstCompile]
        private void OnPlayerShoot(InputAction.CallbackContext obj) {
            if (!SystemAPI.Exists(_playerEntity)) return;
            SystemAPI.SetComponentEnabled<PlayerProperties.FireProjectileTag>(_playerEntity, true);
        }
    }
}