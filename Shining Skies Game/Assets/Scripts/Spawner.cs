using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;  // 0 = coin, rest = trees
    public float spawnInterval = 1.5f;     // spawn every 1 second
    public float spawnXPosition = 10f;   // offscreen right X pos
    public float minCoinY = -4f;         // lower min Y for coins, closer to bottom
    public float maxCoinY = 1f;          // tighter max Y for coins to avoid top
    public float minTreeYOffset = 0.3f;  // small offset so trees are not floating too high

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        float randomValue = Random.Range(0f, 1f);
        GameObject obj;

        if (randomValue < 0.5f)  // increase chance of coins to 50%
        {
            // Spawn coin with Y between minCoinY and maxCoinY
            obj = Instantiate(objectsToSpawn[0]);
            float coinY = Random.Range(minCoinY, maxCoinY);

            // Add small random X offset so coins don’t stack exactly vertically
            float coinX = spawnXPosition + Random.Range(-1f, 1f);

            obj.transform.position = new Vector3(coinX, coinY, 0);
        }
        else
        {
            // Spawn a tree prefab randomly chosen
            int treeIndex = Random.Range(1, objectsToSpawn.Length);
            obj = Instantiate(objectsToSpawn[treeIndex]);

            float bottomY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
            float spriteHeight = obj.GetComponent<SpriteRenderer>().bounds.size.y;

            // Position tree so its trunk is a bit below the bottom of screen, making it look natural
            float treeY = bottomY + spriteHeight / 2f - minTreeYOffset;

            // Small random X offset so trees don’t spawn perfectly lined up
            float treeX = spawnXPosition + Random.Range(-1f, 1f);

            obj.transform.position = new Vector3(treeX, treeY, 0);
        }
    }
}
