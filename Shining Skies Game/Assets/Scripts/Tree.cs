using UnityEngine;

public class Tree : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
        if (gameManager == null)
            Debug.LogError("GameManager not found in scene!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Optional: check if it's the player to be safe
        if (other.GetComponent<CrowMovement>() != null)
        {
            gameManager.GameOver();
        }
    }
}
