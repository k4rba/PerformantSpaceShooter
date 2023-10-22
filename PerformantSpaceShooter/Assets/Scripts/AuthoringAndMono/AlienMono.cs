using ComponentsAndTags;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace AuthoringAndMono {
    public class AlienMono : MonoBehaviour {
        public float WalkSpeed;
        public float RiseRate;
        public float WalkAmplitude;
        public float WalkFrequency;
        public float3 AlienPosition;
    }

    public class AlienBaker : Baker<AlienMono> {
        public override void Bake(AlienMono authoring) {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(new AlienProperties.RiseRate{Value = authoring.RiseRate});
            AddComponent(new AlienProperties.Walk {
                WalkSpeed = authoring.RiseRate, 
                WalkAmplitude = authoring.WalkAmplitude, 
                WalkFrequency = authoring.WalkFrequency
            });
            AddComponent<AlienProperties.Timer>();
            AddComponent<AlienProperties.AlienHeading>();
            AddComponent<AlienProperties.NewAlienTag>();
            AddComponent(new AlienProperties.AlienPosition{Value = authoring.AlienPosition, AssosiatedEntity = entity});
        }
    }
}