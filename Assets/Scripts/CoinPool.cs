using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    private static CoinPool _instance;
    public static CoinPool Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private int _coinsInPool;
    [SerializeField] private GameObject _coinContainer;
    private List<GameObject> _coins = new List<GameObject>();

    private void Start()
    {
        GeneratePool();
    }

    private void GeneratePool()
    {
        for (int i = 0; i < _coinsInPool; i++)
        {
            AddCoinToPool();
        }
    }

    public GameObject CoinRequest()
    {
        foreach (var coin in _coins)
        {
            if (coin.activeInHierarchy == false)
            {
                coin.SetActive(true);
                return coin;
            }
        }
        return AddCoinToPool();
    }
    private GameObject AddCoinToPool()
    {
        GameObject coin = Instantiate(_coinPrefab);
        coin.transform.SetParent(_coinContainer.transform);
        coin.SetActive(false);
        _coins.Add(coin);
        return coin;
    }
}
