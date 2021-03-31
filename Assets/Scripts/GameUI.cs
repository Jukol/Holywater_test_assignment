using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text _coinsNumberText;
    private int _coinsNumber;

    private void OnEnable()
    {
        Coin.OnPickup += CoinCounter;
    }

    private void OnDisable()
    {
        Coin.OnPickup -= CoinCounter;
    }
    private void Start()
    {
        _coinsNumber = 0;
        _coinsNumberText.text = "0";
    }
    private void CoinCounter()
    {
        _coinsNumber++;
        _coinsNumberText.text = _coinsNumber.ToString();
    }
}
