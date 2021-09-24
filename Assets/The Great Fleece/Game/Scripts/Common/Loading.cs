using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Image _progressBar;

    private WaitForSeconds _wait;
    private float _waitTime = 0.1f;

    void Start()
    {
        _wait = new WaitForSeconds(_waitTime);
        StartCoroutine(LoadMainSceneAsync());
    }

    private IEnumerator LoadMainSceneAsync()
    {
        var loading = SceneManager.LoadSceneAsync("Main");

        while (!loading.isDone)
        {
            _progressBar.fillAmount = loading.progress;
            yield return _wait;
        }

    }
}
