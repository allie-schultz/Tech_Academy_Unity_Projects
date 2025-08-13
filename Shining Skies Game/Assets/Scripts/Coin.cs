using UnityEngine;

public class Coin : MonoBehaviour
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
        if (other.GetComponent<CrowMovement>() != null)
        {
            gameManager.IncreaseScore(1);
            Destroy(gameObject);
        }
    }
}
