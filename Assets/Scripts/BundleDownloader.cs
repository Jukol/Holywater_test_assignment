using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;

public class BundleDownloader : MonoBehaviour
{
    public static bool canStart;

    [SerializeField] GameObject _downloadingBar;
    [SerializeField] Image _progressBar;
    [SerializeField] GameObject _progressBarGameObject;
    [SerializeField] Camera _progressCamera;
    [SerializeField] Text _noConnectionMessage, _noConnectionText;

    private uint _version;
    private AssetBundle bundle;
    private float _downloadDataProgress;

    private void OnEnable()
    {
        if (!canStart)
            StartCoroutine(InstantiateObject());
        _noConnectionText.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        bundle.Unload(true);
        BundleDownloader.canStart = false;
    }

    private IEnumerator InstantiateObject()
    {
        string bundleURL = "https://testproject002.s3.amazonaws.com/AssetBundles/scene_objects";
        string versionURL = "https://testproject002.s3.amazonaws.com/AssetBundles/version.txt";

        var versionRequest = UnityWebRequest.Get(versionURL);
        yield return versionRequest.SendWebRequest();

        if (versionRequest.result == UnityWebRequest.Result.Success)
        {
            string version = versionRequest.downloadHandler.text;
            _version = uint.Parse(version);
            PlayerPrefs.SetInt("Version", (int)_version);
        }
        else
        {
            _version = (uint)PlayerPrefs.GetInt("Version", 0);
            _noConnectionText.gameObject.SetActive(true);
            if (_version == 0)
            {
                _noConnectionMessage.gameObject.SetActive(true);
                _progressBarGameObject.SetActive(false);
                yield break;
            }
        }

        var bundleRequest = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL, _version, 0);

        var operation = bundleRequest.SendWebRequest();

        while (!operation.isDone)
        {
            _downloadDataProgress = bundleRequest.downloadProgress;
            _progressBar.fillAmount = _downloadDataProgress;
            yield return null;
        }

        yield return operation;

        _downloadingBar.SetActive(true);

        bundle = DownloadHandlerAssetBundle.GetContent(bundleRequest);
        GameObject sceneObjects = bundle.LoadAsset<GameObject>("Scene_Objects");

        Instantiate(sceneObjects);
        _progressBar.fillAmount = 1f;
        yield return new WaitForSeconds(0.6f);
        _progressCamera.gameObject.SetActive(false);
        AudioManager.Instance.TurnGameMusicOn();
        canStart = true;
    }
}
