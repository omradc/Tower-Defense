using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Singelton
    public static EnemySpawner Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
            Destroy(Instance);
    }
    #endregion

    public int currentEnemyCount;
    public GameObject enemySpawnPoint;
    public int timeToStartWave;
    public Waves[] waves;

    float countDown;
    [HideInInspector] public int waveIndex;
    //public TextMeshProUGUI waveText;

    void Start()
    {
        countDown = timeToStartWave;
    }


    void Update()
    {
        if (currentEnemyCount > 0)
            return;

        countDown -= Time.deltaTime;
        //countDown = Mathf.Clamp(countDown, 0, Mathf.Infinity);
        if (countDown <= 0)
        {
            UI.Instance.waveText.text = $"Wave: {waveIndex + 1}";
            countDown = timeToStartWave;
            StartCoroutine("SpawnEnemy");
        }
    }

    IEnumerator SpawnEnemy()
    {
        Waves _wave = waves[waveIndex];
        for (int i = 0; i < _wave.enemyCount; i++)
        {
            Instantiate(_wave.enemy, enemySpawnPoint.transform.position, enemySpawnPoint.transform.rotation);
            currentEnemyCount++;
            yield return new WaitForSeconds(_wave.enemySpawnRate);
        }

        waveIndex++;

        // Bölüm Geçildi
        if (waves.Length == waveIndex)
        {
            GamePanels.Instance.levelCleared = true;
            this.enabled = false;
        }
    }


}
