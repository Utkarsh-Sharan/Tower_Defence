using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private Vector3 _spawnPos = new Vector3(4.5f, 2.25f, 4.5f);

    private int _waveNumber = 1;
    private int _currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < _waveNumber;)
        {          
            if(_currentWave != _waveNumber)
            {
                Instantiate(_enemyPrefab, _spawnPos, Quaternion.identity);
                _currentWave++;
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                i++;
                _currentWave = 0;
                _waveNumber++;
                yield return new WaitForSeconds(4f);
            }
        }
    }
}
