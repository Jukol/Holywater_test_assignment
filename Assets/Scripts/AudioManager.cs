using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("The Audio Manager is NULL");
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }


    [SerializeField] private AudioClip _buttonSound;
    [SerializeField] private AudioClip _toggleSound;
    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _gameMusic;
    [SerializeField] private AudioSource _musicSource, _sfxSource;
    [SerializeField] private bool _sfxOn = true;
    [SerializeField] private bool _musicOn = true;

    private void Start()
    {
        //TurnMenuMusicOn();
        if (PlayerPrefs.GetInt("SFX", 1) == 1)
        {
            _sfxOn = true;
        }
        else if (PlayerPrefs.GetInt("SFX", 1) == 0)
        {
            _sfxOn = false;
        }

        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            _musicOn = true;
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                TurnMenuMusicOn();
            }
            else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                TurnGameMusicOn();
            }
            
        }
        else if (PlayerPrefs.GetInt("Music", 1) == 0)
        {
            _musicOn = false;
            _musicSource.Stop();
        }
    }

    public void ButtonSound()
    {
        if (_sfxOn)
        {
            _sfxSource.clip = _buttonSound;
            _sfxSource.Play();
        }
    }

    public void ToggleSound()
    {
        if (_sfxOn)
        {
            _sfxSource.clip = _toggleSound;
            _sfxSource.Play();
        }
    }

    public void PlayMenuMusic()
    {
        if (_musicOn)
        {
            _musicSource.clip = _menuMusic;
            _musicSource.Play();
        }
    }

    public void GameMusic()
    {
        if (_musicOn)
        {
            _musicSource.clip = _gameMusic;
            _musicSource.Play();
        }
    }

    public void ToggleSFX()
    {
        _sfxOn = !_sfxOn;

        if (PlayerPrefs.GetInt("SFX", 1) == 1)
        {
            PlayerPrefs.SetInt("SFX", 0);
        }
        else if (PlayerPrefs.GetInt("SFX", 1) == 0)
        {
            PlayerPrefs.SetInt("SFX", 1);
        }

    }

    public void ToggleMusic()
    {
        if (_musicOn == true)
        {
            _musicOn = false;

            if (_musicSource.isPlaying)
            {
                _musicSource.mute = true;
            }
        }
        else if(_musicOn == false)
        {
            _musicOn = true;

            if (_musicSource.isPlaying)
            {
                _musicSource.mute = false;
            }
            else if (!_musicSource.isPlaying)
            {
                TurnMenuMusicOn();
            }
        }
        
        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            PlayerPrefs.SetInt("Music", 0);
        }
        else if (PlayerPrefs.GetInt("Music", 1) == 0)
        {
            PlayerPrefs.SetInt("Music", 1);
        }
    }

    public void TurnMenuMusicOff()
    {
        _musicSource.Stop();
    }

    public void TurnMenuMusicOn()
    {
        _musicSource.clip = _menuMusic;
        _musicSource.Play();
    }

    public void TurnGameMusicOff()
    {
        _musicSource.Stop();
    }

    public void TurnGameMusicOn()
    {
        _musicSource.clip = _gameMusic;
        _musicSource.Play();
    }

}
