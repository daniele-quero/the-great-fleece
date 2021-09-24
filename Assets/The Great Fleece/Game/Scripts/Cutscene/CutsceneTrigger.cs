using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _cutscene;

    [SerializeField]
    private GameObject[] _gameObjectsToHide;

    [SerializeField]
    private Transform _mainCameraTransform;

    [SerializeField]
    private UnityEvent _aftermath;

    [SerializeField]
    private bool _isLastCutscene = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _cutscene.SetActive(true);
            double duration = _cutscene.GetComponent<PlayableDirector>().duration;
            StartCoroutine(ResetAtTheEndOfCutscene((float)duration));
        }
    }

    private IEnumerator ResetAtTheEndOfCutscene(float time)
    {
        SetActiveObjects(false);
        yield return new WaitWhile(() => PlayState.Playing == _cutscene.GetComponent<PlayableDirector>().state);
        if(!_isLastCutscene)
        {
            SetActiveObjects(true);
            _cutscene.SetActive(false);
            ResetMainCamera();
            GetComponent<Collider>().enabled = false;

            PerformAftermath(); 
        }
    }

    private void SetActiveObjects(bool active)
    {
        if (_gameObjectsToHide != null)
            foreach (var g in _gameObjectsToHide)
                g.SetActive(active);
    }

    private void ResetMainCamera()
    {
        if (_mainCameraTransform != null)
        {
            Camera.main.transform.position = _mainCameraTransform.position;
            Camera.main.transform.rotation = _mainCameraTransform.rotation;
        }
    }

    private void PerformAftermath()
    {
        if (_aftermath.GetPersistentEventCount() > 0)
            _aftermath.Invoke();
    }

}
