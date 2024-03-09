using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float counter = 3;
    private float spawnDelay = 3;
    private float roundFirstSeconds = 10;

    public GameObject enemyPrefab;
    private GameObject currentEnemy;
    public TextMeshProUGUI killCounterText;
    public TextMeshProUGUI money;

    List<Transform> enemySpawnPoints = new List<Transform>();

    void Start()
    {
        Transform spawnPointsParent = GameObject.FindGameObjectWithTag("WayPoints").transform;
        foreach(Transform spawnPoint in spawnPointsParent)
            enemySpawnPoints.Add(spawnPoint);
    }

    void Update()
    {
        roundFirstSeconds -= Time.deltaTime;

        killCounterText.text = Enemy.kills.ToString();
        money.text = Enemy.money.ToString();

        counter -= Time.deltaTime;
        if(counter <= 0 && roundFirstSeconds <= 0)
        {
            spawnEnemy();
            counter = spawnDelay;
        }
    }
    void spawnEnemy()
    {
        int i = Random.Range(0, enemySpawnPoints.Count);
        currentEnemy = Instantiate(enemyPrefab, enemySpawnPoints[i].position, enemySpawnPoints[i].rotation);
    }
}
