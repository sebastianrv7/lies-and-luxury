using UnityEngine;
using UnityEngine.InputSystem;

public class SelectableObject : MonoBehaviour
{
    private void Start()
    {
        PlayerInputActions playerInputActions = new();
        
        playerInputActions.Enable();
        playerInputActions.Default.Select.performed += OnSelected;
    }

    private void OnSelected(InputAction.CallbackContext context){
        Debug.Log("Selected");
    }
}
