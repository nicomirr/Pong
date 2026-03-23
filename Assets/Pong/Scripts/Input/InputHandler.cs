using System;
using UnityEngine;

namespace Pong.Input
{
    public class InputHandler : MonoBehaviour
    {
        private IInput _input;

        public void Init(IInput input)
        {            
            _input = input;
        }

        private void Update()
        {
            _input.ChangeDirection();
        }

        private void OnDisable()
        {
            if(_input is IDisposable disposable)
            {                
                disposable.Dispose();
            }

            _input = null;
        }
    }
}



