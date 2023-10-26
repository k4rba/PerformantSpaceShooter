using Aspects;
using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace AuthoringAndMono {
    public class AlienMono : MonoBehaviour {
        public float WalkAmplitude;
        public float WalkFrequency;
        public float WalkSpeed;
        public float3 AlienPosition;
    }

    public class AlienBaker : Baker<AlienMono> {
        public override void Bake(AlienMono authoring) {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new AlienProperties.Walk {
                WalkSpeed = authoring.WalkSpeed,
                WalkAmplitude = authoring.WalkAmplitude, 
                WalkFrequency = authoring.WalkFrequency
            });
            AddComponent<AlienProperties.Timer>(entity);
            AddComponent<AlienProperties.AlienHeading>(entity);
            AddComponent<AlienProperties.NewAlienTag>(entity);
            AddComponent(entity, new AlienProperties.AlienPosition{Value = authoring.AlienPosition, AssosiatedEntity = entity});
        }
    }
}