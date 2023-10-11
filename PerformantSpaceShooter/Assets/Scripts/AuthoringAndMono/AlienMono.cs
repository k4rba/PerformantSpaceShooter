using ComponentsAndTags;
using Unity.Entities;
using UnityEngine;

namespace AuthoringAndMono {
    public class AlienMono : MonoBehaviour {
        public float RiseRate;
    }

    public class AlienBaker : Baker<AlienMono> {
        public override void Bake(AlienMono authoring) {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new AlienProperties.RiseRate { Value = authoring.RiseRate });
        }
    }
}