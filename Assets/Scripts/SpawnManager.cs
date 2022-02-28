using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    [SerializeField] private GameObject[] _animalPrefabs;
    [SerializeField] private GameObject _foxPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private float _animalSpawnRate = 2f;
    [SerializeField] private float _foxSpawnRate = 10f;

    [SerializeField] private bool _isSpawning = true;
    public bool IsSpawning // ENCAPSULATION
    {
        get { return _isSpawning; }
        set { _isSpawning = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAnimals());
        StartCoroutine(SpawnFox());
    }

    IEnumerator SpawnAnimals() // ABSTRACTION
    {
        while (_isSpawning)
        {
            yield return new WaitForSeconds(_animalSpawnRate);
            _animalSpawnRate = Random.Range(3f, 6f);

            int animalIndex = Random.Range(0, _animalPrefabs.Length);
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

            Instantiate(_animalPrefabs[animalIndex], _spawnPoints[spawnPointIndex].position,
                        _spawnPoints[spawnPointIndex].rotation);
        }
    }

    IEnumerator SpawnFox() // ABSTRACTION
    {
        while (_isSpawning)
        {
            _foxSpawnRate = Random.Range(20f, 30f);
            yield return new WaitForSeconds(_foxSpawnRate);
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

            Instantiate(_foxPrefab, _spawnPoints[spawnPointIndex].position,
                        _spawnPoints[spawnPointIndex].rotation);
        }
    }
}
