using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnButtonPress : MonoBehaviour
{
    public string sceneToLoad = "NewScene"; // Change this to the name of the scene you want to load

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Change KeyCode.Space to the desired button
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
