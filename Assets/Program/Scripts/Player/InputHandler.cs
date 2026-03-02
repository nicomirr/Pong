using System;
using UnityEngine;

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
}
