using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public GameObject confirmationPanel; // Reference to the confirmation panel GameObject
    public Button confirmButton; // Reference to the confirm Button
    public Button cancelButton; // Reference to the cancel Button

    private void Start()
    {
        // Get the Button component attached to this GameObject
        Button exitButton = GetComponent<Button>();

        // Add an event listener for the button's click event
        exitButton.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        // Activate the confirmation panel
        confirmationPanel.SetActive(true);

        // Add event listeners to the confirm and cancel buttons
        confirmButton.onClick.AddListener(ConfirmExit);
        cancelButton.onClick.AddListener(CancelExit);
    }

    private void ConfirmExit()
    {
        // Exit the application when confirmed
        Application.Quit();
    }

    private void CancelExit()
    {
        // Deactivate the confirmation panel and remove event listeners
        confirmationPanel.SetActive(false);
        confirmButton.onClick.RemoveListener(ConfirmExit);
        cancelButton.onClick.RemoveListener(CancelExit);
    }
}
