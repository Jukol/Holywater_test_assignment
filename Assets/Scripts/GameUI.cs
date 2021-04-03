using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text _coinsNumberText;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        Player.CoinUpdate += UIUpdate;
    }

    private void OnDisable()
    {
        Player.CoinUpdate -= UIUpdate;
    }

    private void Start()
    {
        _coinsNumberText.text = _player.myCoins.ToString();
    }
    private void UIUpdate()
    {
        _coinsNumberText.text = _player.myCoins.ToString();
    }
}
