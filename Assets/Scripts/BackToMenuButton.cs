﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        AudioManager.Instance.TurnMenuMusicOn();
    }
}
