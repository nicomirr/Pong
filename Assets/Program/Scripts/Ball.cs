using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rb.linearVelocity = new Vector2(1*7, 1*7);
    }
    
}
