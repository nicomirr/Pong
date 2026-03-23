using System;
using UnityEngine;

namespace Pong.Audio
{
    [Serializable]
    public struct SFXEntry
    {
        [SerializeField] private SFXType _type;
        public SFXType Type => _type;

        [SerializeField] private AudioClip _clip;
        public AudioClip Clip => _clip; 
    }
}

