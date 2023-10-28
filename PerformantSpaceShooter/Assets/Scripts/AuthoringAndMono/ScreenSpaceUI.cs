using System.Collections;
using Components;
using TMPro;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace AuthoringAndMono {
    public class ScreenSpaceUI : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _amountOfAliens;

        private EntityManager _entityManager;
        private Entity _planetEntity;
        private bool initialized = false;

        private IEnumerator Start() {
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            yield return new WaitForSeconds(0.2f);
            EntityQuery planet = _entityManager.CreateEntityQuery(typeof(PlanetTag));
            planet.TryGetSingletonEntity<PlanetTag>(out Entity planetEntity);
            _planetEntity = planetEntity;
            initialized = true;
        }

        private void Update() {
            if (initialized) {
                var currentAmountOfAliens = _entityManager.GetComponentData<AmountOfAliens>(_planetEntity).Value;
                _amountOfAliens.text = $"Current Alien Amount: {currentAmountOfAliens}";
            }
        }
    }
}