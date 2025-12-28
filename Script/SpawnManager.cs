using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUp;

    private GameObject powerUpInstance;

    private float spawnRange = 9f;
    public int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    }

    void Update()
    {
        int enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        if (enemyCount == 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        // evita múltiplas execuções no mesmo frame
        if (powerUpInstance != null)
        {
            Destroy(powerUpInstance);
        }

        waveNumber++;
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerUp()
    {
        powerUpInstance = Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);
    }

    Vector3 GenerateSpawnPosition()
    {
        float x = Random.Range(-spawnRange, spawnRange);
        float z = Random.Range(-spawnRange, spawnRange);
        return new Vector3(x, 0, z);
    }
}
