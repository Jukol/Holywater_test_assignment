using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject _coinPrefab;
    [SerializeField] private float _height = 15f;
    [SerializeField] private float _spawnRate = 0.1f;
    private WaitForSeconds _spawnRateYield;

    private void Start()
    {
        _spawnRateYield = new WaitForSeconds(_spawnRate);
        StartCoroutine(SpawnProcedure());
    }

    private IEnumerator SpawnProcedure()
    {

        while (true)
        {
            if (BundleDownloader.canStart)
            {
                
                SpawnCoins();
            }

            yield return _spawnRateYield;

        }
    }

    private void SpawnCoins()
    {
        float x = Random.Range(-30f, 30f);
        float z = Random.Range(-30f, 30f);

        Vector3 randomPosition = new Vector3(x, _height, z);
        GameObject coin = Instantiate(_coinPrefab, randomPosition, Quaternion.Euler(0, 90, 90));
    }
}
