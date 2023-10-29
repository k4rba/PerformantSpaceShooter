using System.Collections;
using Components;
using TMPro;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace AuthoringAndMono {
    public class ScreenSpaceUI : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _amountOfAliens;
        [SerializeField] private TextMeshProUGUI _fpsText;

        private EntityManager _entityManager;
        private Entity _planetEntity;
        private bool _initialized;
        private float _timer;
        [SerializeField] private float _hudRefreshRate;

        private IEnumerator Start() {
            Application.targetFrameRate = 5000;
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            yield return new WaitForSeconds(0.2f);
            EntityQuery planet = _entityManager.CreateEntityQuery(typeof(PlanetTag));
            planet.TryGetSingletonEntity<PlanetTag>(out Entity planetEntity);
            _planetEntity = planetEntity;
            _initialized = true;
        }

        private void Update() {
            if (!_initialized) return;
            
            if (Time.unscaledTime > _timer) {
                int fps = (int)(1f / Time.unscaledDeltaTime);
                _fpsText.text = "FPS: " + fps;
                _timer = Time.unscaledTime + _hudRefreshRate;
            }

            var currentAmountOfAliens = _entityManager.GetComponentData<AmountOfAliens>(_planetEntity).Value;
            _amountOfAliens.text = $"Current Alien Amount: {currentAmountOfAliens}";
        }
    }
}