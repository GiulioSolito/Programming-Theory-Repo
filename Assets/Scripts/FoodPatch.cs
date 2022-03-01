using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPatch : MonoBehaviour
{
    [SerializeField] private GameObject _foodToSpawn;
    [SerializeField] private float _spawnRate = 2f;

    [SerializeField] private bool _isSpawning = true;
    [SerializeField] private bool _hasItemSpawned = false;

    private Transform _spawnPoint;

    private GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        _spawnPoint = transform.Find("FoodSpawnPoint");

        StartCoroutine(SpawnFood());
    }

    IEnumerator SpawnFood() // ABSTRACTION
    {
        if(_isSpawning == true && _hasItemSpawned == false)
        {
            yield return new WaitForSeconds(_spawnRate);

            go = Instantiate(_foodToSpawn, _spawnPoint.position,_spawnPoint.rotation);
            go.name = go.name.Replace("(Clone)", "").Trim();
            go.transform.SetParent(_spawnPoint);
            _hasItemSpawned = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            other.GetComponent<Player>().Projectile = (GameObject)Resources.Load("Food/" + go.gameObject.name, typeof(GameObject));     
            //Debug.Log("Food/"+)
            Destroy(go.gameObject);
            _hasItemSpawned = false;
            StartCoroutine(SpawnFood());
        }
    }
}
