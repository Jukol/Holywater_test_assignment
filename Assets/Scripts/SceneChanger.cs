using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private RectTransform _blackRect;


    private void Start()
    {
        _blackRect.gameObject.SetActive(false);
    }
    public void FadeOut()
    {
       
        _blackRect.gameObject.SetActive(true);
        _animator.SetTrigger("FadeOut");
        StartCoroutine(LoadNextScene());
    }

    
    
    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
