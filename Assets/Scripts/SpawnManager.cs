﻿using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private Coroutine _spawningEnemyCoroutine;
    private Coroutine _spawningPowerupCoroutine;
    [SerializeField]
    private GameObject[] _powerups;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        _spawningEnemyCoroutine = StartCoroutine(SpawnEnemyRoutine());
        _spawningPowerupCoroutine = StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 8, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f);
        }

    }

    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 8, 0);
            int powerupIdx = Random.Range(0, _powerups.Length);
            GameObject newEnemy = Instantiate(_powerups[powerupIdx], posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(3f, 7f));
        }

    }

    public void OnPLayerDeath()
    {
        StopCoroutine(_spawningEnemyCoroutine);
        StopCoroutine(_spawningPowerupCoroutine);
    }
}
