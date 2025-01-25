using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControllerNavigationWithActions : MonoBehaviour
{
    // UI Navigation
    public Button[] buttons; // Assign buttons in the Inspector
    private int selectedIndex = 0;

    // Input Actions
    public InputActionAsset inputActions; // Assign the Input Actions Asset in the Inspector
    private InputAction navigateAction;
    private InputAction submitAction;

    // Colors for highlighting buttons and their text
    public Color normalButtonColor = Color.gray;
    public Color highlightedButtonColor = Color.yellow;
    public Color normalTextColor = Color.white;
    public Color highlightedTextColor = Color.red;

    private void OnEnable()
    {
        // Assign actions from InputActionAsset
        var uiMap = inputActions.FindActionMap("UI");
        navigateAction = uiMap.FindAction("Navigate");
        submitAction = uiMap.FindAction("Submit");

        // Subscribe to input actions
        navigateAction.performed += OnNavigate;
        submitAction.performed += OnSubmit;

        // Enable actions
        navigateAction.Enable();
        submitAction.Enable();

        // Highlight the first button by default
        UpdateButtonSelection();
    }

    private void OnDisable()
    {
        // Unsubscribe and disable actions
        navigateAction.performed -= OnNavigate;
        submitAction.performed -= OnSubmit;

        navigateAction.Disable();
        submitAction.Disable();
    }

    private void OnNavigate(InputAction.CallbackContext context)
    {
        // Get the input direction (Vector2)
        Vector2 input = context.ReadValue<Vector2>();

        if (input.y > 0.5f) // Move Up
        {
            MoveSelection(-1);
            Debug.Log("Navigated Up");
        }
        else if (input.y < -0.5f) // Move Down
        {
            MoveSelection(1);
            Debug.Log("Navigated Down");
        }
    }

    private void OnSubmit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log($"Button {selectedIndex} Selected: {buttons[selectedIndex].name}");
            TriggerButtonAction();
        }
    }

    private void MoveSelection(int direction)
    {
        // Reset the color of the currently selected button and its text
        SetButtonAppearance(buttons[selectedIndex], normalButtonColor, normalTextColor);

        // Update the selected index (looping around if necessary)
        selectedIndex = (selectedIndex + direction + buttons.Length) % buttons.Length;

        // Highlight the new button
        UpdateButtonSelection();
    }

    private void UpdateButtonSelection()
    {
        // Highlight the currently selected button and its text
        SetButtonAppearance(buttons[selectedIndex], highlightedButtonColor, highlightedTextColor);

        // Programmatically select the button (useful for keyboard/mouse navigation fallback)
        buttons[selectedIndex].Select();

        Debug.Log($"Button {selectedIndex} Highlighted: {buttons[selectedIndex].name}");
    }

    private void TriggerButtonAction()
    {
        // Invoke the selected button's onClick event
        buttons[selectedIndex].onClick.Invoke();
    }

    private void SetButtonAppearance(Button button, Color buttonColor, Color textColor)
    {
        // Update the button's background color using ColorBlock
        var colors = button.colors;
        colors.normalColor = buttonColor;
        colors.highlightedColor = buttonColor; // Match highlight for simplicity
        button.colors = colors;

        // Update the text color (Text Legacy Component)
        Text text = button.GetComponentInChildren<Text>();
        if (text != null)
        {
            text.color = textColor;
        }
    }
}
