using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovableObject : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rigidbody;

    private bool isHolding;

    private new Camera camera;

    private void Start()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();

        camera = Camera.main;

        PlayerInputActions playerInputActions = new();

        playerInputActions.Enable();
        playerInputActions.Default.Hold.performed += (context) => OnSelected(context);
        playerInputActions.Default.Hold.canceled += _ => isHolding = false;
    }

    private void OnSelected(InputAction.CallbackContext context)
    {
        Func<Vector2> getCursorPosition = null;

        switch (context.control.device)
        {
            case Mouse:
                getCursorPosition = () => Mouse.current.position.ReadValue();
                break;
            case Touchscreen:
                getCursorPosition = () => Touchscreen.current.primaryTouch.position.ReadValue();
                break;
        }

        StartCoroutine(Hold(getCursorPosition));
    }

    private IEnumerator Hold(Func<Vector2> getCursorPosition)
    {
        isHolding = true;

        _rigidbody.gravityScale = 0;

        while (isHolding)
        {
            Vector2 cursorPosition = getCursorPosition();

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(cursorPosition.x, cursorPosition.y, Camera.main.nearClipPlane));

            _transform.position = worldPosition;

            yield return null;
        }

        _rigidbody.gravityScale = 1;
    }
}