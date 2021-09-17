using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Missing GameManager");

            return _instance;
        }
    }

    public bool HasCard { get; set; }

    [SerializeField]
    private GameObject _cutscenes;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SkipCutscene(GetCurrentCutscene());
    }

    private void SkipCutscene(PlayableDirector current)
    {
        if (current != null && current.playableAsset.name.Contains("Start"))
            current.Stop();
    }

    private PlayableDirector GetCurrentCutscene()
    {
        return _cutscenes.GetComponentInChildren<PlayableDirector>();
    }
}
