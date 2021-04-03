using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action CoinUpdate;
    public int myCoins { get; private set; } = 0;

    private void OnEnable()
    {
        Coin.OnPickup += AddCoins;
    }

    private void OnDisable()
    {
        Coin.OnPickup -= AddCoins;
    }
    private void AddCoins()
    {
        myCoins++;
        CoinUpdate?.Invoke();
    }
}
