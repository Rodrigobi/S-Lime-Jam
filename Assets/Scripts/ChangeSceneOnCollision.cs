using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    public string sceneToLoad = "NewScene"; // Change this to the name of the scene you want to load

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get a reference to the player GameObject
            GameObject player = collision.gameObject;

            // Don't destroy the player GameObject when loading a new scene
            DontDestroyOnLoad(player);

            // Load the new scene asynchronously
            SceneManager.LoadSceneAsync(sceneToLoad);
        }
    }
}
