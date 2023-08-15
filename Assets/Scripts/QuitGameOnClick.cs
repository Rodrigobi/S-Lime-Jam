using UnityEngine;
using UnityEngine.UI;

public class QuitGameOnClick : MonoBehaviour
{
    private void Start()
    {
        Button button = GetComponent<Button>(); // Get the Button component from the GameObject
        button.onClick.AddListener(QuitGame); // Add a listener to the button's click event
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
