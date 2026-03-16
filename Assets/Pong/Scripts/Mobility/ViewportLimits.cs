using UnityEngine;

namespace Pong.Mobility
{
    [System.Serializable]
    public struct ViewportLimits
    {
        [Header("Límites de la pantalla")]
    
        [Tooltip("Que tan abajo puede ir el jugador")] [Range(0, 1)] [SerializeField]
        private float _minY;

        [Tooltip("Que tan arriba puede ir el jugador")] [Range(0, 1)] [SerializeField]
        private float _maxY;
    
        public float MinY => _minY;
        public float MaxY => _maxY;
    }

}

