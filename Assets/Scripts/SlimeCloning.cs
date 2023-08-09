using UnityEngine;

public class SlimeCloning : MonoBehaviour
{
    public GameObject slimePrefab; // Assign the slime prefab in the Inspector
    public int maxSlimeCount = 2; // Maximum number of slimes allowed in the game
    public float cloneForce = 5f; // Initial force applied to the cloned slime

    private Rigidbody2D rb;
    private int currentSlimeCount = 1; // Start with 1 slime (the original)

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && currentSlimeCount < maxSlimeCount)
        {
            CloneSlime();
        }
    }

    private void FixedUpdate()
    {
        // Your regular movement code here
        // ...
    }

    private void CloneSlime()
    {
        GameObject newSlime = Instantiate(slimePrefab, transform.position, Quaternion.identity);
        Rigidbody2D newRb = newSlime.GetComponent<Rigidbody2D>();

        // Apply initial force to move the cloned slime towards the ceiling
        Vector2 cloneDirection = Vector2.up;
        newRb.AddForce(cloneDirection * cloneForce, ForceMode2D.Impulse);

        currentSlimeCount++;
    }
}
