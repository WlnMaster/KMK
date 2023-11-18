using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public TextMeshProUGUI waveCountText;
    public float spawnRate = 1.0f;
    public float timeBetweenWaves = 3.0f;
    public int enemyCount = 1;
    public int waveCount = 1;
    public GameObject enemy;

    public Transform spawnPoint; // ตำแหน่งที่จะให้ enemy spawn

    bool waveIsDone = true;

    void Update()
    {
        waveCountText.text = "Wave:  " + waveCount.ToString();

        if (waveIsDone == true)
        {
            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {
        waveIsDone = false;
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemyClone = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
        spawnRate -= 0.1f;
        enemyCount += 3;
        waveCount += 1;
        yield return new WaitForSeconds(timeBetweenWaves);
        waveIsDone = true;
    }
}
