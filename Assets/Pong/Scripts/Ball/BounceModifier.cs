using System;
using UnityEngine;

namespace Pong.Ball
{
    [Serializable]
    public struct BounceModifier
    {
        [Range(0.8f, 1.5f)]
        [SerializeField] private float _bounceFactor;
        public float BounceFactor => _bounceFactor;

        [Range(0.2f, 0.3f)]
        [SerializeField] private float _minVerticalBounce;
        public float MinVerticalBounce => _minVerticalBounce;

        [Range(0.7f, 0.9f)]
        [SerializeField] private float _maxVerticalBounce;
        public float MaxVerticalBounce => _maxVerticalBounce;
    }
}

