using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControllerNavigationWithActions : MonoBehaviour
{
    public Button[] buttons;
    private int selectedIndex = 0;

    public InputActionAsset inputActions; // Assign your Input Actions Asset in the Inspector
    private InputAction navigateAction;
    private InputAction submitAction;

    private void OnEnable()
    {
        var uiMap = inputActions.FindActionMap("UI");
        navigateAction = uiMap.FindAction("Navigate");
        submitAction = uiMap.FindAction("Submit");

        navigateAction.performed += OnNavigate;
        submitAction.performed += OnSubmit;

        navigateAction.Enable();
        submitAction.Enable();
    }

    private void OnDisable()
    {
        navigateAction.Disable();
        submitAction.Disable();

        navigateAction.performed -= OnNavigate;
        submitAction.performed -= OnSubmit;
    }

    private void OnNavigate(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if (input.y > 0.5f)
        {
            MoveSelection(-1); // Move Up
        }
        else if (input.y < -0.5f)
        {
            MoveSelection(1); // Move Down
        }
    }

    private void OnSubmit(InputAction.CallbackContext context)
    {
        TriggerButtonAction();
    }

    private void MoveSelection(int direction)
    {
        buttons[selectedIndex].OnDeselect(null);
        selectedIndex = (selectedIndex + direction + buttons.Length) % buttons.Length;
        UpdateButtonSelection();
    }

    private void UpdateButtonSelection()
    {
        buttons[selectedIndex].Select();
    }

    private void TriggerButtonAction()
    {
        buttons[selectedIndex].onClick.Invoke();
    }
}
