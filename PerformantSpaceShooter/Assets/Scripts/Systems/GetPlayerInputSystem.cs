using ComponentsAndTags;
using Unity.Burst;
using Unity.Entities;
using Unity.Scenes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems {
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial class GetPlayerInputSystem : SystemBase {
        private PlayerInputActionMap _movementActions;
        private Entity _playerEntity;

        protected override void OnCreate() {

            RequireForUpdate<PlayerProperties.PlayerTag>();
            RequireForUpdate<PlayerProperties.PlayerMoveInputValue>();
            _movementActions = new PlayerInputActionMap();
        }

        protected override void OnStartRunning() {
            _movementActions.Enable();
            _movementActions.PlayerInputMap.PlayerShootInput.performed += OnPlayerShoot;
            _playerEntity = SystemAPI.GetSingletonEntity<PlayerProperties.PlayerTag>();
        }
        
        protected override void OnUpdate() {
            var curMoveInput = _movementActions.PlayerInputMap.PlayerMoveInput.ReadValue<Vector2>();
            SystemAPI.SetSingleton(new PlayerProperties.PlayerMoveInputValue{Value = curMoveInput});
        }

        protected override void OnStopRunning() {
            _movementActions.PlayerInputMap.PlayerShootInput.performed -= OnPlayerShoot;
            _movementActions.Disable();
            
            _playerEntity = Entity.Null;
        }

        private void OnPlayerShoot(InputAction.CallbackContext obj) {
            if (!SystemAPI.Exists(_playerEntity)) return;
            SystemAPI.SetComponentEnabled<PlayerProperties.FireProjectileTag>(_playerEntity, true);
        }
    }
}