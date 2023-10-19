﻿using Unity.Entities;

namespace ComponentsAndTags {
    public static class AlienProperties {
        public struct Walk : IComponentData, IEnableableComponent {
            public float WalkSpeed;
            public float WalkAmplitude;
            public float WalkFrequency;
        }

        public struct Timer : IComponentData {
            public float Value;
        }

        public struct RiseRate : IComponentData {
            public float Value;
        }

        public struct AlienHeading : IComponentData {
            public float Value;
        }
        
        public struct NewAlienTag : IComponentData{}
    }
}