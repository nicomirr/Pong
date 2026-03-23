using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        if(Cursor.visible)
        {
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = _camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Mathf.Abs(_camera.transform.position.z)));

        worldPos.z = 0f;
        transform.position = worldPos;
    }

}
