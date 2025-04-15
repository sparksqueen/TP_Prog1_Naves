using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 2f;

    private float timer;

    void Update()
    {
        if (!GameManager.instance.isGameStarted)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyToSpawn = enemyPrefabs[index];

       
        Vector3 spawnPosition = GetRandomTopPosition();
        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomTopPosition()
    {
        Vector3 topLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        float randomX = Random.Range(topLeft.x, topRight.x);
        float y = topLeft.y + 1f ;


        return new Vector3(randomX, y, 0f);
    }
}
