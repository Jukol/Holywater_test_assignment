using UnityEngine;
using UnityEngine.UI;

public class SettingView : MonoBehaviour
{
    [SerializeField] private Toggle _sfx;
    [SerializeField] private Toggle _music;
    private void Start()
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 1)
        {
            _sfx.isOn = true;
        }
        else if (PlayerPrefs.GetInt("SFX", 1) == 0)
        {
            _sfx.isOn = false;
        }

        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            _music.isOn = true;
        }
        else if (PlayerPrefs.GetInt("Music", 1) == 0)
        {
            _music.isOn = false;
        }

        _sfx.onValueChanged.AddListener(OnSfxChange);
        _music.onValueChanged.AddListener(OnMusicChange);
    }

    private void OnMusicChange(bool newValue)
    {
        AudioManager.Instance.ToggleMusic();
        
    }

    private void OnSfxChange(bool newValue)
    {
        AudioManager.Instance.ToggleSFX();
    }
}
