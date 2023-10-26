using System;
using Aspects;
using Components;
using TMPro;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;

namespace AuthoringAndMono {
    public class ScreenSpaceUI : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _amountOfAliens;

        private EntityManager _entityManager;
        private Entity _planetEntity;

        private void Start() {
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            _planetEntity = _entityManager.CreateEntityQuery(typeof(PlanetTag)).GetSingletonEntity();
        }

        private void Update() {
            var currentAmountOfAliens = _entityManager.GetComponentData<AmountOfAliens>(_planetEntity).Value;
            _amountOfAliens.text = $"Current Alien Amount: {currentAmountOfAliens}";
        }
    }
}