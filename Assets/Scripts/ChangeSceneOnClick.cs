using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneOnClick : MonoBehaviour
{
    public string sceneToLoad = "NewScene"; // Change this to the name of the scene you want to load

    private void Start()
    {
        Button button = GetComponent<Button>(); // Get the Button component from the GameObject
        button.onClick.AddListener(ChangeScene); // Add a listener to the button's click event
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
